/*
 * MainForm.cs
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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Sudoku
{
    public partial class MainForm : Form
    {
        //Fields för de olika klasserna.
        private Controller m_controller;
        private SquareGUI[,] squares;
        Stopwatch sw = new Stopwatch();
        Highscore m_highscore = new Highscore();
        private int nummer;
        public MainForm()
        {
            m_controller = new Controller();
            InitializeComponent();
            InitializeGrid();
            CBDifficulty.DataSource = Enum.GetNames(typeof(Difficulty));
            
        }
        
        /// <summary>
        /// Initierar rutnätet. Skriver ut ett antal SquareGUI-objekt. 
        /// </summary>
        private void InitializeGrid()
        {
            squares = m_controller.InitializeGrid();
            for (int i = 0; i < squares.GetLength(0); i++)
            {
                for (int j = 0; j < squares.GetLength(1); j++)
                {
                    pnlSudoku.Controls.Add(squares[i, j]);
                }
            }
        }

        /// <summary>
        /// Vid klick på nytt spel ska NewGame() anropas. 
        /// </summary>
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        /// <summary>
        /// Metod för stoppuret. 
        /// </summary>
        private void StopWatch()
        {
            sw.Reset();
            timer1.Start();
            sw.Start();
        }
        /// <summary>
        /// Knapp för att rätta lösningen och stoppa klockan. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValidate_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            m_highscore.AddHighscore(sw.Elapsed.TotalSeconds);
            
        }
        /// <summary>
        /// Timer som räknar ut hur länge man spelat. 
        /// Tiden hämtas från controller, som i sin tur hämtar från TimeTracker via SquareManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = m_controller.GetTime().ToString();
            if (m_controller.StopTime())
            { 
                timer1.Stop(); 
            }
        }

        /// <summary>
        /// För att visa highscorelistan. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHigh_Click(object sender, EventArgs e)
        {
            HighscoreList highscorelist = new HighscoreList();
            highscorelist.Show();
            highscorelist.PrintHighscore();
        }
        /// <summary>
        /// Om man ändrar på comboboxen med svårighetsgrader.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            nummer = CBDifficulty.SelectedIndex;
            
        }

        /// <summary>
        /// Metod för att initiera nytt spel. 
        /// Hämtar siffror från controllern. 
        /// </summary>
        private void NewGame()
        {
            DialogResult DialogRes = MessageBox.Show("Starta nytt spel?", "Säker?", MessageBoxButtons.YesNo);
            if (DialogRes == DialogResult.Yes)
            {
                m_controller.GetNumbers(nummer);
                StopWatch();
                m_controller.StartTime();
            }
        }

        /// <summary>
        /// Knapp för att öppna instruktionsfönstret. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInstruct_Click(object sender, EventArgs e)
        {
            Instructions m_instruct = new Instructions();
            m_instruct.Show();
            m_instruct.PrintInstruct();   
        }
 
    }
}
