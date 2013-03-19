/*
 * InputUtility.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class InputUtility
    {
        /// <summary>
        /// Kontrollerar så att en textsträng går att göra till en double, samt att den är inom spannet minLimit och maxLimit
        /// </summary>
        /// <param name="stringToConvert">Textsträngen som ska konverteras.</param>
        /// <param name="dblOutValue">Utvärdet, en double.</param>
        /// <param name="minLimit">Minsta möjliga värde.</param>
        /// <param name="maxLimit">Högsta möjliga värde.</param>
        /// <returns>En bool, om det gick bra eller inte.</returns>
        public static bool GetDouble(string stringToConvert, out double dblOutValue, double minLimit, double maxLimit)
        {
            if(Double.TryParse(stringToConvert, out dblOutValue))
            {
                return (dblOutValue <= maxLimit && dblOutValue >= minLimit);
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Kontrollerar så att en textsträng går att göra till ett heltal, samt att den är inom spannet minLimit och maxLimit
        /// </summary>
        /// <param name="stringToConvert">Textsträngen som ska konverteras.</param>
        /// <param name="intOutValue">Utvärdet, en int.</param>
        /// <param name="minLimit">Minsta möjliga värde.</param>
        /// <param name="maxLimit">Högsta möjliga värde.</param>
        /// <returns>En bool, om det gick bra eller inte.</returns>
        public static bool GetInteger(string stringToConvert, out int intOutValue, int minLimit, int maxLimit)
        {
            if(int.TryParse(stringToConvert, out intOutValue))
            {
                return (intOutValue <= maxLimit && intOutValue >= minLimit);
            }
            else
            {
                return false;
            }
        }
    }
}
