using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual.Class;

namespace Visual
{
	public partial class SpaceForm : Form
	{
		public static SpaceForm self = null;

		public SpaceForm()
		{
			if (self == null)
				self = this;
			else
				throw new Exception("Nope");

			//import z this.Designer.cs
			InitializeComponent();

			//init algos
			VSAlgo.init();
			VSAlgo.resetAll();
			ELAlgo.init();
			ELAlgo.resetAll();
		}

		private void bSendVSRawQuery_Click(object sender, EventArgs e)
		{
			VSAlgo.processRawInput(this.tbVSRawQuery.Text);
		}

		private void bVSSendQuery_Click(object sender, EventArgs e)
		{
			VSAlgo.processInput(this.tbVSQuery.Text);
		}

		private void bVSReset_Click(object sender, EventArgs e)
		{
			VSAlgo.resetAll();
		}

		private int selected = -1;
		private void lvVSHistory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.lvVSHistory.Items.Count == 0)
				return;

			foreach (int i in this.lvVSHistory.SelectedIndices)
			{
				selected = i;
				//only first, please
				break;
			}

			if (this.lvVSHistory.SelectedItems.Count == 0)
				selected = this.lvVSHistory.Items.Count - 1;

			VSAlgo.selectSpaceLists(selected);
		}

		private void tbVSRawQuery_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Return))
				this.bSendVSRawQuery_Click(null, null);
		}

		private void bVSClearHistorySelection_Click(object sender, EventArgs e)
		{
			this.lvVSHistory.SelectedIndices.Clear();
		}

		private void pbViz_Paint(object sender, PaintEventArgs e)
		{
			//temporary
			Pen pen = new Pen(Color.FromArgb(255, 0, 0, 255), 8);
			pen.StartCap = LineCap.ArrowAnchor;
			pen.EndCap = LineCap.RoundAnchor;
			e.Graphics.DrawLine(pen, 20, 175, 300, 175);
		}

		private void bVSRelockSpace_Click(object sender, EventArgs e)
		{
			this.tbVSConceptSpace.Enabled = !this.tbVSConceptSpace.Enabled;
			if (this.tbVSConceptSpace.Enabled == false)
				MessageBox.Show("Po zmianie definicji przestrzeni konceptualnej "
					+ "wymagany jest reset algorytmu za pomocą przycisku w prawej dolnej części okna",
					"Wymagany reset algorytmu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void tbVSQuery_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == Convert.ToChar(Keys.Return))
				this.bVSSendQuery_Click(null, null);
		}

		private void bELResetAll_Click(object sender, EventArgs e)
		{
			ELAlgo.resetAll();
		}

		private void bELExtractRule_Click(object sender, EventArgs e)
		{
			ELAlgo.execQuery(SpaceForm.self.tbELRuleInput.Text);
		}

		private void bELSaveDomTheory_Click(object sender, EventArgs e)
		{
			this.tbELDomainTheory.Enabled = !this.tbELDomainTheory.Enabled;
			//if (this.tbELDomainTheory.Enabled == false)
				//MessageBox.Show("Po zmianie definicji przestrzeni konceptualnej "
					//+ "wymagany jest reset algorytmu za pomocą przycisku w prawej dolnej części okna",
					//"Wymagany reset algorytmu", MessageBoxButtons.OK, MessageBoxIcon.Warning);

		}

	}
}
