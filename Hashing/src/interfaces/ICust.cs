// Define an interface for the cust class
using Hashing.src;
namespace Hashing.src.interfaces
{
    public interface ICust
    {
        bool Verify(string input, string hash);
        string Hash(string input, string salt, int saltinc);

        string Salt(int saltLength);
    }
}