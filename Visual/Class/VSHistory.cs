using System;
using System.Collections.Generic;
using Prolog;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Visual.Class
{
	struct VSHistoryItem
	{
		public List<ListViewItem> listGen, listSpec;
		public string gen, spec;
		public ListViewItem lviCmd;
		public readonly string cmd;

		public VSHistoryItem(string c)
		{
			this.lviCmd = new ListViewItem(c);
			this.listGen = new List<ListViewItem>();
			this.listSpec = new List<ListViewItem>();

			this.gen = "";
			this.spec = "";
			this.cmd = c;
		}
	}

	class VSHistory
	{
		public PrologEngine pe;

		protected readonly VSHistoryItem nminus1;
		public List<VSHistoryItem> items;

		public string types;

		//constructor
		public VSHistory()
		{
			this.items = new List<VSHistoryItem>();
			this.resetEngine();

			this.nminus1 = new VSHistoryItem("true");
			this.nminus1.gen = "[_,_,_]";
			this.nminus1.spec = "[]";
			this.types = Regex.Replace(SpaceForm.self.tbVSConceptSpace.Text, @"\s+", "");
		}

		private void resetEngine()
		{
			this.pe = new PrologEngine(new SpaceIO());
			try
			{ //launched in /bin/debug|release
				this.pe.Consult(@"../../vs_source.pl");
			}
			catch (Exception)
			{ //standalone program
				this.pe.Consult(@"./vs_source.pl");
			}
			VSAlgo.logProlog("---Engine reset---");
		}

		public void persist()
		{
			this.pe.PersistCommandHistory();
		}

		protected string buildQuery(string cmd, int atpos = -1)
		{
			VSHistoryItem prev;

			if (this.items.Count == 0)
				prev = this.nminus1;
			else
			{
				if (atpos < 0) //newest
					atpos = this.items.Count - 1;
				prev = this.items[atpos];
			}
			if (cmd.EndsWith("."))
				cmd.TrimEnd('.');

			return "process(" + cmd + ", " + prev.gen + ", " + prev.spec + ", UpdatedG, UpdatedS, " + this.types + ").";
		}
		
		//execute next query with optional removal of items
		public VSHistoryItem nextQuery(string cmd, int atpos = -1)
		{
			VSHistoryItem hi = new VSHistoryItem(cmd);

			if (atpos >= 0)
			{
				this.items.RemoveRange(atpos, (this.items.Count - atpos));

				this.resetEngine();
				//rebuild history
				for (int i = 0; i <= atpos; i++)
				{
					this.pe.Query = this.buildQuery(this.items[i].cmd, i);

					foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
						if (this.pe.Error)
						{
							VSAlgo.reportError("niepowodzenie w odtwarzaniu historii; sprawdź konsolę",
								"History rewind error on item " + i + ": " + s,
								"History rewind error on item " + i);
							this.pe.clearError();
						}
					this.persist();
				}
			}

			this.pe.Query = this.buildQuery(cmd, atpos);
			bool first = true;
			foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
				if (this.pe.Error)
				{
					VSAlgo.reportError("Błąd przy zatwierdzaniu; sprawdź konsolę",
						"History commit error: " + s,
						"History commit error");
					this.pe.clearError();
				}
				else if (first)
				{
					foreach (PrologEngine.IVarValue vv in s.VarValuesIterator)
					{
						if (vv.Name == "UpdatedG")
							hi.gen = vv.Value.ToString();
						else if (vv.Name == "UpdatedS")
							hi.spec = vv.Value.ToString();
					}
					//don't crawl through other results
					first = false;
				}
			this.persist();

			//add colors
			if (Regex.IsMatch(cmd, @"^[ ]*(negative)\(.*$"))
				hi.lviCmd.ForeColor = System.Drawing.Color.DarkRed;
			else
				hi.lviCmd.ForeColor = System.Drawing.Color.DarkGreen;

			if (!VSAlgo.Error)
				this.items.Add(hi);
			return hi;
		}

		//update lists
		public void buildLists(int atpos = -1)
		{
			SpaceForm.self.lvVSGenSpace.Items.Clear();
			SpaceForm.self.lvVSSpecSpace.Items.Clear();
			SpaceForm.self.lvVSHistory.Items.Clear();

			foreach (var itm in this.items)
				SpaceForm.self.lvVSHistory.Items.Add(itm.lviCmd);

			//build from last
			if (atpos < 0)
				atpos = this.items.Count - 1;

			var last = this.items[atpos];
			foreach (ListViewItem itm in last.listGen)
				SpaceForm.self.lvVSGenSpace.Items.Add(itm);
			foreach (ListViewItem itm in last.listSpec)
				SpaceForm.self.lvVSSpecSpace.Items.Add(itm);
		}
	}
}
