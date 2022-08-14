using System.Data;
using Lesson1.Controller;
using Lesson1.Helper;

namespace Lesson1.View
{
    internal sealed class Program
    {
        private const string PROMPT = "Enter a command";

        private static IController _controller;
        private static Dictionary<string, string> _commands;
        
        static void Main(string[] args)
        {
            _controller = new Controller.Controller();

            _commands = _controller.Commands;
            _commands.Add("help", "Show all commands");
            _commands.Add("clear", "Clear terminal");
            _commands.Add("exit", "Close application");
            
            CommandWaiting();
        }

        private static void CommandWaiting()
        {
            var parameters = new Dictionary<int, List<PersonParameter>>();

            while (true)
            {
                var command = GetCommand();

                if(!CommandValidate(command)) continue;
                
                switch (command.Split(' ')[0])
                {
                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "help":
                        ShowCommands();
                        break;
                    case "add":
                        Add();
                        break;
                    case "show":
                        Show(command);
                        break;
                    default:
                        SendCommand(command, ref parameters);
                        break;
                }
            }
        }

        private static void ShowCommands()
        {
            foreach (var command in _commands)
            {
                Console.WriteLine($"Command: {command.Key} | Description: {command.Value}");
            }
        }

        private static void Add()
        {
            var personParameters = _controller.PersonParameters.ToArray();
            string parameter;
            string message;
            bool isChecked;

            for (int i = 0; i < personParameters.Count(); i++)
            {
                do
                {
                    Console.Write($"Insert a {personParameters[i].Name}: ");
                    parameter = Console.ReadLine();

                    isChecked = DataValidator.DataValidator.Validate(parameter, personParameters[i].ValidateMethod, out message);

                    if (!isChecked) Console.WriteLine($"{message}\n");

                } while (!isChecked);

                personParameters[i].Value = parameter;
            }
            
            var param = new Dictionary<int, List<PersonParameter>> { { 0, personParameters.ToList() } };

            SendCommand("add", ref param);
        }

        private static void Show(string command)
        {
            var personParameters = new Dictionary<int, List<PersonParameter>>();

            if (!SendCommand(command, ref personParameters)) return;
            
            if (personParameters.Count == 0)
            {
                Console.WriteLine("Nothing found");
                return;
            }

            var parameters = (from p in personParameters where p.Key > 0 select p).ToList();

            foreach (var id in personParameters.Keys)
            {
                Console.WriteLine($"{personParameters[id].First(x => x.Name == "Firstname").Value} " +
                                  $"{personParameters[id].First(x => x.Name == "Lastname").Value} " +
                                  $"(ID: {id}):");

                foreach (var parameter in personParameters[id].OrderBy(x => x.Position))
                {
                    Console.WriteLine($"{parameter.Name}: {parameter.Value}");
                }

                Console.WriteLine("\n");
            }

            
        }

        private static bool SendCommand(string command, ref Dictionary<int, List<PersonParameter>> personParameters)
        {
            var responseMessage = String.Empty;
            
            var success = _controller.Execute(command, out responseMessage, ref personParameters);

            responseMessage = success
                ? responseMessage
                : $"An error occurred while executing the command \"{command}\".\nError message: {responseMessage}";

            Console.WriteLine($"{responseMessage}\n");

            return success;
        }
        
        private static string GetCommand(string? prompt = null)
        {
            prompt = prompt ?? PROMPT;
            Console.Write(prompt + ": ");

            return Console.ReadLine();
        }

        private static bool CommandValidate(string command)
        {
            var keys = _commands.Keys.ToList().Select(x => x.Split(' ')[0]).ToList();

            var result = keys.Contains(command.Split(' ')[0]);

            if (!result)
            {
                Console.WriteLine($"The entered command \"{command}\" is incorrect. Type \"help\" for a list of available commands.");
            }

            return result;
        }
    }
}