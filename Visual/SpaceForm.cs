﻿using System;
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
			try
			{
				ELAlgo.init();
				ELAlgo.resetAll();
			}
			catch (Exception e)
			{
				MessageBox.Show("Nie można zainicjalizować modułu SWI-Prolog. Algorytm EBL będzie niedostępny."
					+ Environment.NewLine + Environment.NewLine + "Szczegóły: " + e.ToString(),
					"Błąd inicjalizacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
				ELAlgo.logApp("Błąd inicjalizacji, algorytm będzie niedostępny");
				SpaceForm.self.tcTabs.TabPages.Remove(SpaceForm.self.tabExpLearning);
			}

			SpaceForm.Bump();
		}
		~SpaceForm()
		{
			ELAlgo.finish();
		}

		public static void Bump()
		{
			self.Refresh();
		}

		private void bSendVSRawQuery_Click(object sender, EventArgs e)
		{
			VSAlgo.processRawInput(this.tbVSRawQuery.Text);
		}

		private void bVSSendQuery_Click(object sender, EventArgs e)
		{
			if (this.tbVSConceptSpace.ReadOnly)
				VSAlgo.processInput(this.tbVSQuery.Text);
			else
				this.lVSLastCmdStatus.Text = "najpierw zablokuj definicję przestrzeni konceptowej";
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

		private void bVSRelockSpace_Click(object sender, EventArgs e)
		{
			this.tbVSConceptSpace.ReadOnly = !this.tbVSConceptSpace.ReadOnly;
			if (this.tbVSConceptSpace.ReadOnly == true)
				MessageBox.Show("Po zmianie definicji przestrzeni konceptualnej "
					+ "wymagany jest reset algorytmu za pomocą przycisku w prawej dolnej części okna",
					"Wymagany reset algorytmu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			this.tbELDomainTheory.ReadOnly = !this.tbELDomainTheory.ReadOnly;
		}

		private void bELSaveFactToDT_Click(object sender, EventArgs e)
		{
			ELAlgo.addDerivedFact();
		}

	}
}
