using System;
using System.Configuration;
using System.ComponentModel.Design;
using System.IO;
using System.Diagnostics;
using Hashing.src.interfaces;
using Hashing.src.command;

namespace Hashing.src
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application();
            app.Run(args);
        }
    }

    // Define a class for the application
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
}