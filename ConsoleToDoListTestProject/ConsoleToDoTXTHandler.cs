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
    public class ConsoleToDoTXTHandler
    {

        private readonly string pathToDoList = @".\ToDoList.txt";
        private List<string> toDoList; 
        public ConsoleToDoTXTHandler()
        {

            if (File.Exists(pathToDoList))
            {
                string[] ReadAllLines = File.ReadAllLines(pathToDoList);
                toDoList = new List<string>(ReadAllLines.Length);
                foreach (string ReadLine in ReadAllLines)
                {
                    toDoList.Add(ReadLine);
                }
            }

        }
        public void ShowToDoList()
        {
            if (toDoList.Count == 0 || toDoList == null)
            {
                Console.WriteLine("ToDoList is empty.");
            }
            else
            {
                foreach (string task in toDoList)
                {
                    Console.WriteLine(task);
                }
            }
        }

        public void AddTaskToDoList()
        {
            if (File.Exists(pathToDoList))
            {
                Console.WriteLine("Write task to add.");
                string newTask = Console.ReadLine();
                if (string.IsNullOrEmpty(newTask))
                {
                    Console.WriteLine("New task is empty");
                }
                else
                {
                    toDoList.Add(newTask);
                    using (StreamWriter writer = new StreamWriter(pathToDoList, true))
                    {
                        writer.WriteLine(newTask);
                        Console.WriteLine("Task \"" + newTask + "\" was added.");
                    }
                }
            }
        }
        public void RemoveTaskToDoList()
        {
            if (toDoList.Count == 0 || toDoList == null)
            {
                Console.WriteLine("ToDoList is empty.");
            }
            else
            {
                int linesCount = toDoList.Count();
                int currentElementIndex = 0;
                int positionDelete;
                foreach (string ReadLine in toDoList)
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
                        positionDelete--;//Because we show index to user started from 1 insted of 0
                        toDoList.RemoveAt(positionDelete);
                        File.WriteAllLines(pathToDoList, toDoList);
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
