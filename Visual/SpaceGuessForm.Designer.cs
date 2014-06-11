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
            this.tbVSDirectQuery = new System.Windows.Forms.TextBox();
            this.bSendVSDirectQuery = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tbVSPrologOut = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lVSLastCmdStatus = new System.Windows.Forms.Label();
            this.lvSpecSpace = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvGenSpace = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lVSExpTerm = new System.Windows.Forms.Label();
            this.lHelp1 = new System.Windows.Forms.Label();
            this.lvExamplesHist = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bVSSendTermInput = new System.Windows.Forms.Button();
            this.tVSTermInput = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbVSStatusOut = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbVSDirectQuery
            // 
            this.tbVSDirectQuery.Location = new System.Drawing.Point(6, 362);
            this.tbVSDirectQuery.Name = "tbVSDirectQuery";
            this.tbVSDirectQuery.Size = new System.Drawing.Size(205, 20);
            this.tbVSDirectQuery.TabIndex = 0;
            // 
            // bSendVSDirectQuery
            // 
            this.bSendVSDirectQuery.Location = new System.Drawing.Point(217, 362);
            this.bSendVSDirectQuery.Name = "bSendVSDirectQuery";
            this.bSendVSDirectQuery.Size = new System.Drawing.Size(97, 20);
            this.bSendVSDirectQuery.TabIndex = 1;
            this.bSendVSDirectQuery.Text = "Send query";
            this.bSendVSDirectQuery.UseVisualStyleBackColor = true;
            this.bSendVSDirectQuery.Click += new System.EventHandler(this.bSendVSDirectQuery_Click);
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
            this.tabPage1.Controls.Add(this.lvSpecSpace);
            this.tabPage1.Controls.Add(this.lvGenSpace);
            this.tabPage1.Controls.Add(this.lVSExpTerm);
            this.tabPage1.Controls.Add(this.lHelp1);
            this.tabPage1.Controls.Add(this.lvExamplesHist);
            this.tabPage1.Controls.Add(this.bVSSendTermInput);
            this.tabPage1.Controls.Add(this.tVSTermInput);
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
            // lvSpecSpace
            // 
            this.lvSpecSpace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lvSpecSpace.FullRowSelect = true;
            this.lvSpecSpace.GridLines = true;
            this.lvSpecSpace.Location = new System.Drawing.Point(381, 6);
            this.lvSpecSpace.MultiSelect = false;
            this.lvSpecSpace.Name = "lvSpecSpace";
            this.lvSpecSpace.Size = new System.Drawing.Size(154, 191);
            this.lvSpecSpace.TabIndex = 8;
            this.lvSpecSpace.UseCompatibleStateImageBehavior = false;
            this.lvSpecSpace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Specific space";
            this.columnHeader3.Width = 138;
            // 
            // lvGenSpace
            // 
            this.lvGenSpace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvGenSpace.FullRowSelect = true;
            this.lvGenSpace.GridLines = true;
            this.lvGenSpace.Location = new System.Drawing.Point(221, 6);
            this.lvGenSpace.MultiSelect = false;
            this.lvGenSpace.Name = "lvGenSpace";
            this.lvGenSpace.Size = new System.Drawing.Size(154, 191);
            this.lvGenSpace.TabIndex = 7;
            this.lvGenSpace.UseCompatibleStateImageBehavior = false;
            this.lvGenSpace.View = System.Windows.Forms.View.Details;
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
            // bVSSendTermInput
            // 
            this.bVSSendTermInput.Location = new System.Drawing.Point(175, 300);
            this.bVSSendTermInput.Name = "bVSSendTermInput";
            this.bVSSendTermInput.Size = new System.Drawing.Size(166, 34);
            this.bVSSendTermInput.TabIndex = 1;
            this.bVSSendTermInput.Text = "Wyślij";
            this.bVSSendTermInput.UseVisualStyleBackColor = true;
            // 
            // tVSTermInput
            // 
            this.tVSTermInput.Location = new System.Drawing.Point(175, 274);
            this.tVSTermInput.Name = "tVSTermInput";
            this.tVSTermInput.Size = new System.Drawing.Size(167, 20);
            this.tVSTermInput.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbVSStatusOut);
            this.tabPage2.Controls.Add(this.tbVSPrologOut);
            this.tabPage2.Controls.Add(this.bSendVSDirectQuery);
            this.tabPage2.Controls.Add(this.tbVSDirectQuery);
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

        private System.Windows.Forms.TextBox tbVSDirectQuery;
        private System.Windows.Forms.Button bSendVSDirectQuery;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox tbVSPrologOut;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bVSSendTermInput;
        private System.Windows.Forms.TextBox tVSTermInput;
        private System.Windows.Forms.Label lVSLastCmdStatus;
        private System.Windows.Forms.ListView lvSpecSpace;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvGenSpace;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lVSExpTerm;
        private System.Windows.Forms.Label lHelp1;
        private System.Windows.Forms.ListView lvExamplesHist;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox tbVSStatusOut;
    }
}

