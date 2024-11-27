using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToDoListTestProject
{
    internal class ConsoleToDoTXTHandler
    {

        private readonly string pathToDoList = @".\ToDoList.txt";
        public ConsoleToDoTXTHandler()
        {
        }
        public void ShowToDoList()
        {
            if (File.Exists(pathToDoList))
            {
                using (StreamReader reader = new StreamReader(pathToDoList))
                {
                    string[] ReadAllLines = File.ReadAllLines(pathToDoList);
                    foreach (string ReadLine in ReadAllLines)
                    {
                        Console.WriteLine(ReadLine);
                    }
                }
            }
        }
    }
}
