/*
 * SquareGUI.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class SquareGUI : System.Windows.Forms.TextBox
    {
        //Har en square. 
        private Square my_square;

        /// <summary>
        /// Constructor. 
        /// </summary>
        public SquareGUI(Square square)
        {
            my_square = square;
        }
        /// <summary>
        /// Property för my_square. 
        /// </summary>
        public Square GetSquare
        {
            get { return my_square; }
        }
    }
}
