// Define an interface for commands

namespace Hashing.src.Main
{
    public interface ICommand
    {
        void Execute(string[] args);
    } 
}