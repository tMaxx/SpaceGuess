namespace Visual
{
    partial class SpaceGuessForm
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lVSLastCmdStatus = new System.Windows.Forms.Label();
            this.lvVSSpecSpace = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvVSGenSpace = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lVSExpTerm = new System.Windows.Forms.Label();
            this.lHelp1 = new System.Windows.Forms.Label();
            this.lvExamplesHist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bVSSendQuery = new System.Windows.Forms.Button();
            this.tVSQuery = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbVSStatusOut = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVSRawQuery
            // 
            this.tbVSRawQuery.Location = new System.Drawing.Point(6, 362);
            this.tbVSRawQuery.Name = "tbVSRawQuery";
            this.tbVSRawQuery.Size = new System.Drawing.Size(205, 20);
            this.tbVSRawQuery.TabIndex = 0;
            // 
            // bSendVSRawQuery
            // 
            this.bSendVSRawQuery.Location = new System.Drawing.Point(217, 362);
            this.bSendVSRawQuery.Name = "bSendVSRawQuery";
            this.bSendVSRawQuery.Size = new System.Drawing.Size(97, 20);
            this.bSendVSRawQuery.TabIndex = 1;
            this.bSendVSRawQuery.Text = "Send query";
            this.bSendVSRawQuery.UseVisualStyleBackColor = true;
            this.bSendVSRawQuery.Click += new System.EventHandler(this.bSendVSDirectQuery_Click);
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
            this.tbVSPrologOut.Size = new System.Drawing.Size(308, 350);
            this.tbVSPrologOut.TabIndex = 2;
            this.tbVSPrologOut.Text = "<output prologa>";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 414);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lVSLastCmdStatus);
            this.tabPage1.Controls.Add(this.lvVSSpecSpace);
            this.tabPage1.Controls.Add(this.lvVSGenSpace);
            this.tabPage1.Controls.Add(this.lVSExpTerm);
            this.tabPage1.Controls.Add(this.lHelp1);
            this.tabPage1.Controls.Add(this.lvExamplesHist);
            this.tabPage1.Controls.Add(this.bVSSendQuery);
            this.tabPage1.Controls.Add(this.tVSQuery);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(541, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Version Space Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lVSLastCmdStatus
            // 
            this.lVSLastCmdStatus.AutoSize = true;
            this.lVSLastCmdStatus.Location = new System.Drawing.Point(12, 237);
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
            this.lvVSSpecSpace.Location = new System.Drawing.Point(381, 6);
            this.lvVSSpecSpace.MultiSelect = false;
            this.lvVSSpecSpace.Name = "lvVSSpecSpace";
            this.lvVSSpecSpace.Size = new System.Drawing.Size(154, 191);
            this.lvVSSpecSpace.TabIndex = 8;
            this.lvVSSpecSpace.UseCompatibleStateImageBehavior = false;
            this.lvVSSpecSpace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Specific space";
            this.columnHeader3.Width = 138;
            // 
            // lvVSGenSpace
            // 
            this.lvVSGenSpace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvVSGenSpace.FullRowSelect = true;
            this.lvVSGenSpace.GridLines = true;
            this.lvVSGenSpace.Location = new System.Drawing.Point(221, 6);
            this.lvVSGenSpace.MultiSelect = false;
            this.lvVSGenSpace.Name = "lvVSGenSpace";
            this.lvVSGenSpace.Size = new System.Drawing.Size(154, 191);
            this.lvVSGenSpace.TabIndex = 7;
            this.lvVSGenSpace.UseCompatibleStateImageBehavior = false;
            this.lvVSGenSpace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "General space";
            this.columnHeader2.Width = 129;
            // 
            // lVSExpTerm
            // 
            this.lVSExpTerm.AutoSize = true;
            this.lVSExpTerm.Location = new System.Drawing.Point(86, 204);
            this.lVSExpTerm.Name = "lVSExpTerm";
            this.lVSExpTerm.Size = new System.Drawing.Size(219, 13);
            this.lVSExpTerm.TabIndex = 6;
            this.lVSExpTerm.Text = "<przewidywany wywód (unknown, example)>";
            // 
            // lHelp1
            // 
            this.lHelp1.AutoSize = true;
            this.lHelp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lHelp1.Location = new System.Drawing.Point(7, 204);
            this.lHelp1.Name = "lHelp1";
            this.lHelp1.Size = new System.Drawing.Size(73, 13);
            this.lHelp1.TabIndex = 5;
            this.lHelp1.Text = "Probably is:";
            // 
            // lvExamplesHist
            // 
            this.lvExamplesHist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvExamplesHist.FullRowSelect = true;
            this.lvExamplesHist.GridLines = true;
            this.lvExamplesHist.Location = new System.Drawing.Point(6, 6);
            this.lvExamplesHist.MultiSelect = false;
            this.lvExamplesHist.Name = "lvExamplesHist";
            this.lvExamplesHist.Size = new System.Drawing.Size(154, 191);
            this.lvExamplesHist.TabIndex = 2;
            this.lvExamplesHist.UseCompatibleStateImageBehavior = false;
            this.lvExamplesHist.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Examples history";
            this.columnHeader1.Width = 131;
            // 
            // bVSSendQuery
            // 
            this.bVSSendQuery.Location = new System.Drawing.Point(175, 300);
            this.bVSSendQuery.Name = "bVSSendQuery";
            this.bVSSendQuery.Size = new System.Drawing.Size(166, 34);
            this.bVSSendQuery.TabIndex = 1;
            this.bVSSendQuery.Text = "Wyślij";
            this.bVSSendQuery.UseVisualStyleBackColor = true;
            // 
            // tVSQuery
            // 
            this.tVSQuery.Location = new System.Drawing.Point(175, 274);
            this.tVSQuery.Name = "tVSQuery";
            this.tVSQuery.Size = new System.Drawing.Size(167, 20);
            this.tVSQuery.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbVSStatusOut);
            this.tabPage2.Controls.Add(this.tbVSPrologOut);
            this.tabPage2.Controls.Add(this.bSendVSRawQuery);
            this.tabPage2.Controls.Add(this.tbVSRawQuery);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(541, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VS Console";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbVSStatusOut
            // 
            this.tbVSStatusOut.Location = new System.Drawing.Point(320, 6);
            this.tbVSStatusOut.Multiline = true;
            this.tbVSStatusOut.Name = "tbVSStatusOut";
            this.tbVSStatusOut.ReadOnly = true;
            this.tbVSStatusOut.Size = new System.Drawing.Size(215, 376);
            this.tbVSStatusOut.TabIndex = 3;
            this.tbVSStatusOut.Text = "<status programu>";
            // 
            // SpaceGuessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 438);
            this.Controls.Add(this.tabControl1);
            this.Name = "SpaceGuessForm";
            this.Text = "SpaceGuess";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSendVSRawQuery;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lHelp1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ListView lvExamplesHist;
        public System.Windows.Forms.ListView lvVSSpecSpace;
        public System.Windows.Forms.ListView lvVSGenSpace;
        public System.Windows.Forms.TextBox tbVSRawQuery;
        public System.Windows.Forms.TextBox tbVSPrologOut;
        public System.Windows.Forms.Button bVSSendQuery;
        public System.Windows.Forms.TextBox tVSQuery;
        public System.Windows.Forms.Label lVSLastCmdStatus;
        public System.Windows.Forms.Label lVSExpTerm;
        public System.Windows.Forms.TextBox tbVSStatusOut;
    }
}

