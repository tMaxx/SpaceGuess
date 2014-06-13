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
        public string cmd;
        public ListViewItem lvi;

        public VSHistoryItem(ListViewItem i)
        {
            this.lvi = i;
            this.lvcGen = new List<ListViewItem>();
            this.lvcSpec = new List<ListViewItem>();
            this.cmd = null;
        }
    }

    class VSHistory
    {
        public PrologEngine pe;
        protected List<VSHistoryItem> items;
        protected bool lasterr = false;
        public bool lastError { get {
            bool e = this.lasterr;
            this.lasterr = false;
            return e; 
        } }

        //constructor
        public VSHistory()
        {
            this.items = new List<VSHistoryItem>();
            this.resetEngine();
        }

        private void resetEngine()
        {
            this.pe = new PrologEngine(new SpaceIO());
            this.pe.Consult(@"..\..\..\MLAiP_VersionSpace.pl");
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

                this.resetEngine();
                //rebuild history
                foreach (VSHistoryItem lvi in this.items)
                {
                    if ((atpos--) < 0)
                        break;
                    this.pe.Query = lvi.lvi.Text;
                    foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
                        if (this.pe.Error)
                        {
                            VSAlgo.logApp("History rewind error: " + s);
                            this.pe.Error = false;
                            this.lasterr = true;
                        }
                    this.persist();
                }
            }
            this.pe.Query = cmd;
            foreach (PrologEngine.ISolution s in this.pe.SolutionIterator)
                if (this.pe.Error)
                {
                    VSAlgo.logApp("History rewind error: " + s);
                    this.pe.Error = false;
                    this.lasterr = true;
                }
            this.persist();

            hi.cmd = cmd;

            this.items.Add(hi);
            return hi;
        }

        //update lists
        public void buildLists(int atpos = -1)
        {
            SpaceForm.self.lvVSGenSpace.Items.Clear();
            SpaceForm.self.lvVSSpecSpace.Items.Clear();
            SpaceForm.self.lvVSHistory.Items.Clear();

            foreach (var itm in this.items)
                SpaceForm.self.lvVSHistory.Items.Add(itm.lvi);

            //build from last
            if (atpos < 0)
                atpos = this.items.Count - 1;

            var last = this.items[atpos];
            foreach (ListViewItem itm in last.lvcGen)
                SpaceForm.self.lvVSGenSpace.Items.Add(itm);
            foreach (ListViewItem itm in last.lvcSpec)
                SpaceForm.self.lvVSSpecSpace.Items.Add(itm);
        }
    }
}
