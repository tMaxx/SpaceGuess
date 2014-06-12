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

            //init algos
            AlgoVersionSpace.init();
            AlgoVersionSpace.resetAll();
            //AlgoExplanationLearning.init();
        }

        private void bSendVSDirectQuery_Click(object sender, EventArgs e)
        {
            AlgoVersionSpace.processRawInput(this.tbVSRawQuery.Text);
        }

        private void bVSSendQuery_Click(object sender, EventArgs e)
        {
            AlgoVersionSpace.processInput(this.tbVSQuery.Text);
        }

        private void bVSReset_Click(object sender, EventArgs e)
        {
            AlgoVersionSpace.resetAll();
        }

        private void lvVSHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indexes = this.lvVSHistory.SelectedIndices;

            foreach (int i in indexes)
            {
                AlgoVersionSpace.selectIndexHistory(i);
                break;
            }
        }
    }
}
