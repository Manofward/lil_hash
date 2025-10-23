using System;
using System.Configuration;

namespace Hashing.src.Settings
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