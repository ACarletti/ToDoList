using Microsoft.Extensions.DependencyInjection;
using ToDoList.Interfaces;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<IToDoList, ToDoList>();
            serviceCollection.AddTransient<IConsoleWrapper, ConsoleWrapper>();
            serviceCollection.AddTransient<IConsoleFunctions, ConsoleFunctions>();
            serviceCollection.AddTransient<IToDoListController, ToDoListController>();
            serviceCollection.AddTransient<IToDoListMenuUI, ToDoListMenuUI>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var toDoListMenuUI = serviceProvider.GetService<IToDoListMenuUI>();
            toDoListMenuUI?.Run();
        }
    }
}
