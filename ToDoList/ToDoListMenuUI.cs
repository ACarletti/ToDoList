using ToDoList.Interfaces;

namespace ToDoList
{
    public class ToDoListMenuUI : IToDoListMenuUI
    {
        private readonly IToDoListController _toDoListController;
        private readonly IConsoleFunctions _consoleFunctions;

        public ToDoListMenuUI(IToDoListController toDoListController, IConsoleFunctions console)
        {
            _toDoListController = toDoListController;
            _consoleFunctions = console;
        }

        public void Run()
        {
            while (true)
            {
                _consoleFunctions.WriteLine("Enter 1 to add item");
                _consoleFunctions.WriteLine("Enter 2 to remove item");
                _consoleFunctions.WriteLine("Enter 3 to print items");
                _consoleFunctions.WriteLine("Enter 0 to exit");

                int choice = _consoleFunctions.ReadLine();
                switch (choice)
                {
                    case 1:
                        _consoleFunctions.WriteLine("Enter item: ");
                        string item = _consoleFunctions.ReadItem();
                        _toDoListController.AddItem(item);
                        break;
                    case 2:
                        _consoleFunctions.WriteLine("Enter item: ");
                        item = _consoleFunctions.ReadItem();
                        _toDoListController.RemoveItem(item);
                        break;
                    case 3:
                        _toDoListController.PrintItems();
                        break;
                    case 0:
                        return;
                    default:
                        _consoleFunctions.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}
