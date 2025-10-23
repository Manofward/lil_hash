using Hashing.src.Settings;
using Hashing.src.Main;

namespace Hashing.src.Hasher
{
    public class CustCommand : ICommand
    {
        private readonly ICust _cust;
        private readonly ISettings _settings;
        public CustCommand()
        {
            _cust = new Cust();
            _settings = new Settings.Settings();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 3)
            {
                Console.WriteLine("Cust: " + args[1] + " -> " + _cust.Hash(args[1], "", int.TryParse(args[2], out int i) ? i > 0 ? i : 0 : 0));
            }
            else if (args.Length == 2)
            {
                var saltIncrement = _settings.ReadSettingSaltincrement("SaltIncrement");
                Console.WriteLine("Cust: " + args[1] + " -> " + _cust.Hash(args[1], "", saltIncrement));
            }
            else
            {
                Console.WriteLine("Invalid arguments for the 'cust' command.");
            }
        }
    }
}