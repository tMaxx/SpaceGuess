using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;

namespace Visual.Class
{
    class HistoryItem
    {
        protected PrologEngine engine = null;

        public HistoryItem()
        {
            this.engine = new PrologEngine()
        }
    }
}
