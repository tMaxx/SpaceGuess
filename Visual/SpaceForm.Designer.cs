namespace Visual
{
    partial class SpaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.tbVSRawQuery = new System.Windows.Forms.TextBox();
			this.bSendVSRawQuery = new System.Windows.Forms.Button();
			this.tbVSPrologOut = new System.Windows.Forms.TextBox();
			this.tcTabs = new System.Windows.Forms.TabControl();
			this.tabVersionSpace = new System.Windows.Forms.TabPage();
			this.bVSRelockSpace = new System.Windows.Forms.Button();
			this.tbVSConceptSpace = new System.Windows.Forms.TextBox();
			this.bVSClearHistorySelection = new System.Windows.Forms.Button();
			this.lHelp2 = new System.Windows.Forms.Label();
			this.bVSReset = new System.Windows.Forms.Button();
			this.lVSLastCmdStatus = new System.Windows.Forms.Label();
			this.lvVSSpecSpace = new System.Windows.Forms.ListView();
			this.colSpecific = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvVSGenSpace = new System.Windows.Forms.ListView();
			this.colGeneral = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lVSExpTerm = new System.Windows.Forms.Label();
			this.lHelp1 = new System.Windows.Forms.Label();
			this.lvVSHistory = new System.Windows.Forms.ListView();
			this.colHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bVSSendQuery = new System.Windows.Forms.Button();
			this.tbVSQuery = new System.Windows.Forms.TextBox();
			this.tabConsole = new System.Windows.Forms.TabPage();
			this.tbVSStatusOut = new System.Windows.Forms.TextBox();
			this.tabExpLearning = new System.Windows.Forms.TabPage();
			this.bELResetAll = new System.Windows.Forms.Button();
			this.tbELOutput = new System.Windows.Forms.TextBox();
			this.bELExtractRule = new System.Windows.Forms.Button();
			this.lHelp6 = new System.Windows.Forms.Label();
			this.tbELRuleInput = new System.Windows.Forms.TextBox();
			this.lHelp5 = new System.Windows.Forms.Label();
			this.bELSaveDomTheory = new System.Windows.Forms.Button();
			this.tbELDomainTheory = new System.Windows.Forms.TextBox();
			this.tabVisualizer = new System.Windows.Forms.TabPage();
			this.pbViz = new System.Windows.Forms.PictureBox();
			this.lHelp8 = new System.Windows.Forms.Label();
			this.lELStatus = new System.Windows.Forms.Label();
			this.tcTabs.SuspendLayout();
			this.tabVersionSpace.SuspendLayout();
			this.tabConsole.SuspendLayout();
			this.tabExpLearning.SuspendLayout();
			this.tabVisualizer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbViz)).BeginInit();
			this.SuspendLayout();
			// 
			// tbVSRawQuery
			// 
			this.tbVSRawQuery.Location = new System.Drawing.Point(6, 393);
			this.tbVSRawQuery.Name = "tbVSRawQuery";
			this.tbVSRawQuery.Size = new System.Drawing.Size(257, 20);
			this.tbVSRawQuery.TabIndex = 0;
			this.tbVSRawQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVSRawQuery_KeyPress);
			// 
			// bSendVSRawQuery
			// 
			this.bSendVSRawQuery.Location = new System.Drawing.Point(269, 393);
			this.bSendVSRawQuery.Name = "bSendVSRawQuery";
			this.bSendVSRawQuery.Size = new System.Drawing.Size(128, 29);
			this.bSendVSRawQuery.TabIndex = 1;
			this.bSendVSRawQuery.Text = "Send prolog query";
			this.bSendVSRawQuery.UseVisualStyleBackColor = true;
			this.bSendVSRawQuery.Click += new System.EventHandler(this.bSendVSRawQuery_Click);
			// 
			// tbVSPrologOut
			// 
			this.tbVSPrologOut.Location = new System.Drawing.Point(6, 6);
			this.tbVSPrologOut.Multiline = true;
			this.tbVSPrologOut.Name = "tbVSPrologOut";
			this.tbVSPrologOut.ReadOnly = true;
			this.tbVSPrologOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbVSPrologOut.Size = new System.Drawing.Size(391, 381);
			this.tbVSPrologOut.TabIndex = 2;
			this.tbVSPrologOut.Text = "<output prologa>";
			// 
			// tcTabs
			// 
			this.tcTabs.Controls.Add(this.tabVersionSpace);
			this.tcTabs.Controls.Add(this.tabExpLearning);
			this.tcTabs.Controls.Add(this.tabConsole);
			this.tcTabs.Controls.Add(this.tabVisualizer);
			this.tcTabs.Location = new System.Drawing.Point(12, 12);
			this.tcTabs.Name = "tcTabs";
			this.tcTabs.SelectedIndex = 0;
			this.tcTabs.Size = new System.Drawing.Size(697, 455);
			this.tcTabs.TabIndex = 3;
			// 
			// tabVersionSpace
			// 
			this.tabVersionSpace.Controls.Add(this.bVSRelockSpace);
			this.tabVersionSpace.Controls.Add(this.tbVSConceptSpace);
			this.tabVersionSpace.Controls.Add(this.bVSClearHistorySelection);
			this.tabVersionSpace.Controls.Add(this.lHelp2);
			this.tabVersionSpace.Controls.Add(this.bVSReset);
			this.tabVersionSpace.Controls.Add(this.lVSLastCmdStatus);
			this.tabVersionSpace.Controls.Add(this.lvVSSpecSpace);
			this.tabVersionSpace.Controls.Add(this.lvVSGenSpace);
			this.tabVersionSpace.Controls.Add(this.lVSExpTerm);
			this.tabVersionSpace.Controls.Add(this.lHelp1);
			this.tabVersionSpace.Controls.Add(this.lvVSHistory);
			this.tabVersionSpace.Controls.Add(this.bVSSendQuery);
			this.tabVersionSpace.Controls.Add(this.tbVSQuery);
			this.tabVersionSpace.Location = new System.Drawing.Point(4, 22);
			this.tabVersionSpace.Name = "tabVersionSpace";
			this.tabVersionSpace.Padding = new System.Windows.Forms.Padding(3);
			this.tabVersionSpace.Size = new System.Drawing.Size(689, 429);
			this.tabVersionSpace.TabIndex = 0;
			this.tabVersionSpace.Text = "Version Space Search";
			this.tabVersionSpace.UseVisualStyleBackColor = true;
			// 
			// bVSRelockSpace
			// 
			this.bVSRelockSpace.Location = new System.Drawing.Point(6, 98);
			this.bVSRelockSpace.Name = "bVSRelockSpace";
			this.bVSRelockSpace.Size = new System.Drawing.Size(124, 23);
			this.bVSRelockSpace.TabIndex = 14;
			this.bVSRelockSpace.Text = "Zablokuj/odblokuj";
			this.bVSRelockSpace.UseVisualStyleBackColor = true;
			this.bVSRelockSpace.Click += new System.EventHandler(this.bVSRelockSpace_Click);
			// 
			// tbVSConceptSpace
			// 
			this.tbVSConceptSpace.Location = new System.Drawing.Point(6, 6);
			this.tbVSConceptSpace.Multiline = true;
			this.tbVSConceptSpace.Name = "tbVSConceptSpace";
			this.tbVSConceptSpace.ReadOnly = true;
			this.tbVSConceptSpace.Size = new System.Drawing.Size(248, 86);
			this.tbVSConceptSpace.TabIndex = 13;
			this.tbVSConceptSpace.Text = "<wektory przestrzeni konceptowej>";
			// 
			// bVSClearHistorySelection
			// 
			this.bVSClearHistorySelection.Location = new System.Drawing.Point(7, 402);
			this.bVSClearHistorySelection.Name = "bVSClearHistorySelection";
			this.bVSClearHistorySelection.Size = new System.Drawing.Size(125, 20);
			this.bVSClearHistorySelection.TabIndex = 12;
			this.bVSClearHistorySelection.Text = "Wyczyść zaznaczenie";
			this.bVSClearHistorySelection.UseVisualStyleBackColor = true;
			this.bVSClearHistorySelection.Click += new System.EventHandler(this.bVSClearHistorySelection_Click);
			// 
			// lHelp2
			// 
			this.lHelp2.AutoSize = true;
			this.lHelp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHelp2.Location = new System.Drawing.Point(274, 251);
			this.lHelp2.Name = "lHelp2";
			this.lHelp2.Size = new System.Drawing.Size(111, 13);
			this.lHelp2.TabIndex = 11;
			this.lHelp2.Text = "Status wywołania:";
			// 
			// bVSReset
			// 
			this.bVSReset.Location = new System.Drawing.Point(608, 400);
			this.bVSReset.Name = "bVSReset";
			this.bVSReset.Size = new System.Drawing.Size(75, 23);
			this.bVSReset.TabIndex = 10;
			this.bVSReset.Text = "Reset";
			this.bVSReset.UseVisualStyleBackColor = true;
			this.bVSReset.Click += new System.EventHandler(this.bVSReset_Click);
			// 
			// lVSLastCmdStatus
			// 
			this.lVSLastCmdStatus.AutoSize = true;
			this.lVSLastCmdStatus.Location = new System.Drawing.Point(391, 251);
			this.lVSLastCmdStatus.Name = "lVSLastCmdStatus";
			this.lVSLastCmdStatus.Size = new System.Drawing.Size(101, 13);
			this.lVSLastCmdStatus.TabIndex = 9;
			this.lVSLastCmdStatus.Text = "<status wywołania>";
			// 
			// lvVSSpecSpace
			// 
			this.lvVSSpecSpace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSpecific});
			this.lvVSSpecSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvVSSpecSpace.FullRowSelect = true;
			this.lvVSSpecSpace.GridLines = true;
			this.lvVSSpecSpace.HideSelection = false;
			this.lvVSSpecSpace.Location = new System.Drawing.Point(483, 6);
			this.lvVSSpecSpace.MultiSelect = false;
			this.lvVSSpecSpace.Name = "lvVSSpecSpace";
			this.lvVSSpecSpace.Size = new System.Drawing.Size(200, 200);
			this.lvVSSpecSpace.TabIndex = 8;
			this.lvVSSpecSpace.UseCompatibleStateImageBehavior = false;
			this.lvVSSpecSpace.View = System.Windows.Forms.View.Details;
			// 
			// colSpecific
			// 
			this.colSpecific.Text = "Przestrzeń szczegółowa";
			this.colSpecific.Width = 191;
			// 
			// lvVSGenSpace
			// 
			this.lvVSGenSpace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGeneral});
			this.lvVSGenSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvVSGenSpace.FullRowSelect = true;
			this.lvVSGenSpace.GridLines = true;
			this.lvVSGenSpace.HideSelection = false;
			this.lvVSGenSpace.Location = new System.Drawing.Point(277, 6);
			this.lvVSGenSpace.MultiSelect = false;
			this.lvVSGenSpace.Name = "lvVSGenSpace";
			this.lvVSGenSpace.Size = new System.Drawing.Size(200, 200);
			this.lvVSGenSpace.TabIndex = 7;
			this.lvVSGenSpace.UseCompatibleStateImageBehavior = false;
			this.lvVSGenSpace.View = System.Windows.Forms.View.Details;
			// 
			// colGeneral
			// 
			this.colGeneral.Text = "Przestrzeń ogólna";
			this.colGeneral.Width = 188;
			// 
			// lVSExpTerm
			// 
			this.lVSExpTerm.AutoSize = true;
			this.lVSExpTerm.Location = new System.Drawing.Point(418, 209);
			this.lVSExpTerm.Name = "lVSExpTerm";
			this.lVSExpTerm.Size = new System.Drawing.Size(219, 13);
			this.lVSExpTerm.TabIndex = 6;
			this.lVSExpTerm.Text = "<przewidywany wywód (unknown, example)>";
			// 
			// lHelp1
			// 
			this.lHelp1.AutoSize = true;
			this.lHelp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHelp1.Location = new System.Drawing.Point(274, 209);
			this.lHelp1.Name = "lHelp1";
			this.lHelp1.Size = new System.Drawing.Size(138, 13);
			this.lHelp1.TabIndex = 5;
			this.lHelp1.Text = "Przewidywany element:";
			// 
			// lvVSHistory
			// 
			this.lvVSHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colHistory});
			this.lvVSHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lvVSHistory.FullRowSelect = true;
			this.lvVSHistory.GridLines = true;
			this.lvVSHistory.HideSelection = false;
			this.lvVSHistory.Location = new System.Drawing.Point(6, 152);
			this.lvVSHistory.MultiSelect = false;
			this.lvVSHistory.Name = "lvVSHistory";
			this.lvVSHistory.Size = new System.Drawing.Size(248, 244);
			this.lvVSHistory.TabIndex = 2;
			this.lvVSHistory.UseCompatibleStateImageBehavior = false;
			this.lvVSHistory.View = System.Windows.Forms.View.Details;
			this.lvVSHistory.SelectedIndexChanged += new System.EventHandler(this.lvVSHistory_SelectedIndexChanged);
			// 
			// colHistory
			// 
			this.colHistory.Text = "Historia przykładów";
			this.colHistory.Width = 219;
			// 
			// bVSSendQuery
			// 
			this.bVSSendQuery.Location = new System.Drawing.Point(394, 299);
			this.bVSSendQuery.Name = "bVSSendQuery";
			this.bVSSendQuery.Size = new System.Drawing.Size(209, 34);
			this.bVSSendQuery.TabIndex = 1;
			this.bVSSendQuery.Text = "Dodaj przykład";
			this.bVSSendQuery.UseVisualStyleBackColor = true;
			this.bVSSendQuery.Click += new System.EventHandler(this.bVSSendQuery_Click);
			// 
			// tbVSQuery
			// 
			this.tbVSQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbVSQuery.Location = new System.Drawing.Point(394, 267);
			this.tbVSQuery.Name = "tbVSQuery";
			this.tbVSQuery.Size = new System.Drawing.Size(209, 26);
			this.tbVSQuery.TabIndex = 0;
			this.tbVSQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbVSQuery_KeyPress);
			// 
			// tabConsole
			// 
			this.tabConsole.Controls.Add(this.tbVSStatusOut);
			this.tabConsole.Controls.Add(this.tbVSPrologOut);
			this.tabConsole.Controls.Add(this.bSendVSRawQuery);
			this.tabConsole.Controls.Add(this.tbVSRawQuery);
			this.tabConsole.Location = new System.Drawing.Point(4, 22);
			this.tabConsole.Name = "tabConsole";
			this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
			this.tabConsole.Size = new System.Drawing.Size(689, 429);
			this.tabConsole.TabIndex = 1;
			this.tabConsole.Text = "Konsola";
			this.tabConsole.UseVisualStyleBackColor = true;
			// 
			// tbVSStatusOut
			// 
			this.tbVSStatusOut.Location = new System.Drawing.Point(403, 3);
			this.tbVSStatusOut.Multiline = true;
			this.tbVSStatusOut.Name = "tbVSStatusOut";
			this.tbVSStatusOut.ReadOnly = true;
			this.tbVSStatusOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbVSStatusOut.Size = new System.Drawing.Size(280, 420);
			this.tbVSStatusOut.TabIndex = 3;
			this.tbVSStatusOut.Text = "<status programu>";
			// 
			// tabExpLearning
			// 
			this.tabExpLearning.Controls.Add(this.lHelp8);
			this.tabExpLearning.Controls.Add(this.lELStatus);
			this.tabExpLearning.Controls.Add(this.bELResetAll);
			this.tabExpLearning.Controls.Add(this.tbELOutput);
			this.tabExpLearning.Controls.Add(this.bELExtractRule);
			this.tabExpLearning.Controls.Add(this.lHelp6);
			this.tabExpLearning.Controls.Add(this.tbELRuleInput);
			this.tabExpLearning.Controls.Add(this.lHelp5);
			this.tabExpLearning.Controls.Add(this.bELSaveDomTheory);
			this.tabExpLearning.Controls.Add(this.tbELDomainTheory);
			this.tabExpLearning.Location = new System.Drawing.Point(4, 22);
			this.tabExpLearning.Name = "tabExpLearning";
			this.tabExpLearning.Size = new System.Drawing.Size(689, 429);
			this.tabExpLearning.TabIndex = 2;
			this.tabExpLearning.Text = "Explanation-based Learning";
			this.tabExpLearning.UseVisualStyleBackColor = true;
			// 
			// bELResetAll
			// 
			this.bELResetAll.Location = new System.Drawing.Point(592, 405);
			this.bELResetAll.Name = "bELResetAll";
			this.bELResetAll.Size = new System.Drawing.Size(96, 23);
			this.bELResetAll.TabIndex = 7;
			this.bELResetAll.Text = "Reset";
			this.bELResetAll.UseVisualStyleBackColor = true;
			this.bELResetAll.Click += new System.EventHandler(this.bELResetAll_Click);
			// 
			// tbELOutput
			// 
			this.tbELOutput.Location = new System.Drawing.Point(251, 122);
			this.tbELOutput.Multiline = true;
			this.tbELOutput.Name = "tbELOutput";
			this.tbELOutput.ReadOnly = true;
			this.tbELOutput.Size = new System.Drawing.Size(435, 275);
			this.tbELOutput.TabIndex = 6;
			// 
			// bELExtractRule
			// 
			this.bELExtractRule.Location = new System.Drawing.Point(354, 54);
			this.bELExtractRule.Name = "bELExtractRule";
			this.bELExtractRule.Size = new System.Drawing.Size(209, 27);
			this.bELExtractRule.TabIndex = 5;
			this.bELExtractRule.Text = "Wyprowadź regułę";
			this.bELExtractRule.UseVisualStyleBackColor = true;
			this.bELExtractRule.Click += new System.EventHandler(this.bELExtractRule_Click);
			// 
			// lHelp6
			// 
			this.lHelp6.AutoSize = true;
			this.lHelp6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHelp6.Location = new System.Drawing.Point(248, 28);
			this.lHelp6.Name = "lHelp6";
			this.lHelp6.Size = new System.Drawing.Size(100, 16);
			this.lHelp6.TabIndex = 4;
			this.lHelp6.Text = "Podaj obiekt:";
			// 
			// tbELRuleInput
			// 
			this.tbELRuleInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbELRuleInput.Location = new System.Drawing.Point(354, 22);
			this.tbELRuleInput.Name = "tbELRuleInput";
			this.tbELRuleInput.Size = new System.Drawing.Size(209, 26);
			this.tbELRuleInput.TabIndex = 3;
			// 
			// lHelp5
			// 
			this.lHelp5.AutoSize = true;
			this.lHelp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHelp5.Location = new System.Drawing.Point(0, 3);
			this.lHelp5.Name = "lHelp5";
			this.lHelp5.Size = new System.Drawing.Size(127, 16);
			this.lHelp5.TabIndex = 2;
			this.lHelp5.Text = "Teoria dziedziny:";
			// 
			// bELSaveDomTheory
			// 
			this.bELSaveDomTheory.Location = new System.Drawing.Point(3, 403);
			this.bELSaveDomTheory.Name = "bELSaveDomTheory";
			this.bELSaveDomTheory.Size = new System.Drawing.Size(141, 23);
			this.bELSaveDomTheory.TabIndex = 1;
			this.bELSaveDomTheory.Text = "Zablokuj/odblokuj";
			this.bELSaveDomTheory.UseVisualStyleBackColor = true;
			this.bELSaveDomTheory.Click += new System.EventHandler(this.bELSaveDomTheory_Click);
			// 
			// tbELDomainTheory
			// 
			this.tbELDomainTheory.Location = new System.Drawing.Point(3, 22);
			this.tbELDomainTheory.Multiline = true;
			this.tbELDomainTheory.Name = "tbELDomainTheory";
			this.tbELDomainTheory.ReadOnly = true;
			this.tbELDomainTheory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbELDomainTheory.Size = new System.Drawing.Size(210, 375);
			this.tbELDomainTheory.TabIndex = 0;
			// 
			// tabVisualizer
			// 
			this.tabVisualizer.Controls.Add(this.pbViz);
			this.tabVisualizer.Location = new System.Drawing.Point(4, 22);
			this.tabVisualizer.Name = "tabVisualizer";
			this.tabVisualizer.Size = new System.Drawing.Size(689, 429);
			this.tabVisualizer.TabIndex = 3;
			this.tabVisualizer.Text = "Wizualizacje";
			this.tabVisualizer.UseVisualStyleBackColor = true;
			// 
			// pbViz
			// 
			this.pbViz.Location = new System.Drawing.Point(3, 3);
			this.pbViz.Name = "pbViz";
			this.pbViz.Size = new System.Drawing.Size(685, 425);
			this.pbViz.TabIndex = 0;
			this.pbViz.TabStop = false;
			this.pbViz.Paint += new System.Windows.Forms.PaintEventHandler(this.pbViz_Paint);
			// 
			// lHelp8
			// 
			this.lHelp8.AutoSize = true;
			this.lHelp8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lHelp8.Location = new System.Drawing.Point(248, 84);
			this.lHelp8.Name = "lHelp8";
			this.lHelp8.Size = new System.Drawing.Size(111, 13);
			this.lHelp8.TabIndex = 13;
			this.lHelp8.Text = "Status wywołania:";
			// 
			// lELStatus
			// 
			this.lELStatus.AutoSize = true;
			this.lELStatus.Location = new System.Drawing.Point(365, 84);
			this.lELStatus.Name = "lELStatus";
			this.lELStatus.Size = new System.Drawing.Size(101, 13);
			this.lELStatus.TabIndex = 12;
			this.lELStatus.Text = "<status wywołania>";
			// 
			// SpaceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 479);
			this.Controls.Add(this.tcTabs);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "SpaceForm";
			this.Text = "SpaceGuess";
			this.tcTabs.ResumeLayout(false);
			this.tabVersionSpace.ResumeLayout(false);
			this.tabVersionSpace.PerformLayout();
			this.tabConsole.ResumeLayout(false);
			this.tabConsole.PerformLayout();
			this.tabExpLearning.ResumeLayout(false);
			this.tabExpLearning.PerformLayout();
			this.tabVisualizer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbViz)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button bSendVSRawQuery;
		public System.Windows.Forms.TabControl tcTabs;
        private System.Windows.Forms.TabPage tabVersionSpace;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.ColumnHeader colSpecific;
        private System.Windows.Forms.ColumnHeader colGeneral;
        private System.Windows.Forms.Label lHelp1;
        private System.Windows.Forms.ColumnHeader colHistory;
        public System.Windows.Forms.ListView lvVSHistory;
        public System.Windows.Forms.ListView lvVSSpecSpace;
        public System.Windows.Forms.ListView lvVSGenSpace;
        public System.Windows.Forms.TextBox tbVSRawQuery;
        public System.Windows.Forms.TextBox tbVSPrologOut;
        public System.Windows.Forms.Button bVSSendQuery;
        public System.Windows.Forms.TextBox tbVSQuery;
        public System.Windows.Forms.Label lVSLastCmdStatus;
        public System.Windows.Forms.Label lVSExpTerm;
        public System.Windows.Forms.TextBox tbVSStatusOut;
        private System.Windows.Forms.TabPage tabExpLearning;
        private System.Windows.Forms.Button bVSReset;
        private System.Windows.Forms.Label lHelp2;
        private System.Windows.Forms.Button bVSClearHistorySelection;
        private System.Windows.Forms.TabPage tabVisualizer;
        private System.Windows.Forms.PictureBox pbViz;
		private System.Windows.Forms.Button bVSRelockSpace;
		public System.Windows.Forms.TextBox tbVSConceptSpace;
		private System.Windows.Forms.Button bELExtractRule;
		private System.Windows.Forms.Label lHelp6;
		public System.Windows.Forms.TextBox tbELRuleInput;
		private System.Windows.Forms.Label lHelp5;
		private System.Windows.Forms.Button bELSaveDomTheory;
		private System.Windows.Forms.Button bELResetAll;
		public System.Windows.Forms.TextBox tbELDomainTheory;
		public System.Windows.Forms.TextBox tbELOutput;
		private System.Windows.Forms.Label lHelp8;
		public System.Windows.Forms.Label lELStatus;
    }
}

