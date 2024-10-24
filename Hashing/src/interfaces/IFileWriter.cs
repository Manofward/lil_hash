using Hashing.src;

namespace Hashing.src.interfaces
{
    public interface IFileWriter
    {
        string Load();
        void Save(string storedhash);
    }
}