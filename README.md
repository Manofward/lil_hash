# Hashing Algorithm

## Introduction
This program is a simple hashing algorithm designed to be accessed through the terminal. It is written in C# and can be used as a starting point for building a hashing algorithm in other programming languages.

## Files Used
### Code Files

1. **Programm.cs**: The main program file that handles the commands.
2. **Cust.cs**: The file that contains the hashing logic.
3. **FileWriter.cs**: The file that handles file I/O operations.
4. **HelpC.cs**: The file that contains the help messages.
5. **CommandFactory.cs**: handles the navigating
6. **Settings.cs**: handles the settings for the programm
7. **TimingAttack.cs**: handles a brute Force Attack

### Data Files
1. **shadow.txt**: The file that stores the hashed values.
2. **Help-help.txt**: The file that contains the help messages.
3. **Help-cust.txt**: The file that contains the help messages for the `cust` command.
4. **Help-store.txt**: The file that contains the help messages for the `store` command.
5. **Help-verify.txt**: The file that contains the help messages for the `verify` command.
1. **Help-timingattack.txt**: This file has the help message for the `timingattack` command.

### Folders
1. **src**: Has the Code Files saved that are compiled
    1. 1. **FileWriter**: Has the Files important for file Usage of the commands
    1. 2. **Hasher**: Has the Hashing Logic saved
    1. 3. **Helper**: Has the source code for the help file Usage
    1. 4. **Main**: Has the main program code saved
    1. 5. **Settings**: Has the Settings code saved
    1. 6. **TimingAttack**: Has the Timing Attack code saved
2. **docs**: Has the Help Files contained 
3. **bin**: has the release build saved

## using the project:
### Developing the Code:

* `dotnet run cust <input>`: Hashes the input value and displays the result.
* `dotnet run cust <input> <number>`: Hashes the input value with a specified length (up to 64).
* `dotnet run verify <input>`: Verifies the input value against the stored hash.
* `dotnet run store '<hashed input>'`: Saves the hashed input to the `shadow.txt` file.
* `dotnet run help`: Displays the help messages.
* `dotnet run help <command>`: Displays the help message for a specific command.
* `dotnet run timingattack <input>`: Makes a Brute Force attack until the hash is the same and gives out the input you provided.

### Using the Release Build on Windows:

* `Hashing.exe cust <input>`: Hashes the input value and displays the result.
* `Hashing.exe cust <input> <number>`: Hashes the input value with a specified length (up to 64).
* `Hashing.exe verify <input>`: Verifies the input value against the stored hash.
* `Hashing.exe store "<hashed input>"`: Saves the hashed input to the `shadow.txt` file.
* `Hashing.exe help`: Displays the help messages.
* `Hashing.exe help <command>`: Displays the help message for a specific command.
* `Hashing.exe timingattack <input>`: Makes a Brute Force attack until the hash is the same and gives out the input you provided

### Using the Release Build on Linux:

* `./Hashing cust <input>`: Hashes the input value and displays the result.
* `./Hashing cust <input> <number>`: Hashes the input value with a specified length (up to 64).
* `./Hashing verify <input>`: Verifies the input value against the stored hash.
* `./Hashing store "<hashed input>"`: Saves the hashed input to the `shadow.txt` file.
* `./Hashing help`: Displays the help messages.
* `./Hashing help <command>`: Displays the help message for a specific command.
* `./Hashing timingattack <input>`: Makes a Brute Force attack until the hash is the same and gives out the input you provided


## How it Works
The program uses the `Cust.cs` file to hash the input values and the `FileWriter.cs` file to handle file I/O operations. The `Programm.cs` file handles the commands and interacts with the `Cust.cs` and `FileWriter.cs` files.
in the Settings.cs the app.config File will be used to get the SaltIncrement for the hash Function

The Timing Attack works with a input thats hashed and looks for the value you inputed which can take very long. and it iterates over it so long untli it has a guess

### Cust Command

* Hashes the input value and displays the result.
* Can take an optional length parameter to generate a longer hash.

### Store Command

* Saves the hashed input to the `shadow.txt` file.
* Overwrites the previous file contents.

### Verify Command

* Hashes the input value and compares it to the stored hash.
* Displays a success or failure message based on the comparison result.

### Help Command

* Shows the commands in the terminal and how to use them

### timingattack Command

* makes simulates a brute force attack which gives back the unhashed password

## Good to Know
* The length of the input values is important, as it affects the hashing process.
* The program uses the `args` array to parse the command-line arguments.

## Factory design pattern
The project uses the Factory design pattern: **Programm.cs** asks a CommandFactory for an implementation of a command `interface` and receives a concrete command (for example **Cust**) to execute.



## Future Planning
* Updating **Settings.cs** File with new Settings to set
* adding a settings command to change the settings

#### Security 
* Adding more security      (eingabe beim Help command kann man mit einer injection auf andere Files zugreifen)
* Side-channel-attacks      (attack and safety against)
* Hash Function collision attack


## Important Notes
> it does already give for Windows and Linux a fully Compiled Program.

**DO NOT USE THIS ALGORITHM FOR PRODUCTION USE. IT'S ONLY FOR FUN.**