using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hashing.src.Hasher;
using Hashing.src.Settings;


namespace Hashing.src.TimingAttack
{
    public class TimingAttack : ITimingAttack 
    {
        // as long as i dont know how to let _cust or _settings get passed with all the functions i have to do it like that
        private readonly ICust _cust;
        private readonly ISettings _settings;

        public TimingAttack()
        {
            _cust = new Cust();
            _settings = new Settings.Settings();
        }

        public string RecoverPassword(string input)
        {
            var saltIncrement = _settings.ReadSettingSaltincrement("SaltIncrement");
            string password = input; // Use the input password

            // Initialize a StringBuilder to hold the recovered password
            StringBuilder sb = new StringBuilder();

            // Loop through each character position in the password
            for (int i = 0; i < password.Length; i++)
            {
                // Initialize a variable to hold the maximum timing difference
                long maxDiff = 0;

                // Initialize a variable to hold the most likely character
                char mostLikelyChar = '\0';

                // Loop through each possible character
                for (char c = '!'; c <= '~'; c++)
                {
                    string guess = sb.ToString() + c;

                    /*
                     The Stopwatch is important for the time it takes for the function to hash the input
                     the bigger the diff is which is gotten from the elapsed time it took to hash the input
                     the likelier it is that the mostlikely character is true
                     */

                    Stopwatch sw = Stopwatch.StartNew();
                    string hash = _cust.Hash(input, "", saltIncrement);
                    sw.Stop();

                    long diff = sw.Elapsed.Ticks;

                    // Update the maximum timing difference and most likely character
                    if (diff > maxDiff)
                    {
                        maxDiff = diff; 
                        mostLikelyChar = c;
                    }
                }

                // Check if the guessed character is correct
                if (mostLikelyChar == password[i])
                {
                    // Add the correct character to the recovered password
                    sb.Append(mostLikelyChar);
                }
                else
                {
                    // If the guessed character is not correct, try again
                    i--;
                }
            }

            // Return the recovered password
            return sb.ToString();
        }
    }
}
