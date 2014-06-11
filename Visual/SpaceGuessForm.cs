using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual.Class;

namespace Visual
{
    public partial class SpaceGuessForm : Form
    {
        public static SpaceGuessForm self = null;

        public SpaceGuessForm()
        {
            if (self == null)
                self = this;
            else
                throw new Exception("Nope");

            //import z this.Designer.cs
            InitializeComponent();

            //clean up
            this.tbVSPrologOut.Text = "";
            this.tbVSStatusOut.Text = "";
            this.lVSExpTerm.Text = "none";
            this.lVSLastCmdStatus.Text = "none";

            //init algos
            AlgoVersionSpace.init(ref self.lvVSGenSpace, ref self.lvVSSpecSpace);
            //AlgoExplanationLearning.init(ref 
        }

        private void bSendVSDirectQuery_Click(object sender, EventArgs e)
        {
            //text, tytuł, buttony, ikona, ...
            MessageBox.Show(this.tbVSRawQuery.Text);
        }
    }
}
