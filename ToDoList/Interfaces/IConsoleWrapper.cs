namespace ToDoList.Interfaces
{
    public interface IConsoleWrapper
    {
        string ReadLineWrapper();
        void WriteLineWrapper(string message);
    }
}