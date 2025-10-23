namespace Hashing.src.Main 
{
    public interface ICommandFactory
    {
        ICommand Create(string commandName);
    } 
}