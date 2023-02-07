using ToDoList.Interfaces;

namespace ToDoList
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public virtual void WriteLineWrapper(string message)
        {
            Console.WriteLine(message);
        }

        public virtual string ReadLineWrapper()
        {
            return Console.ReadLine() ?? string.Empty; ;
        }
    }
}
