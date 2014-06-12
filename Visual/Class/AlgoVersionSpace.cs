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
            SpaceGuessForm.self.tbVSPrologOut.Text = "";
            SpaceGuessForm.self.tbVSStatusOut.Text = "";
            logApp("App init");
        }

        public static void resetAll()
        {
            hist = new VSHistory();
            SpaceGuessForm.self.lVSExpTerm.Text = "none";
            SpaceGuessForm.self.lVSLastCmdStatus.Text = "none";
            logProlog("---Engine reset---");
            logApp("---App reset---");
        }

        public static void logApp(string str)
        {
            SpaceGuessForm.self.tbVSStatusOut.Text += "[VS] " + str + Environment.NewLine;
        }

        public static void logProlog(string str)
        {
            SpaceGuessForm.self.tbVSPrologOut.Text += "[VS] " + str + Environment.NewLine;
        }

        public static void processRawInput(string cmd)
        { //bind from VS debug page, pass-through
            try
            {
                hist.pe.Query = cmd;
                foreach (PrologEngine.ISolution s in hist.pe.SolutionIterator)
                {
                    logProlog((hist.pe.Error ? "err: " : "q: ") + cmd + Environment.NewLine + s + (s.IsLast ? "" : ";"));
                    if (hist.pe.Error)
                        logApp("Error occured, check console to the left");

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

            //{
            //    if (ss.HasError)
            //        logApp("Query errors: " + ss.ErrMsg);

            //    string buf = ss.Success + ":" + ss.Count + ":" + ss.Query + Environment.NewLine;

            //    foreach (var single in ss.NextSolution)
            //        foreach (Variable v in single.NextVariable)
            //            buf += string.Format("{0} = {1}", v.Name, v.Value) + Environment.NewLine;

            //    if (buf.Length > 0)
            //        logProlog(buf);
            //}
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
