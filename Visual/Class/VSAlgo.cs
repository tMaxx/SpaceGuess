using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prolog;

namespace Visual.Class
{
    class VSAlgo
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
            SpaceGuessForm.self.lvVSGenSpace.Items.Clear();
            SpaceGuessForm.self.lvVSSpecSpace.Items.Clear();
            SpaceGuessForm.self.lvVSHistory.Items.Clear();
            SpaceGuessForm.self.tbVSQuery.Text = "";
            logProlog("---Engine reset---");
            logApp("---App reset---");
        }

        public static void logApp(string str)
        {
            SpaceGuessForm.self.tbVSStatusOut.AppendText("[VS] " + str + Environment.NewLine);
        }

        public static void logProlog(string str, bool newline = true)
        {
            SpaceGuessForm.self.tbVSPrologOut.AppendText("[VS] " + str + (newline ? Environment.NewLine : ""));
        }

        public static void logPrologCont(string str)
        {
            SpaceGuessForm.self.tbVSPrologOut.AppendText(str + Environment.NewLine);
        }

        public static void processRawInput(string cmd)
        { //bind from VS debug page, pass-through
            try
            {
                hist.pe.Query = cmd;
                //bool first = true;
                logProlog((hist.pe.Error ? "ERROR: " : "query: ") + cmd, false);
                foreach (PrologEngine.ISolution s in hist.pe.SolutionIterator)
                {
                    cmd = "";
                    //foreach (PrologEngine.IVarValue v in s.VarValuesIterator)
                    //    cmd += Environment.NewLine + v;
                    logPrologCont(cmd + s + (s.IsLast ? "." : ";"));

                    if (hist.pe.Error)
                    {
                        logApp("Error occured, check console");
                        hist.pe.Error = false;
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

        }

        public static void selectIndexHistory(int i)
        {
            hist.buildLists(i);
        }
    }
}
