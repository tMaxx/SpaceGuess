using Prolog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SbsSW.SwiPlCs;
using System.Windows.Forms;

namespace Visual.Class
{
	class ELItem
	{
		public string
			proof,
			genProof,
			rule;
	}

	class ELAlgo
	{
		private static ELItem item = null;
		public static string previous = null;
		private static string DomTh
		{
			get { return SpaceForm.self.tbELDomainTheory.Text; }
			set { SpaceForm.self.tbELDomainTheory.Text = value; }
		}
		private static string Status
		{
			get { return SpaceForm.self.lELStatus.Text; }
			set
			{
				SpaceForm.self.lELStatus.Text = value;
				SpaceForm.self.Refresh();
			}
		}

		public static void logApp(string str)
		{
			SpaceForm.self.tbVSPrologOut.AppendText("[EL:app] " + str + Environment.NewLine);
		}
		public static void logProlog(string str)
		{
			SpaceForm.self.tbVSPrologOut.AppendText("[EL:prolog] " + str + Environment.NewLine);
		}

		public static void init()
		{
			SpaceForm.self.tbELRuleInput.Text = "";
			SpaceForm.self.tbELOutput.Text = "";
			SpaceForm.self.tbELDomainTheory.Text = "";
			if (!PlEngine.IsInitialized)
			{
				try
				{
					PlEngine.Initialize(new string[] { "-q" });
				}
				catch
				{	//32 on 64 bit
					Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\Program Files (x86)\swipl");
					try
					{
						PlEngine.Initialize(new string[] { "-q" });
					}
					catch
					{	//64/32 bit only
						Environment.SetEnvironmentVariable("SWI_HOME_DIR", @"C:\Program Files\swipl");
						PlEngine.Initialize(new string[] { "-q" });
					}
				}
				PlQuery.PlCall("consult('"
					+ (File.Exists("./source.pl") ? "./source.pl" : "../../source.pl")
					+ "')");
			}

			logApp("---Init---");
		}

		protected static void resetEngine()
		{
			///PlEngine.PlThreadDestroyEngine();
			//P/lEngine.PlThreadAttachEngine();
			//if (ELAlgo.previous != null)
			//{ //retract all :D
			//	string prev = ELAlgo.previous;
			//	ELAlgo.previous = null;
			//	prev = VSHistory.wspaceRx.Replace(prev, "");
			//	foreach (string s in prev.Split('.'))
			//	{
			//		if (s.Length > 0 && !s.StartsWith(":-"))
			//			PlQuery.PlCall("retractall((" + s.TrimEnd('.') + "))");
			//	}
			//}

			SpaceForm.self.tbELOutput.Text = "";
		}

		public static void resetAll()
		{
			resetEngine();
			item = null;
			DomTh = "cup(X) :- liftable(X), holds_liquid(X)."
				+ Environment.NewLine + "holds_liquid(Z) :- part(Z, W), concave(W), points_up(W)."
				+ Environment.NewLine + "liftable(Y) :- light(Y), part(Y, handle)."
				+ Environment.NewLine + "light(A):- small(A)."
				+ Environment.NewLine + "light(A):- made_of(A, feathers)." + Environment.NewLine
				//+ Environment.NewLine + ":- dynamic(small/1)."
				//+ Environment.NewLine + ":- dynamic(owns/2)."
				//+ Environment.NewLine + ":- dynamic(part/2)."
				//+ Environment.NewLine + ":- dynamic(points_up/1)."
				//+ Environment.NewLine + ":- dynamic(concave/1)."
				//+ Environment.NewLine + ":- dynamic(operational/1)."
				//+ Environment.NewLine + ":- dynamic(color/2)." + Environment.NewLine
				+ Environment.NewLine + "small(obj1)."
				+ Environment.NewLine + "owns(bob, obj1)."
				+ Environment.NewLine + "part(obj1, handle)."
				+ Environment.NewLine + "part(obj1, bottom)."
				+ Environment.NewLine + "part(obj1, bowl)."
				+ Environment.NewLine + "points_up(bowl)."
				+ Environment.NewLine + "concave(bowl)."
				+ Environment.NewLine + "color(obj1, red)." + Environment.NewLine
				+ Environment.NewLine + "operational(small(_))."
				+ Environment.NewLine + "operational(part(_, _))."
				+ Environment.NewLine + "operational(owns(_, _))."
				+ Environment.NewLine + "operational(points_up(_))."
				+ Environment.NewLine + "operational(concave(_)).";
			SpaceForm.self.tbELRuleInput.Text = "cup(obj1)";
			Status = "gotowy";
			logApp("---Reset---");
		}

