// Import necessary namespaces for security, text, and file operations
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Hashing.src.interfaces;

// Define a namespace for the hashing program
namespace Hashing.src
{
    // Define a public static class for the program
    public  class Cust : ICust
    {
        // Define a constant string containing a set of characters to use for hashing
        const string chars = 
            "abcdefghijklmnopqrstuvwxyz!@#$%^&+()_+-=[]{}|;:,<>?ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        // Define a method for hashing a password with a salt
        public string Hash(string input, string salt, int saltinc = 0)
        {
            // If no salt is provided, generate a new salt
            if (salt == "") salt = Salt(saltinc > 0 ? saltinc : new Random().Next(32, 64));

            // Calculate the desired length of the hashed password
            int desiredLength = salt.Length % 48 + 16;

            // Initialize a StringBuilder to hold the hashed password
            StringBuilder sb = new StringBuilder();

            // Scramble the input and salt strings together
            for (int i = 0; i < desiredLength; i++)
            {
                sb.Append(chars[(chars.IndexOf(input[i % input.Length]) +
                    chars.IndexOf(salt[i % salt.Length])) % chars.Length]);
            }

            // Repeat the scrambling process 20,000 times
            string scrambledInput = sb.ToString();
            for (int j = 0; j < 20000; j++)
            {
                sb.Clear();

                for (int i = 0; i < desiredLength; i++)
                {
                    sb.Append(chars[(chars.IndexOf(scrambledInput[i % desiredLength]) +
                        chars.IndexOf(salt[i % salt.Length])) % chars.Length]);
                }
            }

            // Return the hashed password as a string in the format "hashed-password.salt"
            return $"{scrambledInput}.{salt}";
        }

        // Define a method for generating a random salt
        public string Salt(int saltLength = 32)
        {
            // Generate a random number of bytes for the salt
            byte[] saltBytes = new byte[(int)Math.Round((double)(saltLength * .5) *
                new Random().NextDouble() + (double)(saltLength * .5f))];

            // Use a random number generator to fill the salt with random bytes
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
                rng.GetBytes(saltBytes);

            // Convert the salt bytes to a string of characters
            StringBuilder sb = new StringBuilder(saltBytes.Length);
            for (int i = 0; i < saltBytes.Length; i++)
            {
                sb.Append(chars[saltBytes[i] % chars.Length]);
            }

            // Return the salt as a string
            return sb.ToString();
        }

        // Define a method for verifying a password against a stored hash
        public bool Verify(string input, string storedhash)
        {
            // Hash the provided password and compare it to the stored hash
            return storedhash == Hash(input, storedhash.Split('.')[1]);
        }
    }
}
