namespace Hashing.src.interfaces 
{
    public interface ICommandFactory
    {
        ICommand Create(string commandName);
    } 
}