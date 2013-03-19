/*
 * TimeTracker.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class Timetracker
    {
        //DateTime för att hålla koll på starttiden. 
        DateTime start;
        /// <summary>
        /// Default-konstruktor. Startar tiden. 
        /// </summary>
        public Timetracker()
        {
            start = DateTime.Now;
        }
        /// <summary>
        /// Hämtar tiden.
        /// </summary>
        /// <returns>En int med antal sekunder som gått från starttid till nutid</returns>
        public int GetTime()
        {
            int now = (int)DateTime.Now.Subtract(start).TotalSeconds;

            return now;
        }
        /// <summary>
        /// Startar tiden. 
        /// </summary>
        public void StartTime()
        {
            start = DateTime.Now;
        }

    }
}
