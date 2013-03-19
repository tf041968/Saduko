/*
 * SquareManager.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sudoku
{
    public class SquareManager
    {
        //Square[,] går på int[row, col];
        private Square[,] squares;

        //Storleken på sudokun. Oftast 9.
        private int gridSize;
        //Används bara för att lagra roten ur grisSize för att förenkla koden.
        private int sqrtLog;

        //TimeTracker- och Highscoreobjekt. Används för tiden och highscorelistan. 
        private Timetracker tt;
        private Highscore hs;

        /// <summary>
        /// Konstruktor. Anropas från Controller. Tar emot storleken på gridSize och skapar objekt. 
        /// </summary>
        /// <param name="gridSize"></param>
        public SquareManager(int gridSize)
        {
            this.gridSize = gridSize;
            squares = new Square[gridSize, gridSize];
            sqrtLog = (int)Math.Sqrt(gridSize);
            tt = new Timetracker();
            hs = new Highscore();
        }
        /// <summary>
        /// Initierar spelplanen. 
        /// </summary>
        /// <returns>Returnerar en Square[,] med alla rutobjekt.</returns>
        public Square[,] InitializeGrid()
        {
            Sudoku sudoku = new Sudoku();
            int currNum;
            int[,] grid = sudoku.GetSudoku();
            for (int currRow = 0; currRow < gridSize; currRow++)
            {
                for (int currCol = 0; currCol < gridSize; currCol++)
                {
                    //Skapar en ruta
                    currNum = grid[currRow, currCol];
                    if (currNum > 0)
                    {
                        squares[currRow, currCol] = new Square(currNum, currRow, currCol, true);
                    }
                    else
                    {
                        squares[currRow, currCol] = new Square(currNum, currRow, currCol, false);
                    }
                }
            }
            return squares;
        }

        /// <summary>
        /// Ändrar en siffra efter att det är validerat och okejat. 
        /// </summary>
        /// <param name="row">Raden som siffran är på</param>
        /// <param name="col">Kolumnen som siffran är på</param>
        /// <param name="num">Det nya nummret den ska ha.</param>
        public void EditNumber(int row, int col, int num)
        {
            squares[row, col].Number = num;
        }

        /// <summary>
        /// Den stora metoden för att ändra värdet i en ruta. 
        /// </summary>
        /// <param name="strToConvert">Texten som ska in i rutan.</param>
        /// <param name="row">Raden som rutan är på.</param>
        /// <param name="col">Kolumnen som rutan är på.</param>
        /// <returns>True om det gick bra, annars false.</returns>
        public bool EditSquare(string strToConvert, int row, int col)
        {
            int number;
            if (InputUtility.GetInteger(strToConvert, out number, 0, gridSize)) //Kontrollerar så att strToConvert är ett heltal inom spannet 0-gridSize
            {
                if (!squares[row, col].Locked) //Om rutan inte är låst. 
                {

                    if (Validate(row, col, number)) //Om det validerar
                    {
                        EditNumber(row, col, number); //Ändrar numret. Se ovan. 
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else //Om rutan är låst.
                {
                    return false;
                }
            }
            else //Om strToConvert inte är ett nummer.
            {
                return false;
            }
        }

        /// <summary>
        /// Validerar sudokuspelet runt siffran man vill ändra. 
        /// </summary>
        /// <param name="row">Raden man vill kolla</param>
        /// <param name="col">Kolumnen man vill kolla</param>
        /// <param name="number">Det nya heltalet</param>
        /// <returns>True om det gick bra, annars false.</returns>
        public bool Validate(int row, int col, int number)
        {
            //Sätter numberOK till true, så försöker vi falsifiera det nedan. 
            bool numberOK = true;

            //Kontrollerar värdet i hela raden.
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                if (squares[row, i].Number == number && i != col)
                {
                    numberOK = false;
                    break;
                }
            }

            //Kontrollerar värdet i kolumnen
            for (int i = 0; i < squares.GetLength(1); i++)
            {
                if (squares[i, col].Number == number && i != row)
                {
                    numberOK = false;
                    break;
                }
            }

            //Kontrollerar värdet i lillrutan
            //Row%sqrtLog ger ett heltal mellan 0-2. Om row är 7 ska row-(row%sqrtlog) ge 6, så har man 0,0 i lillrutan. 
            int startRow = row - (row % sqrtLog); 
            int startCol = col - (col % sqrtLog);
            for (int currRow = startRow; currRow < startRow + sqrtLog; currRow++)
            {
                for (int currCol = startCol; currCol < startCol + sqrtLog; currCol++)
                {
                    //Kontrollerar så att rutan man är i inte är rutan som ska ändras, 
                    //samt att rutans nummer inte får vara samma som number. 
                    if ((currRow != row && currCol != col) && squares[currRow, currCol].Number == number)
                    {
                        numberOK = false;
                        break;
                    }
                }
            }
            return numberOK;
        }

        /// <summary>
        /// När spelet är klart anropas TimeTracker för att  hämta tiden, och sen läggs det in i Highscore om den tar sig in på listan. 
        /// </summary>
        /// <returns>Int som har tidens värde. </returns>
        public int Complete()
        {
            
            int time = tt.GetTime();
            hs.AddHighscore(time);
            return time;
        }
        /// <summary>
        /// Hämtar tiden och returnerar den i en int. 
        /// </summary>
        /// <returns>En int med tiden i sekunder.</returns>
        public int GetTime()
        {
            return tt.GetTime();
        }
        /// <summary>
        /// Startar tidtagningen. 
        /// </summary>
        public void StartTime()
        {
            tt.StartTime();
        }
        /// <summary>
        /// Kontrollerar hur många siffror som inte är ifyllda, dvs har värdet 0
        /// </summary>
        /// <returns>En int med antalet siffror.</returns>
        public int NumbersLeft()
        {
            int numbers = 0;
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    if (squares[row, col].Number == 0)
                    {
                        numbers++;
                    }
                }
            }

            return numbers;
        }
    }
}
