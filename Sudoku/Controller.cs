/*
 * Controller.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Sudoku
{
    public class Controller
    {
        /// <summary>
        /// CONSTANTS AND FIELDS
        /// </summary>
        //Number of squares
        private const int gridSize = 9;
        //Storlek på rutan, samt padding
        private const int size = 40;
        private const int padding = 7;
        //roten ur maxnumber, för att ta reda på lillrutorna
        private int sqrtLog = (int)Math.Sqrt(gridSize);

        SquareManager squareMngr;
        SquareGUIManager squareGUIMngr;

        public Controller()
        {
            squareMngr = new SquareManager(gridSize);
            squareGUIMngr = new SquareGUIManager(gridSize, squareMngr);
        }
        
        /// <summary>
        /// Method to edit a square
        /// </summary>
        /// <param name="strToConvert">The string with a number-value</param>
        /// <param name="row">Coordinates for the square</param>
        /// <param name="col">Coordinates for the square</param>
        /// <returns>True or false, if it went "okay"</returns>
        public void EditSquare(string strToConvert, int row, int col)
        {
            bool isOK = squareMngr.EditSquare(strToConvert, row, col);
            squareGUIMngr.EditSquare(strToConvert, row, col, isOK);
        }

        /// <summary>
        /// Skapar nummervärden för rutorna. 
        /// </summary>
        public void GetNumbers(int nummer)
        {
            Sudoku sudoku = new Sudoku();
            sudoku.SetPath(nummer);
            int[,] grid = sudoku.GetSudoku();
            int number;
            for (int currRow = 0; currRow < gridSize; currRow++)
            {
                for (int currCol = 0; currCol < gridSize; currCol++)
                {
                    number = grid[currRow, currCol];
                    EditNumber(currRow, currCol, number, true);
                }
            }
        }
        
        /// <summary>
        /// Skapa rut-objekt med defaultvärdet 0
        /// </summary>
        /// <returns>En tvådimensionell array med defaultvärden ifyllda</returns>
        public SquareGUI[,] InitializeGrid()
        {
            Square[,] squares = squareMngr.InitializeGrid();
            int row = 0;
            int col = 0;
            int currNum;
            for (int currRow = 0; currRow < gridSize; currRow++)
            {
                for (int currCol = 0; currCol < gridSize; currCol++)
                {
                    currNum = squares[currRow, currCol].Number;
                    squareGUIMngr.InitializeGrid(currRow, currCol, row, col, currNum, squares[currRow, currCol]);
                    //Tar reda på var rutan ska vara
                    if (currCol == 0)
                    {
                        row += size;
                        col = 0;
                    }
                    if (currRow > 0 && currRow % sqrtLog == 0 && currCol == 0)
                    {
                        row += padding;
                    }
                    if (currCol > 0 && currCol % sqrtLog == 0)
                    {
                        col += padding;
                    }
                    
                    squareGUIMngr.InitializeSquare(currRow, currCol, row, col);
                    col += size;
                }
            }
            return squareGUIMngr.GetSquareGUIs;
        }
        
        /// <summary>
        /// Metod för att ändra numret i rutorna. 
        /// </summary>
        /// <param name="row">Raden där rutan finns</param>
        /// <param name="col">Kolumnen där rutan finns</param>
        /// <param name="number">Värdet som ska in i rutan.</param>
        private void EditNumber(int row, int col, int number, bool init)
        {
            squareMngr.EditNumber(row, col, number);
            squareGUIMngr.EditNumber(row, col, number, init);
            if (!init && squareMngr.NumbersLeft() == 0)
            {
                Complete(); 
            }
        }
        /// <summary>
        /// Om spelet är klart ska squareMngr.Complete() anropas.
        /// Dessutom visas en MessageBox. 
        /// </summary>
        private void Complete()
        {
            squareMngr.Complete();
            MessageBox.Show("Grattis! Du klarade det!");
        }

        /// <summary>
        /// Stannar tidtagningen.
        /// </summary>
        /// <returns>En bool om det gick bra eller ej. </returns>
        public bool StopTime()
        { 
            return (squareMngr.NumbersLeft() == 0);
        }

        /// <summary>
        /// Returnerar tiden som gått. 
        /// </summary>
        /// <returns>En int med tiden i sekunder. </returns>
        public int GetTime()
        {
            return squareMngr.GetTime();
            
        }
        /// <summary>
        /// Startar tidtagningen
        /// </summary>
        public void StartTime()
        {
            squareMngr.StartTime();
        }

        /// <summary>
        /// Skapar nytt spel
        /// </summary>
        public void NewGame()
        {
            InitializeGrid();
            squareMngr.StartTime();
        }

        /// <summary>
        /// Metod som kontrollerar om en viss ruta är låst eller ej. 
        /// </summary>
        /// <param name="row">Raden där rutan finns. </param>
        /// <param name="col">Kolumnen där rutan finns</param>
        /// <returns>En bool som berättar om rutan är låst eller ej.</returns>
        private bool IsLocked(int row, int col)
        {
            return squareGUIMngr.IsLocked(row, col);
        }
        /// <summary>
        /// Property för gridSize
        /// </summary>
        public int MaxNumber
        {
            get { return gridSize; }
        }
    }
}
