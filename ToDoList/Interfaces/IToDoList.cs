namespace ToDoList.Interfaces
{
    public interface IToDoList
    {
        void AddItem(string item);
        bool RemoveItem(string item);
        bool RemoveItem(int index);
        IEnumerable<string> GetItems();
    }
}
