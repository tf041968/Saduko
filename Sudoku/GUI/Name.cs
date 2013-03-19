/*
 * Name.cs
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
    public partial class Name : Form
    {
        //Variabel för namn. 
        string name;
        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public Name()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Läser in namnet och sparar den i name. 
        /// </summary>
        private void ReadName()
        {
            this.name = tbName.Text;
        }
        /// <summary>
        /// Property för name.
        /// </summary>
        public string GetName
        {
            get { return name; }
        }

        /// <summary>
        /// När man klickar på OK ska namnet läsas in och sparas i name. Detta sker i metoden ReadName()
        /// </summary>
        private void btnNameOk_Click(object sender, EventArgs e)
        {
            ReadName();
        }

        /// <summary>
        /// Så att man även kan klicka på enter istället för på OK.
        /// </summary>
        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnNameOk_Click(sender, e);
            }
        }
    }
}
