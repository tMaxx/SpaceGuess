using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visual
{
    public partial class SpaceGuessForm : Form
    {
        public SpaceGuessForm()
        {
            InitializeComponent();
            this.tbVSPrologOut.Text = "";
            this.tbVSStatusOut.Text = "";
            this.lVSExpTerm.Text = "none";
            this.lVSLastCmdStatus.Text = "none";
        }

        private void bSendVSDirectQuery_Click(object sender, EventArgs e)
        {
            //text, tytuł, buttony, ikona, ...
            //hwnd
            MessageBox.Show(this.tbVSDirectQuery.Text);
        }
    }
}
