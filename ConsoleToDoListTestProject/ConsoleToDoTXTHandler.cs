using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                string[] ReadAllLines = File.ReadAllLines(pathToDoList);
                foreach (string ReadLine in ReadAllLines)
                {
                    Console.WriteLine(ReadLine);
                }
            }
        }

        public void AddTaskToDoList()
        {

        }
        public void RemoveTaskToDoList()
        {
            if (File.Exists(pathToDoList))
            {
                string[] ToDoList = File.ReadAllLines(pathToDoList);
                int linesCount = ToDoList.Count();
                int currentElementIndex = 0;
                int positionDelete;
                foreach (string ReadLine in ToDoList)
                {
                    currentElementIndex++;
                    Console.WriteLine(currentElementIndex + " " + ReadLine);
                }
                Console.WriteLine("Which task do you want to delite? (enter the number)");
                string tempstring = Console.ReadLine();//заменить tempstring
                bool success = int.TryParse(tempstring, out positionDelete);
                if (!success)
                {
                    Console.WriteLine(tempstring + " is not a number");
                }
                else
                {
                    if (positionDelete < 0 || positionDelete > linesCount)
                    {
                        Console.WriteLine("There is no such the number of task.");
                    }
                    else
                    {
                        positionDelete--;//Becouse we show index to user started from 1 insted of 0
                        List<string> tmp = new List<string>(ToDoList);
                        tmp.RemoveAt(positionDelete);
                        ToDoList = tmp.ToArray();
                        File.WriteAllLines(pathToDoList, ToDoList);
                    }
                }
            }
        }
        public void CheckTaskToDoList()
        {
        }
        public void EditTaskToDoList()
        {

        }
    }
}
