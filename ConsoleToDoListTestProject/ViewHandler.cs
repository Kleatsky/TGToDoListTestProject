using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoListTestProject
{
    internal class ViewHandler
    {
        private string consoleArguments;
        private string consoleCommand;

        public ViewHandler()
        {
            consoleArguments = new string("");
        }
        public void InputAwaiter()
        {
            Console.WriteLine("Input comand /start, /help, /info, /exit.");
            consoleArguments = Console.ReadLine();

            consoleCommand = GettingCommandFromArguments();

            //обработчик аргументов с вызовом

            ArgumentHandler();

        }
        private string GettingCommandFromArguments()
        {
            consoleArguments = consoleArguments.Substring(1);
            int PositionOfSpace = consoleArguments.IndexOf(' ');
            return PositionOfSpace >= 0 ? consoleArguments.Substring(0, PositionOfSpace) : consoleArguments;
        }
        private void ArgumentHandler()
        {
            //реализовать проверку первой команды с вызовом их методов
            switch (consoleCommand)
            {
                case "start":
                    break;
                case "help":
                    break;
                case "info":
                    break;
                case "exit":
                    Console.WriteLine("Exit from program");
                    break;
                case "echo":
                    break;
                default:
                    break;
            }
        }

    }
}
