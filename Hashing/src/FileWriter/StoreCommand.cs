using Hashing.src.Main; // adding the updated namespace

namespace Hashing.src.FileWriter
{
    public class StoreCommand : ICommand
    {
        private readonly IFileWriter _fileWriter;

        public StoreCommand()
        {
            _fileWriter = new FileWriter();
        }

        public void Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments for the 'store' command.");
                return;
            }

            _fileWriter.Save(args[1]);
            Console.WriteLine("Cust: Stored hash " + args[1]);
        }
    }
}