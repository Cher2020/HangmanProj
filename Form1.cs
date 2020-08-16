using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangmanProj
{
    public partial class Hangman : Form



    {
        public char InputBox { get; private set; }

        public Hangman()
        {
            InitializeComponent();
        }

        private void LblChosenLetters_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        


            }
        }

       



        private char InputBox(string v1, string v2, string DefaultResponse = "")
        {
            if (string.IsNullOrWhiteSpace(DefaultResponse))
            {
                throw new ArgumentException("message", nameof(DefaultResponse));
            }

            throw new NotImplementedException();
        }

        private void GuessWord_TextChanged(object sender, EventArgs e)
        {
            

            {
                string[] listwords = new string[20];
                listwords[0] = "sheep";
                listwords[1] = "goat";
                listwords[2] = "computer";
                listwords[3] = "elephant";
                listwords[4] = "giraff";
                listwords[5] = "america";
                listwords[6] = "watermellon";
                listwords[7] = "icecream";
                listwords[8] = "jasmine";
                listwords[9] = "pinapple";
                listwords[10] = "orange";
                listwords[11] = "mango";
                listwords[12] = "chicken";
                listwords[13] = "turkey";
                listwords[14] = "beans";
                listwords[15] = "potatoes";
                listwords[16] = "sharp";
                listwords[17] = "needle";
                listwords[18] = "clothing";
                listwords[19] = "vacation";

                Random randGen = new Random();
                var idx = randGen.Next(0, 19);
                string mysteryWord = listwords[idx];
                char[] guess = new char[mysteryWord.Length];
                Console.Write("Please enter your guess: ");

                for (int p = 0; p < mysteryWord.Length; p++)
                    guess[p] = '*';

                while (true)
                {
                    char playerGuess = char.Parse(Console.ReadLine());
                    for (int j = 0; j < mysteryWord.Length; j++)
                    {
                        if (playerGuess == mysteryWord[j])
                            guess[j] = playerGuess;
                    }
                    Console.WriteLine(guess);

                }
            }
        }
    
    
           