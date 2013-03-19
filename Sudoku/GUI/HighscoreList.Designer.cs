namespace Sudoku
{
    partial class HighscoreList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HighscoreList));
            this.lbHighscore = new System.Windows.Forms.ListBox();
            this.lblHighscore = new System.Windows.Forms.Label();
            this.btnClearHigh = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbHighscore
            // 
            this.lbHighscore.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHighscore.FormattingEnabled = true;
            this.lbHighscore.ItemHeight = 14;
            this.lbHighscore.Location = new System.Drawing.Point(24, 36);
            this.lbHighscore.Name = "lbHighscore";
            this.lbHighscore.Size = new System.Drawing.Size(376, 242);
            this.lbHighscore.TabIndex = 0;
            // 
            // lblHighscore
            // 
            this.lblHighscore.AutoSize = true;
            this.lblHighscore.Location = new System.Drawing.Point(24, 13);
            this.lblHighscore.Name = "lblHighscore";
            this.lblHighscore.Size = new System.Drawing.Size(55, 13);
            this.lblHighscore.TabIndex = 1;
            this.lblHighscore.Text = "Highscore";
            // 
            // btnClearHigh
            // 
            this.btnClearHigh.Location = new System.Drawing.Point(87, 292);
            this.btnClearHigh.Name = "btnClearHigh";
            this.btnClearHigh.Size = new System.Drawing.Size(126, 23);
            this.btnClearHigh.TabIndex = 2;
            this.btnClearHigh.Text = "Clear Highscore";
            this.btnClearHigh.UseVisualStyleBackColor = true;
            this.btnClearHigh.Click += new System.EventHandler(this.btnClearHigh_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(219, 292);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // HighscoreList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 327);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClearHigh);
            this.Controls.Add(this.lblHighscore);
            this.Controls.Add(this.lbHighscore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HighscoreList";
            this.Text = "HighscoreList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbHighscore;
        private System.Windows.Forms.Label lblHighscore;
        private System.Windows.Forms.Button btnClearHigh;
        private System.Windows.Forms.Button btnClose;
    }
}