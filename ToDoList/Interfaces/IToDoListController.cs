namespace ToDoList.Interfaces
{
    public interface IToDoListController
    {
        void AddItem(string item);
        IEnumerable<string> GetItems();
        void PrintItems();
        void RemoveItem(int index);
        void RemoveItem(string item);
    }
}