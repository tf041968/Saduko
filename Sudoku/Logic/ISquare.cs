/*
 * ISquare.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public abstract class ISquare
    {
        //Abstrakta metoder. 
        public abstract int Number { get; set; }
        public abstract bool Locked { get; set; }
        public abstract int Row { get; }
        public abstract int Col { get; }
    }
}
