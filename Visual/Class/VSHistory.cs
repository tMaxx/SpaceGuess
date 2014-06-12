using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;
using System.Windows.Forms;

namespace Visual.Class
{
    struct VSHistoryItem
    {
        public List<ListViewItem> lvcGen, lvcSpec;
        public SolutionSet ss;
        public ListViewItem lvi;

        public VSHistoryItem(ListViewItem i)
        {
            this.lvi = i;
            this.lvcGen = new List<ListViewItem>();
            this.lvcSpec = new List<ListViewItem>();
            this.ss = null;
        }
    }

    class VSHistory
    {
        public PrologEngine pe;
        protected List<VSHistoryItem> items;

        //constructor
        public VSHistory()
        {
            this.pe = new PrologEngine();
            this.items = new List<VSHistoryItem>();
        }

        public void persist()
        {
            this.pe.PersistCommandHistory();
        }

        public SolutionSet rawQuery(string cmd)
        {
            return this.pe.GetAllSolutions(null, cmd);
        }

        //execute next query with optional removal of items
        public VSHistoryItem nextQuery(string cmd, int atpos = -1)
        {
            VSHistoryItem hi = new VSHistoryItem(new ListViewItem(cmd));

            if (atpos >= 0)
            {
                try { this.items.RemoveRange(atpos, (this.items.Count - atpos)); }
                catch (ArgumentException) { /*noop*/ }

                this.pe = new PrologEngine();
                //rebuild history
                foreach (VSHistoryItem lvi in this.items)
                {
                    if ((atpos--) < 0)
                        break;
                    this.pe.GetAllSolutions(null, lvi.lvi.Text);
                    this.persist();
                }
            }
            SolutionSet ss = this.pe.GetAllSolutions(null, cmd);
            this.persist();

            hi.ss = ss;

            this.items.Add(hi);
            return hi;
        }

        //update lists
        public void buildLists(int atpos = -1)
        {
            SpaceGuessForm.self.lvVSGenSpace.Items.Clear();
            SpaceGuessForm.self.lvVSSpecSpace.Items.Clear();
            SpaceGuessForm.self.lvVSHistory.Items.Clear();

            foreach (var itm in this.items)
                SpaceGuessForm.self.lvVSHistory.Items.Add(itm.lvi);

            //build from last
            if (atpos < 0)
                atpos = this.items.Count - 1;

            var last = this.items[atpos];
            foreach (ListViewItem itm in last.lvcGen)
                SpaceGuessForm.self.lvVSGenSpace.Items.Add(itm);
            foreach (ListViewItem itm in last.lvcSpec)
                SpaceGuessForm.self.lvVSSpecSpace.Items.Add(itm);
        }
    }
}
