namespace Sudoku
{
    partial class Name
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Name));
            this.lblName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnNameOk = new System.Windows.Forms.Button();
            this.lblCongrats = new System.Windows.Forms.Label();
            this.lblCongrMess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 65);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(83, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Input your name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(109, 62);
            this.tbName.MaxLength = 3;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(45, 20);
            this.tbName.TabIndex = 1;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // btnNameOk
            // 
            this.btnNameOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnNameOk.Location = new System.Drawing.Point(160, 60);
            this.btnNameOk.Name = "btnNameOk";
            this.btnNameOk.Size = new System.Drawing.Size(38, 23);
            this.btnNameOk.TabIndex = 2;
            this.btnNameOk.Text = "OK";
            this.btnNameOk.UseVisualStyleBackColor = true;
            this.btnNameOk.Click += new System.EventHandler(this.btnNameOk_Click);
            // 
            // lblCongrats
            // 
            this.lblCongrats.AutoSize = true;
            this.lblCongrats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCongrats.Location = new System.Drawing.Point(55, 9);
            this.lblCongrats.Name = "lblCongrats";
            this.lblCongrats.Size = new System.Drawing.Size(99, 13);
            this.lblCongrats.TabIndex = 3;
            this.lblCongrats.Text = "Congratulations!";
            // 
            // lblCongrMess
            // 
            this.lblCongrMess.AutoSize = true;
            this.lblCongrMess.Location = new System.Drawing.Point(41, 31);
            this.lblCongrMess.Name = "lblCongrMess";
            this.lblCongrMess.Size = new System.Drawing.Size(157, 13);
            this.lblCongrMess.TabIndex = 4;
            this.lblCongrMess.Text = "You made it to the highscorelist.";
            // 
            // Name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 95);
            this.Controls.Add(this.lblCongrMess);
            this.Controls.Add(this.lblCongrats);
            this.Controls.Add(this.btnNameOk);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Name";
            this.Text = "Congratulations";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnNameOk;
        private System.Windows.Forms.Label lblCongrats;
        private System.Windows.Forms.Label lblCongrMess;
    }
}