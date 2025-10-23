# Class Dictionary
----------------------

## Introduction

This File lists all classes that are used in which file and with somekind of explanation what they do
Also it contains all Folder names with what they have inside.

## Dictionary

## Folders
1. ### src
	Here are all code Files saved
    
1. 1. #### FileWriter
        Here are the files for the File Writing and Loading from the shadow.txt file
1. 2. #### Hasher
	    Here are the files for the Hashing and Salting of the passwords
1. 3. #### Helper
	    This folder contains the source Code for the Help Command
1. 4. #### Settings
        Here is the source code for the Settings management
1. 5. #### Main
        This folder contains the main Program.cs file and the Application class
1. 6. #### TimingAttack
        Here is the source code for the Timing Attack implementation

-----------------------

## Namespaces
1. ### Hashing.src.FileWriter
	* **FileWriter.cs**
	* **IFileWriter.cs**
	* **StoreCommand.cs**
	* **VerifyCommand.cs**

2. ### Hashing.src.Hasher
	* **Cust.cs**
	* **CustCommand.cs**
	* **ICust.cs**

3. ### Hashing.src.Helper
	* **HelpC.cs**
    * **HelpCommand.cs**
    * **IHelp.cs**
    
4. ### Hashing.src.Main
    * **CommandFactory.cs**
    * **ICommand.cs**
    * **ICommandFactory.cs**
    * **Program.cs**

5. ### Hashing.src.Settings
    * **ISettings.cs**
    * **Settings.cs**

6. ### Hashing.src.TimingAttack
    * **ITimingAttack.cs**
    * **TimingAttack.cs**
    * **TimingAttackCommand.cs**

--------

## Files

1. ### Program.cs
	#### 1.1 Program
	> This class runs the whole programm
	
	```cs
	public static class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application();
            app.Run(args);
        }
    }
	```
	This code snippet creates a new object from **Application** and Runs the Program.

	#### 1.2 Application
	> this class initializes the everthing inside of the programm file and has the **"Run"** Function

	```cs
	public class Application 
    {
        private readonly ICommandFactory _commandFactory;

        public Application()
        {
            _commandFactory = new CommandFactory();
        }

        public void Run(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No command provided. Please try the 'help' command for available options.");
                return;
            }

            var command = _commandFactory.Create(args[0]);
            if (command == null)
            {
                Console.WriteLine($"The command '{args[0]}' does not exist. Please try the 'help' command for available options.");
                return;
            }

            command.Execute(args);
        }
    }
	```
	At first we use the interface ICommandFatcory as a readonly to create a new Object of it in the constructor.
	Then in the Run Function we use the `args` from the Main Function that we get as a parameter ask if a command like `cust`, `store` etc. was added to the command
	and if there is a command added it does give out one of the Errors if something is wrong.

2. ### Cust.cs
	#### 2.1 Cust
	> This class has the Functions **"Hash"**, **"Salt"** and **"Verify"** inside of them

	The code below has the Hash Funktion
	```cs 
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
	```
	This Function creates the **Hash** with a new random generated **Salt** from the Function `Salt` which is further down with more detail.
	Then we have a stringbuilder in which we build the Hash bit by bit.
	In the for loop the stringuilder variable becomes the characters added behind the last for this we used the **Append** Function.

	In the second for loop everything will be scrambled and returned in the end.

	--------------

	Here is the Explanation of the Salt Function
	```cs
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
	```
	At first are we using it under create a radnom number and adding them to the password and it will be hashed with it and in the last step added to the hash with a dot.

	----

	Now comes the explanation of the Verify Function
	```cs
	public bool Verify(string input, string storedhash)
     {
		// Hash the provided password and compare it to the stored hash
        return storedhash == Hash(input, storedhash.Split('.')[1]);
     }
	```
	This Function gives back the input password and the stored hash in **shadow.txt** and will be in another File be validated.


