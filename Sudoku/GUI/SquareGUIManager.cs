/*
 * SquareGUIManager.cs
 * Johan Persson, Pontus Ohlsson, Carl-Peter Holgersson
 * 2012-05-22
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Sudoku
{
    public class SquareGUIManager
    {
        //Fält
        SquareGUI[,] squareGUIs;
        private int gridSize;
        private int sqrtLog;
        SquareManager sm;

        //Storlek på rutan, samt padding
        private const int size = 40;
        private const int padding = 7;

        public SquareGUIManager(int gridSize, SquareManager sm)
        {
            this.gridSize = gridSize;
            squareGUIs = new SquareGUI[gridSize, gridSize];
            sqrtLog = (int)Math.Sqrt(gridSize);
            this.sm = sm;
        }
        public void InitializeGrid(int currRow, int currCol, int row, int col, int currNum, Square square)
        {
            //Skapar en ruta
            squareGUIs[currRow, currCol] = new SquareGUI(square);


            

            //Skapar defaultvärden
            //InitializeSquare(currRow, currCol, row, col);

            
        }
        /// <summary>
        /// Sätter defaultvärden i varje ruta. Sätter bland annat Location, Visible, BorderStyle, MaxLength och EventHandlers.
        /// </summary>
        /// <param name="currRow">Vilket objekt i arrayen squares</param>
        /// <param name="currCol">Vilket objekt i arrayen squares</param>
        /// <param name="drawingRow">Vilken pixel i höjdled som rutan ska skrivas ut i</param>
        /// <param name="drawingCol">Vilken pixel i sidled som rutan ska skrivas ut i</param>
        public void InitializeSquare(int currRow, int currCol, int drawingRow, int drawingCol)
        {
            squareGUIs[currRow, currCol].Name = "textbox" + currRow.ToString();
            squareGUIs[currRow, currCol].Location = new System.Drawing.Point(drawingCol, drawingRow);
            squareGUIs[currRow, currCol].Visible = true;
            squareGUIs[currRow, currCol].Multiline = true;
            squareGUIs[currRow, currCol].BorderStyle = BorderStyle.FixedSingle;

            squareGUIs[currRow, currCol].TextAlign = HorizontalAlignment.Center;
            squareGUIs[currRow, currCol].MaxLength = 1;

            squareGUIs[currRow, currCol].Size = new System.Drawing.Size(size, size);
            squareGUIs[currRow, currCol].KeyUp += new KeyEventHandler(Controller_KeyUp);
            
            squareGUIs[currRow, currCol].SelectionStart = 0;

            if (squareGUIs[currRow, currCol].GetSquare.Locked)
            {
                squareGUIs[currRow, currCol].Enabled = false;
                squareGUIs[currRow, currCol].Font = new Font("Courier New", 20, FontStyle.Bold);
            }
            else
            {
                squareGUIs[currRow, currCol].Enabled = true;
                squareGUIs[currRow, currCol].Font = new Font("Courier New", 20);
            }

            if (squareGUIs[currRow, currCol].GetSquare.Number > 0 && squareGUIs[currRow, currCol].GetSquare.Number <= gridSize)
            {
                squareGUIs[currRow, currCol].Text = squareGUIs[currRow, currCol].GetSquare.Number.ToString();
            }
            else
            {
                squareGUIs[currRow, currCol].Text = string.Empty;
            }
        }
        /// <summary>
        /// När man klickar på en knapp ska ButtonPressed anropas.
        /// </summary>
        private void Controller_KeyUp(object sender, KeyEventArgs e)
        {
            ButtonPressed((SquareGUI)sender, e.KeyCode);
        }
        /// <summary>
        /// Tar emot knappen man kickade på och kontrollerar så att det är en 
        /// av de knapparna man ska kunna klicka på, samt anropar rätt metoder. 
        /// </summary>
        private void ButtonPressed(SquareGUI square, Keys k)
        {
            int num = -1;

            //Kollar om man har skrivit in en siffra
            switch (k)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    num = 0;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    num = 1;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    num = 2;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    num = 3;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    num = 4;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    num = 5;
                    break;
                case Keys.D6:
                case Keys.NumPad6:
                    num = 6;
                    break;
                case Keys.D7:
                case Keys.NumPad7:
                    num = 7;
                    break;
                case Keys.D8:
                case Keys.NumPad8:
                    num = 8;
                    break;
                case Keys.D9:
                case Keys.NumPad9:
                    num = 9;
                    break;
                default:
                    num = -1;
                    break;
            }

            //Om siffran är inom det rättcoma spannet
            if (num > 0 && num <= gridSize)
            {
                EditSquare(square, num);
            }
            //För att kunna sudda siffror
            else if (k == Keys.Space || k == Keys.Delete || k == Keys.Back)
            {
                square.Text = string.Empty;
                EditNumber(square, 0, false);
            }
            //Så att man kan tabba framåt och bakåt
            else if (k != Keys.Tab && k != Keys.ShiftKey)
            {
                //Om det redan finns en siffra i square ska man skriva ut den som svart
                if (square.GetSquare.Number > 0)
                {
                    square.Text = square.GetSquare.Number.ToString();
                    square.ForeColor = Color.Black;
                }
                //Annars skriv ut en tom sträng
                else
                {
                    square.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Överlagrad metod för att kunna ändra texten i en ruta.
        /// Tar ett square-objekt gör om det till row, col och en bool som kollar om det går att ändra. 
        /// </summary>
        /// <param name="square">Ett rutobjekt</param>
        /// <param name="num">Numret man vill ändra.</param>
        public void EditSquare(SquareGUI square, int num)
        {
            int row = square.GetSquare.Row;
            int col = square.GetSquare.Col;
            bool isOK = sm.EditSquare(num.ToString(), row, col);
            EditSquare(num.ToString(), row, col, isOK);
        }

        /// <summary>
        /// Ändrar texten i en ruta. 
        /// </summary>
        /// <param name="strToConvert">Textsträngen som ska skrivas in i rutan.</param>
        /// <param name="row">Raden där rutan finns.</param>
        /// <param name="col">Kolumnen där rutan finns.</param>
        /// <param name="isOK">Om det gick att ändra rutan i SquareManager</param>
        public void EditSquare(string strToConvert, int row, int col, bool isOK)
        {
            //Om det inte gick att ändra rutan ska texten skrivas in i rött. 
            if (!isOK)
            {
                squareGUIs[row, col].ForeColor = Color.Red;
                squareGUIs[row, col].Text = strToConvert;
            }
            else //Annars anropas EditNumber
            {
                EditNumber(row, col, strToConvert, false);
            }
        }

        /// <summary>
        /// Överlagrad metod för att ändra texten i en ruta. 
        /// Gör om ett squareobjekt till row och col. 
        /// </summary>
        /// <param name="square">Rutan som ska ändras.</param>
        /// <param name="number">Det nya numret.</param>
        /// <param name="init">Om det är i Initieringen. </param>
        private void EditNumber(SquareGUI square, int number, bool init)
        {
            EditNumber(square.GetSquare.Row, square.GetSquare.Col, number, init);
        }
        /// <summary>
        /// Överlagrad metod för att ändra texten i en ruta. 
        /// Gör om en textsträng till ett heltal. 
        /// </summary>
        /// <param name="row">Raden där rutan finns</param>
        /// <param name="col">Kolumnen där rutan finns</param>
        /// <param name="number">Textsträngen som ska in i rutan. </param>
        /// <param name="init">Om det är i initieringen eller ej. </param>
        private void EditNumber(int row, int col, string number, bool init)
        {
            int num;
            if (InputUtility.GetInteger(number, out num, 0, gridSize))
                EditNumber(row, col, num, false);
        }
        /// <summary>
        /// Metod för att ändra texten i en ruta. 
        /// </summary>
        /// <param name="row">Raden där rutan finns</param>
        /// <param name="col">Kolumnen där rutan finns</param>
        /// <param name="number">Numret som ska in i rutan. </param>
        /// <param name="init">Om det är i initieringen eller ej. </param>
        public void EditNumber(int row, int col, int number, bool init)
        {
            //Som default ska texten i rutan vara svart. 
            squareGUIs[row, col].ForeColor = Color.Black;
            
            if (number > 0)
            {
                if (init)
                {
                    //Om det är i initieringen ska rutan vara låst, inte enabled och font ska vara bold. 
                    squareGUIs[row, col].GetSquare.Locked = true;
                    squareGUIs[row, col].Enabled = false;
                    squareGUIs[row, col].Font = new Font("Courier New", 20, FontStyle.Bold);
                }
                squareGUIs[row, col].Text = number.ToString();
            }
            else
            {
                //Om siffran är noll ska rutan vara tom, den ska inte vara låst, och den ska vara enabled. 
                squareGUIs[row, col].Text = string.Empty;
                if (init)
                {
                    squareGUIs[row, col].GetSquare.Locked = false;
                    squareGUIs[row, col].Enabled = true;
                    squareGUIs[row, col].Font = new Font("Courier New", 20);
                }
            }
            //Kontrollerar om det finns några siffror kvar i spelet som är större än noll. 
            //Finns det inte det är det klart!
            if (!init && sm.NumbersLeft() == 0)
            {
                Complete();
            }
        }
        /// <summary>
        /// Om allt är klart ska en metod i SquareManager anropas. 
        /// </summary>
        private void Complete()
        {
            sm.Complete();
        }

        /// <summary>
        /// Metod för att kontrollera om en siffra är låst eller inte. 
        /// Går in i squareGUI-objektet och hämtar värdet därifrån. 
        /// </summary>
        /// <param name="row">Raden där rutan finns</param>
        /// <param name="col">Kolumnen där rutan finns</param>
        /// <returns>En bool, om den är låst eller ej.</returns>
        public bool IsLocked(int row, int col)
        {
            return squareGUIs[row, col].GetSquare.Locked;
        }
        /// <summary>
        /// Metod för att hämta alla SquareGUIs. En SquareGUI[,] returneras. 
        /// </summary>
        public SquareGUI[,] GetSquareGUIs
        {
            get { return squareGUIs; }
        }
    }
}
