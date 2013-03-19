/*
 * HighscoreList.cs
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

namespace Sudoku
{
    public partial class HighscoreList : Form
    {
        /// <summary>
        /// Defaultkonstruktor
        /// </summary>
        public HighscoreList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Överlagrad metod för att skriva ut highscorelistan. 
        /// Om det inte finns nån lista hämtar man den från Highscore.cs
        /// </summary>
        public void PrintHighscore()
        { 
          Highscore highscore = new Highscore();
          List<string> list = highscore.GetList();
          PrintHighscore(list);
        }
        /// <summary>
        /// Skriver ut highscorelistan. 
        /// </summary>
        /// <param name="list">Listan som ska skrivas ut. </param>
        public void PrintHighscore (List<string> list)
        {
            //Gör en array av listan. 
            string[] strList = list.ToArray();
            //Skapar en array för att hålla den formaterade listan.
            string[] formattedList = new string[10];
            //En array för den nuvarande raden. 
            string[] currentRow;

            //Tömmer listan.
            lbHighscore.Items.Clear();

            //Variabler för att hålla värden för tid. 
            double time;
            int minutes;
            int seconds;
            int hours;

            //Loopar igenom hela listan. 
            for (int i = 0; i < 10; i++)
            {
                if (i < strList.Length)
                {
                    //Delar upp nuvarande raden på semikolon för att kunna urskilja tiden från namnet. 
                    currentRow = strList[i].Split(';');
                    //Gör tid-strängen till en double. 
                    if (double.TryParse(currentRow[1], out time))
                    {
                        //Sträng för att håla den formaterade tiden. 
                        string formattedTime;
                        
                        //Skapar sekunder och minuter från tiden. 
                        minutes = (int)(time / 60);
                        seconds = (int)(time % 60);

                        //Om det är mer än 60 minuter ska även timmar skrivas ut. 
                        if (minutes > 60)
                        {
                            hours = minutes / 60;
                            minutes = minutes % 60;
                            formattedTime = hours + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
                        }
                        else //Annars skrivs bara minuter och sekunder ut. 
                        {
                            formattedTime = minutes + ":" + seconds.ToString("00");
                        }
                        //Skriver ihop namnet med tiden. 
                        formattedList[i] = (i + 1).ToString("00") + ": " + currentRow[0].ToUpper() + " - " + formattedTime;
                    }
                }
                else //Något har gått fel, listan är för stor. 
                {
                    formattedList[i] = (i + 1).ToString("00") +": " + "WAT" + " - " + (i+1) * 500; 
                }
            }
            lbHighscore.Items.AddRange(formattedList);
        }

        /// <summary>
        /// Metod för att tömma listan. Skapar och skriver ut en defaultlista. 
        /// </summary>
        private void btnClearHigh_Click(object sender, EventArgs e)
        {
            Highscore hs = new Highscore();
            hs.CreateDefaultHighscore();
            PrintHighscore();
        }
        /// <summary>
        /// Stänger rutan. 
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
