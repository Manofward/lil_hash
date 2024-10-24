using System;
using System.Configuration;
using Hashing.src;
using Hashing.src.interfaces;

namespace Hashing.src
{
    public class Settings : ISettings
    {
        public int SaltIncrement { get; set; }
        public int ReadSettingSaltincrement(string key)
        {
            try
            {
                SaltIncrement = int.Parse(ConfigurationManager.AppSettings[key]);
                return SaltIncrement;
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app setting Salt increment");
                return 0;
            }
        }
    }
}