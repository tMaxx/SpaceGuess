using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;
using System.IO;

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
			SpaceForm.self.tbVSStatusOut.AppendText("[EL] " + str + Environment.NewLine);
		}
		public static void logProlog(string str)
		{
			SpaceForm.self.tbVSPrologOut.AppendText("[EL] " + str + Environment.NewLine);
		}

		public static void init()
		{
			SpaceForm.self.tbELRuleInput.Text = "";
			SpaceForm.self.tbELOutput.Text = "";
			SpaceForm.self.tbELDomainTheory.Text = "";
			logApp("---Init---");
		}

		protected static void resetEngine()
		{
			pe = new PrologEngine(new SpaceIO());
			SpaceIO.loadSource(ref pe);
		}

		public static void resetAll()
		{
			resetEngine();
			item = null;
			SpaceForm.self.tbELDomainTheory.Text = @"cup(X) :- liftable(X), holds_liquid(X).
holds_liquid(Z) :-
 part(Z, W), concave(W), points_up(W).
liftable(Y) :-
 light(Y), part(Y, handle).
 light(A):- small(A).
 light(A):- made_of(A, feathers).

small(obj1).
owns(bob, obj1).
part(obj1, handle).
part(obj1, bottom).
part(obj1, bowl).
points_up(bowl).
concave(bowl).
color(obj1, red).

operational(small(_)).
operational(part(_, _)).
operational(owns(_, _)).
operational(points_up(_)).
operational(concave(_)).";
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
			return "prolog_ebg(" + pred + '(' + body + "), " + pred + "(X), Proof, GenProof), extract_support(GenProof, RuleBody).";
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

			string tmppath = Path.GetTempFileName();
			using (StreamWriter outfile = new StreamWriter(tmppath))
			{
				outfile.Write(DomTh);
			}
			pe.Consult(tmppath);
			File.Delete(tmppath); //posprzątaj po sobie

			Status = "wykonywanie polecenia...";
			pe.Query = cmd;
			foreach (PrologEngine.ISolution s in pe.SolutionIterator)
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
					{
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
					}
				} 
				else
				{
					Status = "brak rozwiązań";
					logProlog("not solved: " + s);
					return;
				}
			Status = "drukowanie...";



			Status = "zakończono";
		}
	}
}
