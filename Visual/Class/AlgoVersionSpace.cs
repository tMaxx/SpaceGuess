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
        private ListView spaceGen = null;
        private ListView spaceSpec = null;

        public static void init()
        {
            hist = new History(ref SpaceGuessForm.self.lvExamplesHist);
            //spaceGen = ref SpaceGuessForm.self.lvGenSpace;
        }
    }
}
