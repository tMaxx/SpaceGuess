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
		public string x,
			proof,
			genProof,
			rule;
	}

	class ELAlgo
	{
		private static PrologEngine pe;
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
			PlEngine.PlThreadDestroyEngine();
			PlEngine.PlThreadAttachEngine();
			if (ELAlgo.previous != null)
			{ //retract all :D
				string prev = ELAlgo.previous;
				string[] buf = {};
				ELAlgo.previous = null;
				prev = VSHistory.wspaceRx.Replace(prev, "");
				foreach (string s in prev.Split('.'))
				{
					PlQuery.PlCall("retract((" + s.TrimEnd('.') + "))");
				}
			}

			SpaceForm.self.tbELOutput.Text = "";
			//pe = new PrologEngine(new SpaceIO("[EL:csp] "));
			//SpaceIO.loadSource(ref pe);
		}

		public static void resetAll()
		{
			resetEngine();
			item = null;
			SpaceForm.self.tbELDomainTheory.Text = "cup(X) :- liftable(X), holds_liquid(X)."
				+ Environment.NewLine + "holds_liquid(Z) :- part(Z, W), concave(W), points_up(W)."
				+ Environment.NewLine + "liftable(Y) :- light(Y), part(Y, handle)."
				+ Environment.NewLine + "light(A):- small(A)."
				+ Environment.NewLine + "light(A):- made_of(A, feathers)." + Environment.NewLine
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
			body = cmd.Substring(at+1, cmd.Length - at - 2);
		}

		private static string buildQuery(string pred, string body)
		{
			return "prolog_ebg(" + pred + '(' + body + "), " + pred + "(X), Proof, GenProof).";//, extract_support(GenProof, RuleBody).";
		}

		internal static void execQuery(string cmd) {
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

			string tmppath = Path.GetTempFileName();
			using (StreamWriter outfile = new StreamWriter(tmppath))
			{
				outfile.Write(DomTh);
			}
			if (!PlQuery.PlCall("consult('" + tmppath.Replace(@"\", "/") + "')."))
			{
				logApp("Error consulting file: " + tmppath);
				Status = "wystąpił błąd; nie można załadować teorii";
				return;
			}
			//pe.Consult(tmppath);
			File.Delete(tmppath); //posprzątaj po sobie

			Status = "wykonywanie polecenia...";
			//pe.Query = cmd;
			using (PlQuery q = new PlQuery(cmd))
			{
				foreach (PlQueryVariables v in q.SolutionVariables)
				{
					item.x = "" + v["X"];
					item.proof = "" + v["Proof"];
					item.genProof = "" + v["GenProof"];
					item.rule = pred + '(' + item.x + ')' + v["RuleBody"];
					break;
				}
			}

			PrologEngine.ISolution s = pe.GetFirstSolution(cmd);
			if (pe.Error)
			{
				Status = "wystąpił błąd; sprawdź konsolę";
				logApp("ERROR: could not solve");
				logProlog("ERROR: " + s);
				pe.clearError();
				return;
			}
			else if (s.Solved)
			{
				logProlog("exec: " + cmd);
				item = new ELItem();
				foreach (PrologEngine.IVarValue vv in s.VarValuesIterator)
					switch (vv.Name)
					{
						case "X":
							item.x = vv.Value.ToString();
							break;
						case "Proof":
							item.proof = vv.Value.ToString();
							break;
						case "GenProof":
							item.genProof = vv.Value.ToString();
							break;
						case "RuleBody":
							item.rule = pred + '(' + item.x + ')' + vv.Value.ToString();
							break;
					}
				logProlog("exec: " + s);
			}
			else
			{
				Status = "błąd: brak rozwiązań";
				logProlog("not solved: " + s);
				return;
			}
			Status = "drukowanie...";



			Status = "zakończono";
		}
	}
}
