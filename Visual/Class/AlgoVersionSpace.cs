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
        private static History hist = null;
        private static ListView spaceGen = null;
        private static ListView spaceSpec = null;

        public static void init(ref ListView general, ref ListView specific)
        {
            hist = new History(ref SpaceGuessForm.self.lvExamplesHist);
            spaceGen = general;
            spaceSpec = specific;
        }

        public static void processRawInput(string cmd)
        {

        }

        public static void processInput(string cmd)
        {

        }
    }
}
