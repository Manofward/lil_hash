using Hashing.src.FileWriter;
using Hashing.src.Hasher;
using Hashing.src.Helper;
using Hashing.src.TimingAttack;

namespace Hashing.src.Main
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand Create(string commandName)
        {
            switch (commandName)
            {
                case "verify":
                    return new VerifyCommand();
                case "cust":
                    return new CustCommand();
                case "store":
                    return new StoreCommand();
                case "timingattack":
                    return new TimingAttackCommand();
                case "help":
                    return new HelpCommand();
                default:
                    return null;
            }
        }
    }
}