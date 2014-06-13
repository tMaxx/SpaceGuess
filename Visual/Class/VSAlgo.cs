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
        private static Regex pnrx = new Regex(@"^[ ]*((positive)|(negative))\(.*$");

        public static void init()
        {
            SpaceForm.self.tbVSPrologOut.Text = "";
            SpaceForm.self.tbVSStatusOut.Text = "";
            logApp("App init");
        }

        public static void resetAll()
        {
            hist = new VSHistory();
            SpaceForm.self.lVSExpTerm.Text = "none";
            SpaceForm.self.lVSLastCmdStatus.Text = "none";
            SpaceForm.self.lvVSGenSpace.Items.Clear();
            SpaceForm.self.lvVSSpecSpace.Items.Clear();
            SpaceForm.self.lvVSHistory.Items.Clear();
            SpaceForm.self.tbVSQuery.Text = "";
            logProlog("---Engine reset---");
            logApp("---App reset---");
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
            if (!pnrx.IsMatch(cmd))
            {
                SpaceForm.self.lVSLastCmdStatus.Text = "przykład nie jest pozytywny ani negatywny";
                return;
            }
            SpaceForm.self.lVSLastCmdStatus.Text = "pending...";

        }

        public static void selectIndexHistory(int i)
        {
            hist.buildLists(i);
        }
    }
}
