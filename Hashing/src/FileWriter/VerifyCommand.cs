// defining the updated namespaces
using Hashing.src.Hasher;
using Hashing.src.Main;

namespace Hashing.src.FileWriter
{
    public class VerifyCommand : ICommand
    {
        private readonly IFileWriter _fileWriter;
        private readonly ICust _cust;

        public VerifyCommand()
        {
            _fileWriter = new FileWriter();
            _cust = new Cust();
        }

        public void Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments for the 'verify' command.");
                return;
            }

            string loaded = _fileWriter.Load();
            if (loaded.Equals(""))
            {
                Console.WriteLine("Cust: no hash in shadow.txt");
            }
            else
            {
                Console.WriteLine("Cust: " + (_cust.Verify(args[1], loaded) == false ?
                    "Failed to authenticate" : "succeeded in authenticating"));
            }
        }
    }
}