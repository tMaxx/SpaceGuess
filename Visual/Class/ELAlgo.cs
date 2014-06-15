using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;

namespace Visual.Class
{
	class ELAlgo
	{
		private static PrologEngine pe;
		private static string DomTh
		{
			get { return SpaceForm.self.tbELDomainTheory.Text; }
			set { SpaceForm.self.tbELDomainTheory.Text = value; }
		}

		public static void logApp(string str)
		{
			SpaceForm.self.tbVSStatusOut.AppendText("[EL] " + str + Environment.NewLine);
		}
		public static void logProlog(string str)
		{
			SpaceForm.self.tbVSStatusOut.AppendText("[EL] " + str + Environment.NewLine);
		}

		public static void init()
		{
			SpaceForm.self.tbELRuleInput.Text = "";
			SpaceForm.self.tbELOutput.Text = "";
			SpaceForm.self.tbELDomainTheory.Text = "";
			logApp("---Init---");
		}

		public static void resetAll()
		{
			pe = new PrologEngine(new SpaceIO());
			SpaceIO.loadSource(ref pe);
			SpaceForm.self.tbELDomainTheory.Text = "";
			SpaceForm.self.tbELRuleInput.Text = "";
			logApp("---Reset---");
		}

		private static void extractParts(string cmd, out string pred, out string body)
		{
			int at = cmd.IndexOf('(') + 1;
			pred = cmd.Substring(0, at);
			body = cmd.Substring(at, cmd.Length - 2);
		}

		private static string buildQuery(string pred, string body)
		{
			return "prolog_ebg(" + pred + '(' + body + "), " + pred + "(X), P, GenP), extract_support(GenP, RuleBody).";
		}

		internal static void execQuery(string cmd)
		{
			cmd = VSHistory.wspaceRx.Replace(cmd.Trim(), "");
			if (cmd.EndsWith("."))
				cmd = cmd.TrimEnd('.');

			string pred, body;
			extractParts(cmd, out pred, out body);
			cmd = buildQuery(pred, body);
			pe.Query = cmd;
		}
	}
}