		private static void extractParts(string cmd, out string pred, out string body)
		{
			int at = cmd.IndexOf('(');
			pred = cmd.Substring(0, at);
			body = cmd.Substring(at + 1, cmd.Length - at - 2);
		}

		private static string buildQuery(string pred, string body)
		{
			return "prolog_ebg(" + pred + '(' + body + "), " + pred + "(X), Proof, GenProof), extract_support(GenProof, RuleBody).";
		}

		internal static string tmpFile = null;
		internal static bool bumpTmpFile()
		{
			bool first = tmpFile == null;
			if (first)
				tmpFile = Path.GetTempFileName();

			using (StreamWriter outfile = new StreamWriter(tmpFile, false))
			{
				outfile.Write(DomTh);
			}

			try
			{
				if (first)
					return PlQuery.PlCall("consult('" + tmpFile.Replace(@"\", "/") + "')");
				else
					return PlQuery.PlCall("make");
			}
			catch (Exception e)
			{
				logApp("Error while bumping tmpfile: " + e.ToString());
				return false;
			}
		}
		public static void finish()
		{
			PlEngine.PlCleanup();
			File.Delete(tmpFile);
		}

		internal static void execQuery(string cmd)
		{
			Status = "przygotowywanie polecenia...";
			cmd = VSHistory.wspaceRx.Replace(cmd.Trim(), "");
			if (cmd.EndsWith("."))
				cmd = cmd.TrimEnd('.');

			string pred, body;
			extractParts(cmd, out pred, out body);
			cmd = buildQuery(pred, body);

			Status = "resetowanie silnika Prolog...";

			resetEngine();

			Status = "przygotowywanie teorii...";
			logProlog("commiting theory...");

			if (!bumpTmpFile())
			{
				Status = "błąd przy zapisie stanu teorii";
				//return;
			}

			Status = "wykonywanie polecenia...";

			try
			{
				using (PlQuery q = new PlQuery(cmd))
				{
					item = new ELItem();
					foreach (PlQueryVariables v in q.SolutionVariables)
					{
						//item.x = ;
						item.proof = v["Proof"].ToString();
						item.genProof = v["GenProof"].ToString();
						item.rule = pred + '(' + v["X"].ToString() + ") :- " + v["RuleBody"] + '.';
						break;
					}
					logProlog("exec: " + cmd + Environment.NewLine + q.ToString());
				}
			}
			catch (Exception e)
			{
				Status = "wystąpił błąd; sprawdź konsolę";
				logProlog("ERROR: could not solve: " + e.ToString());
			}

			Status = "drukowanie...";

			SpaceForm.self.tbELOutput.Text = "Zapytanie:" + Environment.NewLine + cmd + Environment.NewLine + Environment.NewLine
				+ "Dowód:" + Environment.NewLine + item.proof + Environment.NewLine + Environment.NewLine
				+ "Dowód ogólny:" + Environment.NewLine + item.genProof
				+ Environment.NewLine + Environment.NewLine + Environment.NewLine
				+ "***Nowa reguła obiektu***:" + Environment.NewLine + item.rule;

			Status = "zakończono";
		}

		internal static void addDerivedFact()
		{
			if (item == null)
				Status = "brak faktu do zapisu!";
			else
			{
				Status = "fakt dodany do teorii dziedziny";
				DomTh += Environment.NewLine + Environment.NewLine + item.rule;
			}
		}
	}
}
