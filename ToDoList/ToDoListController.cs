using ToDoList.Interfaces;

namespace ToDoList
{
    public class ToDoListController : IToDoListController
    {
        private readonly IToDoList _toDoList;
        private readonly IConsoleFunctions _consoleFunctions;

        public ToDoListController(IToDoList toDoList, IConsoleFunctions consoleFunctions)
        {
            _toDoList = toDoList;
            _consoleFunctions = consoleFunctions;
        }

        public void AddItem(string item)
        {
            _toDoList.AddItem(item);
        }

        public void RemoveItem(string item)
        {
            _toDoList.RemoveItem(item);
        }

        public void RemoveItem(int index)
        {
            _toDoList.RemoveItem(index);
        }

        public IEnumerable<string> GetItems()
        {
            return _toDoList.GetItems();
        }

        public void PrintItems()
        {
            var items = _toDoList.GetItems();
            foreach (var item in items)
            {
                _consoleFunctions.WriteLine(item);
            }
        }
    }
}

