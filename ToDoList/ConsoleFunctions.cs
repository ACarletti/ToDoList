using ToDoList.Interfaces;

namespace ToDoList
{
    public class ConsoleFunctions : IConsoleFunctions
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public ConsoleFunctions(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public int ReadLine()
        {
            string input = _consoleWrapper.ReadLineWrapper();

            if (string.IsNullOrEmpty(input))
            {
                throw new Exception("Input cannot be null or empty");
            }

            if (int.TryParse(input, out int result))
            {
                return result;
            }

            throw new Exception("Invalid input. Please enter a valid integer.");
        }

        public string ReadItem()
        {
            return _consoleWrapper.ReadLineWrapper();
        }

        public void WriteLine(string message)
        {
            _consoleWrapper.WriteLineWrapper(message);
        }
    }
}