3. ### FileWriter.cs
	#### 3.1 FileWriter
	> this class has the Functions **"Load"** and **"Save"**

	The Save Function of the FileWriter class just writes the hashed password to the file **shadow.txt**.

	The Load Function on the other hand loads the data from the **shadow.txt** file to a variable and then returns it when it will be validated.
	```cs
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
	```
	like seen here.

4. ### HelpC.cs
	#### 4.1 HelpC
	> this class has the **"Help"** and **"ShowHelp"** Function

	The function Help consists of the following points:
	```cs
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
	```

    At first we do give the Help Function the parameter from the **Program.cs** Run function.
    Which is queried if it has nothing in it.    If it has something in it the ShowHelp function will be used and if nothing is in it then the normal help message is shown.
    
    ---
    The ShowHelp function is shown if the command variable has a command in it.
    ```cs
    private void ShowHelp(string command)
    {
         string filename = Path.GetFileName(command);
         using StreamReader reader = new($"docs/HelpOut/Help-{filename}.txt");
         string text = reader.ReadToEnd();
         Console.WriteLine(text);
     }
    ``` 
    We get from the Help function the command variable and uses the StreamReader to read the text from files to a variable which is then put out.

5. ### Settings.cs 
	#### 5.1 Settings
	> this class has the **"SaltIncrement"** and **ReadSetting** Function

    ```cs
    public int ReadSettingSaltincrement(string key)
    {
         try
         {
             SaltIncrement = int.Parse(ConfigurationManager.AppSettings[key]);
             return SaltIncrement;
         }
         catch (ConfigurationErrorsException)
         {
             Console.WriteLine("Error reading app setting Salt increment");
             return 0;
         }
    }
    ```
    It reads **app.config** file to the variable SaltIncrement using the ConfigurationManager to try to parse it.
    else a Error message will be shown. 

---------

6. ### CommandFactory.cs
	> has the **"Create"** Function inside and manages the command class usage

    the CommandFactory class Creates from the given command a Object which will be later executet with the Command.cs files.

7. ### VerifyCommand.cs
	> this class executes in the end the function **"Verify"** from *Cust.cs*

    The VerifyCommand class uses the ICommand interface to create one Object which will be executed by the **Program.cs**.
    ```cs
        private readonly IFileWriter _fileWriter;
        private readonly ICust _cust;

        public VerifyCommand()
        {
            _fileWriter = new FileWriter();
            _cust = new Cust();
        }

        public void Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments for the 'verify' command.");
                return;
            }

            string loaded = _fileWriter.Load();
            if (loaded.Equals(""))
            {
                Console.WriteLine("Cust: no hash in shadow.txt");
            }
            else
            {
                Console.WriteLine("Cust: " + (_cust.Verify(args[1], loaded) == false ?
                    "Failed to authenticate" : "succeeded in authenticating"));
            }
        }
    ```
    Here you can see that the constructor creates the object which will be used to execute and output the result.

8. ### CustCommand.cs
	> this class uses the hashing functions from *Cust.cs*

    ```cs
        private readonly ICust _cust;
        private readonly ISettings _settings;
        public CustCommand()
        {
            _cust = new Cust();
            _settings = new Settings();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 3)
            {
                Console.WriteLine("Cust: " + args[1] + " -> " + _cust.Hash(args[1], "", int.TryParse(args[2], out int i) ? i > 0 ? i : 0 : 0));
            }
            else if (args.Length == 2)
            {
                var saltIncrement = _settings.ReadSettingSaltincrement("SaltIncrement");
                Console.WriteLine("Cust: " + args[1] + " -> " + _cust.Hash(args[1], "", saltIncrement));
            }
            else
            {
                Console.WriteLine("Invalid arguments for the 'cust' command.");
            }
        }
    ```
    Shown here it has the constructor to create the used objects and executes it later when used.

9. ### StoreCommand.cs
	> this class uses the **"Load"** and **"Save"** Function from *FileWriter.cs*

    ```cs
        private readonly IFileWriter _fileWriter;

        public StoreCommand()
        {
            _fileWriter = new FileWriter();
        }

        public void Execute(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Invalid arguments for the 'store' command.");
                return;
            }

            _fileWriter.Save(args[1]);
            Console.WriteLine("Cust: Stored hash " + args[1]);
        }
    ```
    it is the same mostly like the other Command files.

