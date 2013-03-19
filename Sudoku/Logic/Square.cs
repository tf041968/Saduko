/*
 * Square.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class Square : ISquare
    {
        //Fields
        private int number;
        private bool locked;
        private int row, col;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="number">Nummervärdet som rutan ska ha.</param>
        /// <param name="row">Vilken rad rutan befinner sig på.</param>
        /// <param name="col">Vilken kolumn rutan befinner sig på.</param>
        /// <param name="locked">Om den är låst eller ej.</param>
        public Square(int number, int row, int col, bool locked)
        {
            this.number = number;
            this.locked = locked;
            this.row = row;
            this.col = col;
        }

        /// <summary>
        /// Property för fältet number.
        /// </summary>
        public override int Number
        {
            get { return number; }
            set
            {
                if (!locked)
                {
                    number = value;
                }
            }
        }
        /// <summary>
        /// Property för fältet locked
        /// </summary>
        public override bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }
        /// <summary>
        /// Property för row
        /// </summary>
        public override int Row
        {
            get { return row; }
        }
        /// <summary>
        /// Property för col
        /// </summary>
        public override int Col
        {
            get { return col; }
        }
    }
}
