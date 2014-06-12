using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual.Class
{
    class AlgoVersionSpace
    {
        private static VSHistory hist = null;

        public static void init()
        {
            //noop for now
        }

        public static void processRawInput(string cmd)
        {

        }

        public static void processInput(string cmd)
        {

        }

        public static void resetAll()
        {
            hist = new VSHistory();
            SpaceGuessForm.self.tbVSPrologOut.Text = "";
            SpaceGuessForm.self.tbVSStatusOut.Text = "";
            SpaceGuessForm.self.lVSExpTerm.Text = "none";
            SpaceGuessForm.self.lVSLastCmdStatus.Text = "none";
        }
    }
}
