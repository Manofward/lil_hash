// Define an interface for the cust class

// Define an interface for the cust class
namespace Hashing.src.Hasher
{
    public interface ICust
    {
        bool Verify(string input, string hash);
        string Hash(string input, string salt, int saltinc);

        string Salt(int saltLength);
    }
}