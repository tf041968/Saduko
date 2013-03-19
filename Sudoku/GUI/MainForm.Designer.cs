namespace Sudoku
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlSudoku = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.lblClock = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnShowHigh = new System.Windows.Forms.Button();
            this.CBDifficulty = new System.Windows.Forms.ComboBox();
            this.btnInstruct = new System.Windows.Forms.Button();
            this.pnlSudoku.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSudoku
            // 
            this.pnlSudoku.BackColor = System.Drawing.Color.White;
            this.pnlSudoku.Controls.Add(this.lblHeader);
            this.pnlSudoku.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSudoku.Location = new System.Drawing.Point(13, 13);
            this.pnlSudoku.Name = "pnlSudoku";
            this.pnlSudoku.Size = new System.Drawing.Size(440, 418);
            this.pnlSudoku.TabIndex = 0;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(186, 36);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Sa du ko?";
            // 
            // btnNewGame
            // 
            this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewGame.Location = new System.Drawing.Point(459, 356);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(140, 75);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClock.Location = new System.Drawing.Point(459, 330);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(59, 23);
            this.lblClock.TabIndex = 2;
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnShowHigh
            // 
            this.btnShowHigh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowHigh.Location = new System.Drawing.Point(605, 356);
            this.btnShowHigh.Name = "btnShowHigh";
            this.btnShowHigh.Size = new System.Drawing.Size(145, 75);
            this.btnShowHigh.TabIndex = 5;
            this.btnShowHigh.Text = "Show Highscore";
            this.btnShowHigh.UseVisualStyleBackColor = true;
            this.btnShowHigh.Click += new System.EventHandler(this.btnShowHigh_Click);
            // 
            // CBDifficulty
            // 
            this.CBDifficulty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CBDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDifficulty.FormattingEnabled = true;
            this.CBDifficulty.Location = new System.Drawing.Point(524, 332);
            this.CBDifficulty.Name = "CBDifficulty";
            this.CBDifficulty.Size = new System.Drawing.Size(75, 21);
            this.CBDifficulty.TabIndex = 6;
            this.CBDifficulty.SelectedIndexChanged += new System.EventHandler(this.CBDifficulty_SelectedIndexChanged);
            // 
            // btnInstruct
            // 
            this.btnInstruct.Location = new System.Drawing.Point(605, 330);
            this.btnInstruct.Name = "btnInstruct";
            this.btnInstruct.Size = new System.Drawing.Size(145, 23);
            this.btnInstruct.TabIndex = 7;
            this.btnInstruct.Text = "Instructions";
            this.btnInstruct.UseVisualStyleBackColor = true;
            this.btnInstruct.Click += new System.EventHandler(this.btnInstruct_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sudoku.Properties.Resources._9x9;
            this.ClientSize = new System.Drawing.Size(762, 443);
            this.Controls.Add(this.btnInstruct);
            this.Controls.Add(this.CBDifficulty);
            this.Controls.Add(this.btnShowHigh);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pnlSudoku);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Sudoku";
            this.pnlSudoku.ResumeLayout(false);
            this.pnlSudoku.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSudoku;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnShowHigh;
        private System.Windows.Forms.ComboBox CBDifficulty;
        private System.Windows.Forms.Button btnInstruct;
    }
}

