namespace Hashing.src.FileWriter
{
    public interface IFileWriter
    {
        string Load();
        void Save(string storedhash);
    }
}