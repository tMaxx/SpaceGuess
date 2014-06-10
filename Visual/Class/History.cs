using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;

namespace Visual.Class
{
    class History
    {
        //engine history
        protected List<PrologEngine> engHistory;
        //cursor
        protected int curItem;

        public History()
        {
            this.engHistory = new List<PrologEngine>();
            this.engHistory.Add(new PrologEngine());
            this.curItem = 0;
        }

        protected void next()
        {
            if (this.curItem < this.engHistory.Count - 1)
            {
                //do sth with elements after
            }

            var last = this.engHistory[this.curItem];
        }

        //public SolutionSet execQuery(string input)
        //{

        //}

        
    }
}
