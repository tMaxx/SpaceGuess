using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prolog;

namespace Visual.Class
{
    class AlgoVersionSpace
    {
        private static VSHistory hist = null;

        public static void init()
        {
            //noop for now
        }

        public static void resetAll()
        {
            hist = new VSHistory();
            SpaceGuessForm.self.tbVSPrologOut.Text = "";
            SpaceGuessForm.self.tbVSStatusOut.Text = "";
            SpaceGuessForm.self.lVSExpTerm.Text = "none";
            SpaceGuessForm.self.lVSLastCmdStatus.Text = "none";
        }

        public static void logApp(string str)
        {
            SpaceGuessForm.self.tbVSStatusOut.Text += "(VS:) " + str + Environment.NewLine;
        }

        public static void logProlog(string str)
        {
            SpaceGuessForm.self.tbVSPrologOut.Text += "(VS:) " + str + Environment.NewLine;
        }

        public static void processRawInput(string cmd)
        { //bind from VS debug page, pass-through
            SolutionSet ss = null;

            try
            {
                ss = hist.rawQuery(cmd);
            }
            catch (Exception e)
            {
                logApp("Query exception: " + e.ToString());
            }

            if (ss == null || !ss.Success)
                logApp("Query error: '" + cmd + "'");

            string buf = "";
            foreach (var single in ss.NextSolution)
                foreach (Variable v in single.NextVariable)
                    buf += string.Format("{0} = {1}", v.Name, v.Value) + Environment.NewLine;

            logProlog(buf);
        }

        public static void processInput(string cmd)
        { //bind from VS main

        }

        public static void selectIndexHistory(int i)
        {
            hist.buildLists(i);
        }
    }
}