10. ### HelpCommand.cs
	> this class uses the **"Help"** Function from *HelpC.cs*

    ```cs
        private readonly IHelp _help;

        public HelpCommand()
        {
            _help = new HelpC();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 2)
            {
                _help.Help(args[1]);
            }
            else
            {
                _help.Help(args[0]);
            }
        }
    ```
    here it is different because the Error message itself does not exists and the output is in the HelpC File itself.

11. ### TimingAttackCommand.cs
	> this class uses the **"RecoverPassword"** Function from *TimingAttack.cs*

    ```cs
        private readonly ITimingAttack _timingattack;

        public TimingAttackCommand()
        {
            _timingattack = new TimingAttack();
        }

        public void Execute(string[] args)
        {
            if (args.Length == 2)
            {
                var recoveredPassword = _timingattack.RecoverPassword(args[1]);
                Console.WriteLine("Recovered Password: " + recoveredPassword);
            }
            else
            {
                Console.WriteLine("Invalid arguments for the 'timingattack' command.");
            }
        }
    ```
    here is the normal form like the other Command files.

-------------

12. ### ICommand.cs
	> has the interface 

13. ### ICommandFactory.cs
	> has the interface

14. ### ICust.cs
	> has the interface

15. ### IFileWriter.cs
	> has the interface

16. ### IHelp.cs
	> has the interface

17. ### ISettings.cs
	> has the interface for the *Settings.cs*

18. ### ITimingAttack.cs
	> has the interface for the *TimingAttack.cs*

------------

19. ### TimingAttack.cs
	> this class has the *RecoverPassword* Function 

    ```cs
    public class TimingAttack : ITimingAttack 
    {
        // as long as i dont know how to let _cust or _settings get passed with all the functions i have to do it like that
        private readonly ICust _cust;
        private readonly ISettings _settings;

        public TimingAttack()
        {
            _cust = new Cust();
            _settings = new Settings();
        }

        public string RecoverPassword(string input)
        {
            var saltIncrement = _settings.ReadSettingSaltincrement("SaltIncrement");
            string password = input; // Use the input password

            // Initialize a StringBuilder to hold the recovered password
            StringBuilder sb = new StringBuilder();

            // Loop through each character position in the password
            for (int i = 0; i < password.Length; i++)
            {
                // Initialize a variable to hold the maximum timing difference
                long maxDiff = 0;

                // Initialize a variable to hold the most likely character
                char mostLikelyChar = '\0';

                // Loop through each possible character
                for (char c = '!'; c <= '~'; c++)
                {
                    string guess = sb.ToString() + c;

                    /*
                     The Stopwatch is important for the time it takes for the function to hash the input
                     the bigger the diff is which is gotten from the elapsed time it took to hash the input
                     the likelier it is that the mostlikely character is true
                     */

                    Stopwatch sw = Stopwatch.StartNew();
                    string hash = _cust.Hash(input, "", saltIncrement);
                    sw.Stop();

                    long diff = sw.Elapsed.Ticks;

                    // Update the maximum timing difference and most likely character
                    if (diff > maxDiff)
                    {
                        maxDiff = diff; 
                        mostLikelyChar = c;
                    }
                }

                // Check if the guessed character is correct
                if (mostLikelyChar == password[i])
                {
                    // Add the correct character to the recovered password
                    sb.Append(mostLikelyChar);
                }
                else
                {
                    // If the guessed character is not correct, try again
                    i--;
                }
            }

            // Return the recovered password
            return sb.ToString();
        }
    }
    ```
    Here is the code for the attack which is more like a brute force attack because it test different passwords until a hashed password is the same as the input password.

**THIS FILE HAS TO BE UPDATE WHEN AN NEW FILE WITH NEW CLASSES IS CREATED OR A NEW FUNCTION HAS BEEN CREATED**