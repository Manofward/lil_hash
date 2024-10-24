using Hashing.src.Attacks;
using Hashing.src.interfaces;
using Hashing.src;

namespace Hashing.src.command
{
    public class TimingAttackCommand : ICommand
    {
        private readonly ITimingAttack _timingattack;

        public TimingAttackCommand()
        {
            _timingattack = new TimingAttack();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 2)
            {
                var recoveredPassword = _timingattack.RecoverPassword(args[1]);
                Console.WriteLine("Recovered Password: " + recoveredPassword);
            }
            else
            {
                Console.WriteLine("Invalid arguments for the 'timingattack' command.");
            }
        }
    }
}
