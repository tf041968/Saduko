/*
 * Highscore.cs
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
    class Highscore
    {
        //Sökväg till textfilen
        const string path = @"../../Resources/Highscore.txt";
        //En lista som håller reda på vad som står i textfilen.
        List<string> list;

        /// <summary>
        /// Defaultkonstruktor. Skapar listan. 
        /// </summary>
        public Highscore()
        {
            list = new List<string>();
        }

        /// <summary>
        /// Läser in filen, sparar varje rad i list. 
        /// </summary>
        public void ReadFile()
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
        /// Lägger till en ny post i listan. 
        /// </summary>
        /// <param name="time">Tiden som ska läggas in.</param>
        public void AddHighscore(double time)
        {
            ReadFile();

            //Om listan är tom ska DefaultHighscore skapas, sen läses filen in igen.
            if (list.Count == 0)
            {
                CreateDefaultHighscore();
                ReadFile();
            }

            int index = CompareTimes(time); //Kollar vilken position som tiden hamnar på.

            //Om tiden hamnar på en position som är mindre än 10, dvs bland de tio bästa. 
            if (list.Count == 0 || index < 10)
            {
                Name m_name = new Name(); //Skapar nytt namn

                if (m_name.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string name = m_name.GetName;
                    //Skickar med position, tid och namn. 
                    NewHighscore(index, time, name);
                }
            }
            else //Om tiden inte är bättre än de tio bästa. 
            {
                System.Windows.Forms.MessageBox.Show("Congratulations!" + Environment.NewLine + "You solved the Sudoku but not in a time good enough to make it to the highscorelist." + Environment.NewLine + "Please try again!", "Congratulations!");  
            }
        }
        /// <summary>
        /// Lägger in tiden i highscorelistan. 
        /// </summary>
        /// <param name="index">Positionen</param>
        /// <param name="time">Tiden</param>
        /// <param name="name">Namnet</param>
        public void NewHighscore(int index, double time, string name)
        {
            //Om index är större eller lika med noll, men mindre än listans längd
            if (index >= 0 && index < list.Count)
            {
                //Lägg in namn+tid på position index i listan. 
                list.Insert(index, name+ ";" + time);
            }
            else //Om index är sist
            {
                //Lägg till namn+tid i slutet
                list.Add(name + ";" + time);
            }

            //Skriver in den nya listan i highscore.txt
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < 10 && i < list.Count; i++)
            {
                sw.WriteLine(list[i]);
            }
            
            sw.Close();
            //Öppnar highscorelist och skriver ut listan. 
            HighscoreList hsl = new HighscoreList();
            hsl.Show();
            
            hsl.PrintHighscore(list);
        }

        /// <summary>
        /// Jämför tiderna
        /// </summary>
        /// <param name="time">Tiden som ska jämföras med listan</param>
        /// <returns>En int, positionen som tiden hamnade på</returns>
        private int CompareTimes(double time)
        {
            string[] currentLine;
            double currentTime;
            int index=0;
            foreach (string line in list)
            {
                currentLine = line.Split(';'); //Delar upp varje rad i listan på ;, så man får tid och namn uppdelat
                if (double.TryParse(currentLine[1], out currentTime))
                {
                    //Om tiden är mindre än nuvarande positionen i listan ska index returneras.
                    if (time < currentTime)
                    {
                        return index;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("CurrentTime is not a double");
                }
                index++;
            }
            return index;
        }
        /// <summary>
        /// Skapar defaulthighscore med '---' som namn, och stegvis ökande tid. 
        /// </summary>
        public void CreateDefaultHighscore()
        {
            StreamWriter sw = new StreamWriter(path);
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    sw.WriteLine("---;" + (i + 1) * 600);
                }
                else
                {
                    sw.WriteLine("---;" + (((i + 1) * 300)+300));
                }
            }
            sw.Close();
        }

        /// <summary>
        /// Hämtar listan. Läser in filen och returnerar en lista. 
        /// </summary>
        /// <returns>Listan med highscores.</returns>
        public List<string> GetList()
        {
            ReadFile();
            if (list.Count == 0)
            {
                CreateDefaultHighscore();
                ReadFile();
            }
            return list;
        }
    }
}
