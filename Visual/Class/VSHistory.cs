using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;
using System.Windows.Forms;

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

		protected VSHistoryItem nminus1;
		protected List<VSHistoryItem> items;
		
		protected bool lasterr = false;
		public bool lastError { get {
			bool e = this.lasterr;
			this.lasterr = false;
			return e; 
		} }

		public string types;

		//constructor
		public VSHistory()
		{
			this.items = new List<VSHistoryItem>();
			this.resetEngine();

			this.nminus1 = new VSHistoryItem("true");
			this.nminus1.gen = "[_,_,_]";
			this.nminus1.spec = "[]";
			this.types = "[[small, medium, large],[red, blue, green],[ball, brick, cube]]";
		}

		public VSHistory(string conceptSpace) : this()
		{
			this.types = conceptSpace;
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
			
			return "process("+cmd+", " + prev.gen + ", " + prev.spec + ", UpdatedG, UpdatedS, " + this.types + ").";
		}
		
		//execute next query with optional removal of items
		public VSHistoryItem nextQuery(string cmd, int atpos = -1)
		{
			VSHistoryItem hi = new VSHistoryItem(cmd);

			if (atpos >= 0)
			{
				this.items.RemoveRange(atpos, (this.items.Count - atpos));
				//catch (ArgumentException) { /*noop*/ }

				this.resetEngine();
				//rebuild history
				for (int i = 0; i <= atpos; i++)
				{
					this.pe.Query = this.buildQuery(this.items[i].cmd, i);

					foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
						if (this.pe.Error)
						{
							VSAlgo.logApp("History rewind error: " + s);
							this.pe.Error = false;
							this.lasterr = true;
						}
					this.persist();
				}
			}
			this.pe.Query = cmd;
			foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
				if (this.pe.Error)
				{
					VSAlgo.logApp("History rewind error: " + s);
					this.pe.Error = false;
					this.lasterr = true;
				}
				else
				{
					//todo: get updated G&S
					foreach (PrologEngine.IVarValue vv in s.VarValuesIterator)
					{

					}
					break; //end after first result
				}
			this.persist();

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
