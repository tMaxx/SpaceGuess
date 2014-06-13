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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbVSPrologOut = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVersionSpace = new System.Windows.Forms.TabPage();
            this.lHelp2 = new System.Windows.Forms.Label();
            this.bVSReset = new System.Windows.Forms.Button();
            this.lVSLastCmdStatus = new System.Windows.Forms.Label();
            this.lvVSSpecSpace = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvVSGenSpace = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lVSExpTerm = new System.Windows.Forms.Label();
            this.lHelp1 = new System.Windows.Forms.Label();
            this.lvVSHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bVSSendQuery = new System.Windows.Forms.Button();
            this.tbVSQuery = new System.Windows.Forms.TextBox();
            this.tabVSConsole = new System.Windows.Forms.TabPage();
            this.tbVSStatusOut = new System.Windows.Forms.TextBox();
            this.tabExpLearning = new System.Windows.Forms.TabPage();
            this.bVSClearHistorySelection = new System.Windows.Forms.Button();
            this.tabVisualizer = new System.Windows.Forms.TabPage();
            this.pbViz = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabVersionSpace.SuspendLayout();
            this.tabVSConsole.SuspendLayout();
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabVersionSpace);
            this.tabControl1.Controls.Add(this.tabVSConsole);
            this.tabControl1.Controls.Add(this.tabExpLearning);
            this.tabControl1.Controls.Add(this.tabVisualizer);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 455);
            this.tabControl1.TabIndex = 3;
            // 
            // tabVersionSpace
            // 
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
            this.columnHeader3});
            this.lvVSSpecSpace.FullRowSelect = true;
            this.lvVSSpecSpace.GridLines = true;
            this.lvVSSpecSpace.Location = new System.Drawing.Point(483, 6);
            this.lvVSSpecSpace.MultiSelect = false;
            this.lvVSSpecSpace.Name = "lvVSSpecSpace";
            this.lvVSSpecSpace.Size = new System.Drawing.Size(200, 200);
            this.lvVSSpecSpace.TabIndex = 8;
            this.lvVSSpecSpace.UseCompatibleStateImageBehavior = false;
            this.lvVSSpecSpace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Przestrzeń szczegółowa";
            this.columnHeader3.Width = 191;
            // 
            // lvVSGenSpace
            // 
            this.lvVSGenSpace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvVSGenSpace.FullRowSelect = true;
            this.lvVSGenSpace.GridLines = true;
            this.lvVSGenSpace.Location = new System.Drawing.Point(277, 6);
            this.lvVSGenSpace.MultiSelect = false;
            this.lvVSGenSpace.Name = "lvVSGenSpace";
            this.lvVSGenSpace.Size = new System.Drawing.Size(200, 200);
            this.lvVSGenSpace.TabIndex = 7;
            this.lvVSGenSpace.UseCompatibleStateImageBehavior = false;
            this.lvVSGenSpace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Przestrzeń ogólna";
            this.columnHeader2.Width = 188;
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
            this.columnHeader1});
            this.lvVSHistory.FullRowSelect = true;
            this.lvVSHistory.GridLines = true;
            this.lvVSHistory.Location = new System.Drawing.Point(6, 6);
            this.lvVSHistory.MultiSelect = false;
            this.lvVSHistory.Name = "lvVSHistory";
            this.lvVSHistory.Size = new System.Drawing.Size(248, 390);
            this.lvVSHistory.TabIndex = 2;
            this.lvVSHistory.UseCompatibleStateImageBehavior = false;
            this.lvVSHistory.View = System.Windows.Forms.View.Details;
            this.lvVSHistory.SelectedIndexChanged += new System.EventHandler(this.lvVSHistory_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Historia przykładów";
            this.columnHeader1.Width = 219;
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
            // 
            // tabVSConsole
            // 
            this.tabVSConsole.Controls.Add(this.tbVSStatusOut);
            this.tabVSConsole.Controls.Add(this.tbVSPrologOut);
            this.tabVSConsole.Controls.Add(this.bSendVSRawQuery);
            this.tabVSConsole.Controls.Add(this.tbVSRawQuery);
            this.tabVSConsole.Location = new System.Drawing.Point(4, 22);
            this.tabVSConsole.Name = "tabVSConsole";
            this.tabVSConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabVSConsole.Size = new System.Drawing.Size(689, 429);
            this.tabVSConsole.TabIndex = 1;
            this.tabVSConsole.Text = "Konsola";
            this.tabVSConsole.UseVisualStyleBackColor = true;
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
            this.tabExpLearning.Location = new System.Drawing.Point(4, 22);
            this.tabExpLearning.Name = "tabExpLearning";
            this.tabExpLearning.Size = new System.Drawing.Size(689, 429);
            this.tabExpLearning.TabIndex = 2;
            this.tabExpLearning.Text = "Explanation-based Learning";
            this.tabExpLearning.UseVisualStyleBackColor = true;
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
            // SpaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 479);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SpaceForm";
            this.Text = "SpaceGuess";
            this.tabControl1.ResumeLayout(false);
            this.tabVersionSpace.ResumeLayout(false);
            this.tabVersionSpace.PerformLayout();
            this.tabVSConsole.ResumeLayout(false);
            this.tabVSConsole.PerformLayout();
            this.tabVisualizer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbViz)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSendVSRawQuery;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVersionSpace;
        private System.Windows.Forms.TabPage tabVSConsole;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lHelp1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
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
    }
}

