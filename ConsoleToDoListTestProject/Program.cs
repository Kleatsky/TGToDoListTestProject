namespace ConsoleToDoListTestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ViewHandler viewhandler = new ViewHandler();
            viewhandler.InputAwaiter();

            Console.WriteLine("Program complite!");
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}
