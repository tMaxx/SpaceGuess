using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;
using System.Windows.Forms;

namespace Visual.Class
{
    class History
    {
        //to form view
        protected ListView lv;
        protected PrologEngine pe;

        public History(ref ListView list)
        {
            this.lv = list;
            this.pe = new PrologEngine();
        }

        public SolutionSet nextQuery(string cmd, int pos = -1)
        {
            ListViewItem itm = new ListViewItem(cmd);
            SolutionSet ss = null;


            if (pos >= 0)
            {
                try { while (true) lv.Items.RemoveAt(pos); }
                catch (ArgumentOutOfRangeException e) { /*noop*/ }

                this.pe = new PrologEngine();

                foreach (ListViewItem lvi in lv.Items)
                    this.pe.GetAllSolutions(null, lvi.Text);
            }
            ss = this.pe.GetAllSolutions(null, cmd);

            this.lv.Items.Add(itm);
            return ss;
        }
    }
}
