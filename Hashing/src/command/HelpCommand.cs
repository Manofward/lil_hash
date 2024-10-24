using Hashing.src;
using Hashing.src.interfaces;

namespace Hashing.src.command
{
    public class HelpCommand : ICommand
    {
        private readonly IHelp _help;

        public HelpCommand()
        {
            _help = new HelpC();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 2)
            {
                _help.Help(args[1]);
            }
            else
            {
                _help.Help(args[0]);
            }
        }
    }
}