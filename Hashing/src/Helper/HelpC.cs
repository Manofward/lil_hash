namespace Hashing.src.Helper
{
    class HelpC : IHelp
    {
        public void Help(string command)
        {
            // checks if the second input was one of the following words and gives then out the following Help message
            if (command != null)
            {
                ShowHelp(command);
            }
            else
            {
                using StreamReader reader = new("docs/HelpOut/Help-help.txt");
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
        }

        private void ShowHelp(string command)
        {
            string filename = Path.GetFileName(command);
            using StreamReader reader = new($"docs/HelpOut/Help-{filename}.txt");
            string text = reader.ReadToEnd();
            Console.WriteLine(text);
        }
    }
}
