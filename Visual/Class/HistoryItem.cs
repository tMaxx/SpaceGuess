using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prolog;

namespace Visual.Class
{
    struct HistoryItem
    {
        PrologEngine engine = null;
        readonly string command = "";

        HistoryItem(string cmd)
        {
            this.engine = new PrologEngine();
            this.command = cmd;
        }
    }
}
