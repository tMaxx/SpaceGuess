using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Prolog;

namespace Visual.Class
{
	class VSAlgo
	{
		private static VSHistory hist = null;
		private static bool errorOccured = false;
		public static bool Error
		{
			get { return errorOccured; }
			set { errorOccured = false; }
		}
		private static Regex posnegRx = new Regex(@"^[ ]*((positive)|(negative))\(.*$");

		public static void init()
		{
			SpaceForm.self.tbVSPrologOut.Text = "";
			SpaceForm.self.tbVSStatusOut.Text = "";
			SpaceForm.self.tbVSConceptSpace.Text = "[[small, medium, large]," + Environment.NewLine
				+ "[red, blue, green]," + Environment.NewLine + "[ball, brick, cube]]";
			logApp("---Init---");
		}

		public static void resetAll()
		{
			hist = new VSHistory();
			setProposed(null);
			SpaceForm.self.lVSLastCmdStatus.Text = "wpisz wyrażenie poniżej";
			SpaceForm.self.lvVSGenSpace.Items.Clear();
			SpaceForm.self.lvVSSpecSpace.Items.Clear();
			SpaceForm.self.lvVSHistory.Items.Clear();
			SpaceForm.self.tbVSQuery.Text = "positive([small,red,ball])";
			logApp("---Reset---");
		}

		public static void setProposed(string str)
		{
			if (str == null)
				str = "brak";
			SpaceForm.self.lVSExpTerm.Text = str;
		}

		public static void logApp(string str)
		{
			SpaceForm.self.tbVSStatusOut.AppendText("[VS] " + str + Environment.NewLine);
		}

		public static void logProlog(string str, bool newline = true)
		{
			SpaceForm.self.tbVSPrologOut.AppendText("[VS] " + str + (newline ? Environment.NewLine : ""));
		}

		public static void logPrologCont(string str)
		{
			SpaceForm.self.tbVSPrologOut.AppendText(str + Environment.NewLine);
		}

		public static void setUserStatus(string str)
		{
			SpaceForm.self.lVSLastCmdStatus.Text = str;
		}

		public static void log(string usererr, string prolog = null, string app = null)
		{
			if (prolog != null)
				logProlog(prolog);
			if (app != null)
				logApp(app);
			if (usererr != null)
				setUserStatus(usererr);
		}

		public static void reportError(string usererr, string prolog = null, string app = null)
		{
			errorOccured = true;
			log(
				usererr == null ? null : "błąd: " + usererr,
				prolog == null ? null : "ERROR: " + prolog,
				app == null ? null : "ERROR: " + app
			);
		}

		public static void processRawInput(string cmd)
		{ //bind from VS debug page, pass-through
			try
			{
				hist.pe.Query = cmd;

				logProlog((hist.pe.Error ? "ERROR: " : "query: ") + cmd, false);
				foreach (PrologEngine.ISolution s in hist.pe.SolutionIterator)
				{
					logPrologCont(s + (s.IsLast ? "." : ";"));

					if (hist.pe.Error)
					{
						logApp("Error occured, check console");
						hist.pe.clearError();
					}

					if (s.IsLast) break;
				}
			}
			catch (Exception e)
			{
				logApp("Query exception: " + e.ToString());
			}
			finally
			{
				hist.persist();
			}
		}

		public static void processInput(string cmd)
		{ //bind from VS main
			cmd = cmd.Trim();
			if (!posnegRx.IsMatch(cmd))
			{
				reportError("przykład nie jest pozytywny ani negatywny");
				return;
			}
			errorOccured = false;
			setUserStatus("przetwarzanie...");

			hist.nextQuery(cmd);

			if (!errorOccured)
			{
				setUserStatus("dodano przykład");
				hist.buildLists(-1);
			}
		}

		public static void selectHistoryItem(int i = -1)
		{
			if (i < 0)
			{
				i = SpaceForm.self.lvVSHistory.Items.Count;
				if (i == 0)
					return;
				i--;
			}
			SpaceForm.self.lvVSHistory.SelectedItems.Clear();
			SpaceForm.self.lvVSHistory.Items[i].Selected = true;
		}

		public static void selectIndexHistory(int i)
		{
			hist.buildLists(i);
		}

		public static void selectSpaceLists(int i)
		{
			hist.buildSpaceLists(i);
		}
	}
}
