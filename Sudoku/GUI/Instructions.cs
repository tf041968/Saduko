/*
 * Instructions.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metod för att skriva ut instruktioner från fil. 
        /// </summary>
        public void PrintInstruct()
        {
            const string path2 = @"../../Resources/Instructions.rtf";
            richTextBox1.LoadFile(path2);
        }

        /// <summary>
        /// Stänger fönstret
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
