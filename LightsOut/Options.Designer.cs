namespace LightsOut
{
    partial class Options
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
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.colTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.easyRB = new System.Windows.Forms.RadioButton();
            this.mediumRB = new System.Windows.Forms.RadioButton();
            this.hardRB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(209, 10);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(209, 36);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // rowTextBox
            // 
            this.rowTextBox.Location = new System.Drawing.Point(94, 12);
            this.rowTextBox.MaxLength = 2;
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(97, 20);
            this.rowTextBox.TabIndex = 6;
            // 
            // colTextBox
            // 
            this.colTextBox.Location = new System.Drawing.Point(94, 38);
            this.colTextBox.MaxLength = 2;
            this.colTextBox.Name = "colTextBox";
            this.colTextBox.Size = new System.Drawing.Size(97, 20);
            this.colTextBox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Rows (10 - 30)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cols (10 - 50)";
            // 
            // easyRB
            // 
            this.easyRB.AutoSize = true;
            this.easyRB.Checked = _easy;
            this.easyRB.Location = new System.Drawing.Point(12, 74);
            this.easyRB.Name = "easyRB";
            this.easyRB.Size = new System.Drawing.Size(48, 17);
            this.easyRB.TabIndex = 11;
            this.easyRB.Text = "Easy";
            this.easyRB.UseVisualStyleBackColor = true;
            // 
            // mediumRB
            // 
            this.mediumRB.AutoSize = true;
            this.mediumRB.Checked = _medium;
            this.mediumRB.Location = new System.Drawing.Point(103, 74);
            this.mediumRB.Name = "mediumRB";
            this.mediumRB.Size = new System.Drawing.Size(62, 17);
            this.mediumRB.TabIndex = 12;
            this.mediumRB.TabStop = true;
            this.mediumRB.Text = "Medium";
            this.mediumRB.UseVisualStyleBackColor = true;
            // 
            // hardRB
            // 
            this.hardRB.AutoSize = true;
            this.hardRB.Checked = _hard;
            this.hardRB.Location = new System.Drawing.Point(194, 74);
            this.hardRB.Name = "hardRB";
            this.hardRB.Size = new System.Drawing.Size(48, 17);
            this.hardRB.TabIndex = 13;
            this.hardRB.Text = "Hard";
            this.hardRB.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(294, 103);
            this.Controls.Add(this.hardRB);
            this.Controls.Add(this.mediumRB);
            this.Controls.Add(this.easyRB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.colTextBox);
            this.Controls.Add(this.rowTextBox);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.MaximizeBox = false;
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.TextBox rowTextBox;
        private System.Windows.Forms.TextBox colTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton easyRB;
        private System.Windows.Forms.RadioButton mediumRB;
        private System.Windows.Forms.RadioButton hardRB;
    }
}