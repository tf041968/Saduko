/*
 * Sudoku.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    class Sudoku
    {
        //Paths till filerna. En för easy, medium och hard. 
        //En fil har formen 5;0;6;1;3, där 0 står för tomma rutor. 
        //En rad är 81 tecken lång. Varje rad är ett eget sudoku. 
        string path;
        string pathEasy = @"../../Resources/Sudoku.txt";
        string pathMedium = @"../../Resources/SudokuMedium.txt";
        string pathHard = @"../../Resources/SudokuHard.txt";

        //Lista för att hålla i talen. 
        List<string> list;
        
        public Sudoku()
        {
            //Som default sätts easy som path. 
            path = pathEasy;
            list = new List<string>();
        }

        /// <summary>
        /// Läser in filen och sparar alla värden i listan. 
        /// </summary>
        private void ReadFile()
        {
            StreamReader sr = new StreamReader(path);
            list.Clear();
            while (sr.Peek() >= 0)
            {
                list.Add(sr.ReadLine());
            }
            sr.Close();
        }
        /// <summary>
        /// Läser in filen, hämtar ett sudoku och returnerar en int[9,9] med värden
        /// </summary>
        /// <returns></returns>
        public int[,] GetSudoku()
        {
            ReadFile();
            //Slumpar en siffra och väljer därmed ett sudoku. 
            Random rand = new Random();
            int number = rand.Next(0, list.Count);
            int index = 0;
            //Splittar på ; så man får alla talen för sig. 
            string[] sudoku = list[number].Split(';');
            int currentSquare;
            int[,] grid = new int[9,9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    //Kontrollerar så att det är en siffra
                    if(InputUtility.GetInteger(sudoku[index], out currentSquare, 0, 9)){
                        grid[row,col] = currentSquare;
                    }
                    index++;
                }
            }
            return grid;
        }

        /// <summary>
        /// Används för att välja path, 0-2. 
        /// </summary>
        /// <param name="number">En siffra från 0-2 för att välja svårighetsgrad</param>
        public void SetPath(int number)
        {
            if (number == 0)
            {
                path = pathEasy;
            }
            else if (number == 1)
            {
                path = pathMedium;
            }
            else if (number == 2)
            {
                path = pathHard;
            }
            else
            {
                path = pathEasy;
            }
        }

       

    }
}
