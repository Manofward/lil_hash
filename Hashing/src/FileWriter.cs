// Import necessary namespaces for security, text, and file operations
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Hashing.src.interfaces;

// Define a namespace for the hashing program
namespace Hashing.src
{
    // Define a public static class for file writing and reading
    public class FileWriter : IFileWriter
    {
        // Define a method to save data to a file
        public void Save(string data)
        {
            // Use the File.WriteAllText method to write the data to a file named "shadow.txt"
            // This will overwrite any existing file with the same name
            File.WriteAllText("shadow.txt", data);
        }

        // Define a method to load data from a file
        public string Load()
        {
            // Initialize an empty string to hold the loaded data
            string temp = "";

            // Check if a file named "shadow.txt" exists
            if (File.Exists("shadow.txt"))
            {
                // If the file exists, read its contents into the temp string
                temp = File.ReadAllText("shadow.txt");
            }

            // Return the loaded data
            return temp;
        }
    }
}
