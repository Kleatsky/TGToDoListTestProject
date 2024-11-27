using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoListTestProject
{
    internal class ViewHandler
    {
        private string consoleGlobalArguments;
        private string consoleCommand;
        private string consoleArguments;

        public ViewHandler()
        {
            consoleGlobalArguments = new string("");
        }
        public void InputAwaiter()
        {
            bool exitFlag = false;//false is meaning not exit circle
            do
            {
                Console.WriteLine("Please input comand \"/start\", \"/help\", \"/info\", \"/exit\".");
                consoleGlobalArguments = Console.ReadLine();

                if (consoleGlobalArguments != null && consoleGlobalArguments.Length >= 4)
                {
                    if (consoleGlobalArguments[0] == '/')
                    {
                        consoleGlobalArguments = consoleGlobalArguments.Substring(1);//remove '/' from begin
                        consoleCommand = GettingCommandFromArguments();
                        consoleArguments = GettingArgumentsForCommandFromGlobalArguments();

                        //обработчик аргументов с вызовом

                        exitFlag = ArgumentHandler();
                    }
                    else
                    {
                        Console.WriteLine("Input command begin with /, please input correct command");
                    }
                }
                else if (consoleGlobalArguments == null)
                {
                    Console.WriteLine("String are empty, please input correct command");
                }
                else if (consoleGlobalArguments.Length < 4)
                {
                    Console.WriteLine("String too short, please input correct command");
                }
                else
                {
                    Console.WriteLine("String input incorrect, please input correct command");
                }
            } while (!exitFlag);

        }
        private string GettingCommandFromArguments()
        {
            int PositionOfSpace = consoleGlobalArguments.IndexOf(' ');
            return PositionOfSpace >= 0 ? consoleGlobalArguments.Substring(0, PositionOfSpace) : consoleGlobalArguments;
        }
        private string GettingArgumentsForCommandFromGlobalArguments()
        {
            int PositionOfSpace = consoleGlobalArguments.IndexOf(' ');
            return PositionOfSpace >= 0 ? consoleGlobalArguments.Substring(PositionOfSpace + 1) : "";
        }
        private bool ArgumentHandler()//Переписать чтобы вместо возврата bool было по нормальному
        {
            //реализовать проверку первой команды с вызовом их методов
            switch (consoleCommand)
            {
                case "start":
                    break;
                case "help":
                    CommandHelp();
                    break;
                case "info":
                    CommandInfo();
                    break;
                case "exit":
                    Console.WriteLine("Exit from program");
                    return true;
                case "echo":
                    CommandEcho();
                    break;
                default:
                    Console.WriteLine("There is no such command like \"" + consoleCommand + '\"');
                    break;
            }
            return false;
        }
        private void CommandEcho()//Console write arguments after command \echo
        {
            Console.WriteLine(consoleArguments);
        }
        private void CommandInfo()//Console write verion and data creation of programm
        {
            Console.WriteLine("Program version: 0.2 console app");
            Console.WriteLine("Data creation: 26.11.24");
        }
        private void CommandHelp()//Console write arguments after command \echo
        {
            switch(consoleArguments)
            {
                case "":
                    Console.WriteLine("/help show information about commands");//Сдалять внятное описание
                    break;
                case "/start":
                    Console.WriteLine("/start");//Need to complite
                    break;
                case "/help":
                    Console.WriteLine("/help show information about commands");//Сдалять внятное описание
                    break;
                case "/info":
                    Console.WriteLine("/info show information about verion and data creation of programm");
                    break;
                case "/exit":
                    Console.WriteLine("/exit command to close programm");
                    break;
                case "/echo":
                    Console.WriteLine("/echo write to console arguments after command \\echo");
                    break;
                default:
                    Console.WriteLine("There is no such command like \"" + consoleArguments + '\"');
                    break;
            }
        }
    }
}
