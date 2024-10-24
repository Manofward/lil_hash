// Define an interface for commands

namespace Hashing.src.interfaces
{
    public interface ICommand
    {
        void Execute(string[] args);
    } 
}