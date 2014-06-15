using System;
using System.Collections.Generic;
using Prolog;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Linq;

namespace Visual.Class
{
	struct VSHistoryItem
	{
		public List<ListViewItem> listGen, listSpec;
		public string gen, spec;
		public ListViewItem lviCmd;
		public readonly string cmd;

		public VSHistoryItem(ref string c)
		{
			c = c.Trim();
			if (c.EndsWith("."))
				c = c.TrimEnd('.');

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
		//instancja engine'a
		public PrologEngine pe;

		//element inicjujacy
		protected readonly VSHistoryItem initial;
		//kolekcja wszytskich elementów używanych do wyświetlania
		public List<VSHistoryItem> items;

		//typy - słownik dopuszczalnych elementów w definicji instancji
		public readonly string types;

		//regex do wywalania spacji
		public static Regex wspaceRx = new Regex(@"\s+");

		//constructor
		public VSHistory()
		{
			this.items = new List<VSHistoryItem>();
			this.resetEngine();

			string cmd = "true";
			this.initial = new VSHistoryItem(ref cmd);

			this.types = wspaceRx.Replace(SpaceForm.self.tbVSConceptSpace.Text, "");
			cmd = String.Concat(Enumerable.Repeat("_,", countOccurences("],[", this.types)));

			this.initial.gen = "[[" + cmd + "_]]";
			this.initial.spec = "[]";
		}

		private void resetEngine()
		{
			this.pe = new PrologEngine(new SpaceIO());
			try
			{ //launched in /bin/debug|release
				this.pe.Consult(@"../../source.pl");
			}
			catch
			{ //standalone program
				try
				{
					this.pe.Consult(@"./source.pl");
				}
				catch
				{
					MessageBox.Show("Nie znaleziono pliku z kodem źródłowym algorytmów."
						+ Environment.NewLine + Environment.NewLine
						+ "Należy go umieścić w katalogu razem z plikiem wykonywalnym aplikacji, w pliku o nazwie 'source.pl'."
						+ Environment.NewLine
						+ "Bez powyższego pliku aplikacja nie może kontynuować działania.", "Nie znaleziono pliku źródłowego",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					Environment.Exit(1);
				}
			}
			VSAlgo.logProlog("---Engine reset---");
		}

		public void persist()
		{
			this.pe.PersistCommandHistory();
		}

		public readonly static Regex anonVar = new Regex(@"_[0-9]+");
		protected string[] setLists(string str, ref List<ListViewItem> l)
		{
			str = wspaceRx.Replace(str, "");
			if (str == "[]" || str == "" || str == "[[]]")
			{
				l.Add(new ListViewItem("<pusta>"));
				return new string[] { "<pusta>" };
			}
			else
			{
				str = str.Substring(2, str.Length - 4); //4: start index & snip 2 last chars
				string[] buf = new string[] { "],[" };
				buf = str.Split(buf, StringSplitOptions.None);
				for (int i = 0, len = buf.Length; i < len; i++)
				{
					buf[i] = anonVar.Replace(buf[i].Replace(",", ", "), "<?>");
					l.Add(new ListViewItem(buf[i]));
				}
				return buf;
			}
		}

		protected string buildQuery(string cmd, int atpos = -1)
		{
			VSHistoryItem prev;

			if (this.items.Count == 0)
				prev = this.initial;
			else
			{
				if (atpos < 0) //newest
					atpos = this.items.Count - 1;
				prev = this.items[atpos];
			}

			return "process(" + cmd + ", " + prev.gen + ", " + prev.spec + ", UpdatedG, UpdatedS, " + this.types + ").";
		}
		
		//execute next query with optional removal of items
		public void nextQuery(string cmd, int atpos = -1)
		{
			VSHistoryItem hi = new VSHistoryItem(ref cmd);

			if (atpos >= 0)
			{
				this.items.RemoveRange(atpos, (this.items.Count - atpos));

				this.resetEngine();
				//rebuild history
				VSAlgo.setUserStatus("odtwarzanie historii...");
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
			VSAlgo.logProlog("Exec: " + this.pe.Query, false);

			bool first = true;
			foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
				if (this.pe.Error)
				{
					VSAlgo.reportError("nieudane zatwierdzanie; sprawdź konsolę",
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
					VSAlgo.setUserStatus("aktualizacja przestrzeni...");
					VSAlgo.logPrologCont(s.ToString());
					//don't crawl through other results
					first = false;
				}
				else
					break;
			this.persist();

			if (!VSAlgo.Error)
			{
				string[] bs, bg;

				bs = this.setLists(hi.spec, ref hi.listSpec);
				bg = this.setLists(hi.gen, ref hi.listGen);

				VSAlgo.setProposed(null);
				//add colors
				if (ArraysEqual<string>(bs, bg))
				{
					hi.lviCmd.ForeColor = System.Drawing.Color.Yellow;
					VSAlgo.setProposed(hi.lviCmd.Text);
				}
				if (Regex.IsMatch(cmd, @"^[ ]*(negative)\(.*$"))
					hi.lviCmd.ForeColor = System.Drawing.Color.DarkRed;
				else
					hi.lviCmd.ForeColor = System.Drawing.Color.DarkGreen;

				this.items.Add(hi);
			}
		}

		protected bool buildLocked = false;
		//update lists
		public void buildLists(int atpos = -1)
		{
			if (buildLocked)
				return;
			buildLocked = true;
		
			SpaceForm.self.lvVSHistory.Items.Clear();

			foreach (var itm in this.items)
				SpaceForm.self.lvVSHistory.Items.Add(itm.lviCmd);

			//build from last
			VSAlgo.selectHistoryItem(atpos);

			//this.buildSpaceLists(atpos);
			buildLocked = false;
		}

		public void buildSpaceLists(int atpos = -1)
		{
			//build from last
			if (atpos < 0)
				atpos = this.items.Count - 1;
			var last = this.items[atpos];

			SpaceForm.self.lvVSGenSpace.Items.Clear();
			SpaceForm.self.lvVSSpecSpace.Items.Clear();

			foreach (ListViewItem itm in last.listGen)
				SpaceForm.self.lvVSGenSpace.Items.Add(itm);
			foreach (ListViewItem itm in last.listSpec)
				SpaceForm.self.lvVSSpecSpace.Items.Add(itm);
		}

		///////////////////////////////////////////////////////////////Additional functions

		//src:http://stackoverflow.com/a/713355
		static bool ArraysEqual<T>(T[] a1, T[] a2)
		{
			if (ReferenceEquals(a1, a2))
				return true;

			if (a1 == null || a2 == null)
				return false;

			if (a1.Length != a2.Length)
				return false;

			EqualityComparer<T> comparer = EqualityComparer<T>.Default;
			for (int i = 0; i < a1.Length; i++)
			{
				if (!comparer.Equals(a1[i], a2[i])) return false;
			}
			return true;
		}

		//src: http://stackoverflow.com/a/542001
		static int countOccurences(string needle, string haystack)
		{
			return (haystack.Length - haystack.Replace(needle, "").Length) / needle.Length;
		}
	}
}
