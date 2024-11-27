using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoListTestProject
{
    internal class ViewHandler
    {
        private string consoleGlobalArguments;
        private string consoleCommand;
        private string consoleArguments;
        private readonly string pathUserName = @".\UserName.txt";
        private string userName;
        private bool programmStarted = false;//make true after command /start
        ConsoleToDoTXTHandler consoleToDoTXTHandler;

        public ViewHandler()
        {
            consoleGlobalArguments = new string("");
            consoleCommand = new string("");
            consoleArguments = new string("");

            if (File.Exists(pathUserName))
            {
                using (StreamReader reader = new StreamReader(pathUserName))//Reading saved username
                {
                    string inputText = reader.ReadLine();
                    if (inputText != null && inputText != "")
                    {
                        userName = inputText;
                    }
                    else
                    {
                        userName = new string("");
                    }
                }
            }
        }
        public void InputAwaiter()
        {
            bool exitFlag = false;//false is meaning not exit circle

            do
            {
                if (!programmStarted)//сделать нормальную обработку после получения команды /start
                {
                    if (userName == "")
                    {
                        Console.WriteLine("Please input comand \"/start\", \"/help\", \"/info\", \"/exit\".");
                    }
                    else
                    {
                        Console.WriteLine("Hello " + userName + ", please input comand \"/start\", \"/help\", \"/info\", \"/exit\".");
                    }
                    consoleGlobalArguments = Console.ReadLine();
                }
                else
                {
                    if (userName == "")
                    {
                        Console.WriteLine("Please input comand \"/start\", \"/help\", \"/info\", \"/echo\", \"/exit\".");
                    }
                    else
                    {
                        Console.WriteLine("Hello " + userName + ", please input comand \"/start\", \"/help\", \"/info\", \"/echo\", \"/exit\".");
                    }
                    consoleGlobalArguments = Console.ReadLine();
                }


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
            switch (consoleCommand)//сделать два свича для programmStart с true и false
            {
                case "start":
                    CommandStart();
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
                case string tempstring when tempstring == "echo" && programmStarted:
                    CommandEcho();
                    break;
                case string tempstring when tempstring == "ShowToDoList" && programmStarted:
                    consoleToDoTXTHandler.ShowToDoList();
                    break;
                case string tempstring when tempstring == "AddTaskToDoList" && programmStarted:
                    consoleToDoTXTHandler.AddTaskToDoList();
                    break;
                case string tempstring when tempstring == "RemoveTaskToDoList" && programmStarted:
                    consoleToDoTXTHandler.RemoveTaskToDoList();
                    break;
                default:
                    Console.WriteLine("There is no such command like \"" + consoleCommand + '\"');
                    break;
            }
            return false;
        }
        /// <summary>
        /// Console write arguments after command \echo
        /// </summary>
        private void CommandEcho()
        {
            Console.WriteLine(consoleArguments);
        }
        /// <summary>
        /// Console write verion and data creation of programm
        /// </summary>
        private void CommandInfo()
        {
            Console.WriteLine("Program version: 0.2 console app");
            Console.WriteLine("Data creation: 26.11.24");
            //Assembly.GetExecutingAssembly().FullName;//добавить парсер имени и версии
        }
        /// <summary>
        /// Console write arguments after command \echo
        /// </summary>
        private void CommandHelp()
        {
            switch (consoleArguments)//сделать два свича для programmStart с true и false
            {
                case "":
                    Console.WriteLine("To use the program, press the command with the \"/\" symbol, showed at the beginning of the program.");
                    break;
                case "/start":
                    Console.WriteLine("/start get name from user");//Сделать внятное описание
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
                case string tempstring when tempstring == "/echo" && programmStarted:
                    Console.WriteLine("/echo write to console arguments after command \\echo");
                    break;
                default:
                    Console.WriteLine("There is no such command like \"" + consoleArguments + '\"');
                    break;
            }
        }
        /// <summary>
        /// Get userName from user and start programm;
        /// </summary>
        private void CommandStart()//сделать нормальную обработку имени если пусто зарание, а не в методе присвоения имени
        {
            programmStarted = true;
            consoleToDoTXTHandler = new ConsoleToDoTXTHandler();
            Console.WriteLine("Programm start.");//сделать нормальное описание старта программы


            if (userName == "")
            {
                Console.WriteLine("Hello unnamed user, please inpute your name");
                string inputText = Console.ReadLine();
                SetNewUserName(inputText);
            }
            else
            {
                Console.WriteLine("Hello " + userName + ", if your name is not " +
                    userName + ", input your new name, or just press enter to continue.");

                string inputText = Console.ReadLine();
                SetNewUserName(inputText);
            }
        }
        private void SetNewUserName(string newUserName)
        {
            if (newUserName != "" && newUserName != null)
            {
                userName = newUserName;
                Console.WriteLine("Now your you name is " + userName);
                using (StreamWriter writer = new StreamWriter(pathUserName, false))//Добавить обработку, если файл не может создасться
                {
                    writer.WriteLine(userName);
                }
            }

        }
    }
}
