using ToDoList.Interfaces;

namespace ToDoList
{
    public class ToDoList : IToDoList
    {
        private readonly List<string> items;

        public ToDoList()
        {
            items = new List<string>();
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public bool RemoveItem(string item)
        {
            return items.Remove(item);
        }

        public bool RemoveItem(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                items.RemoveAt(index);
                return true;
            }
            return false;
        }

        public IEnumerable<string> GetItems()
        {
            return items;
        }
    }
}
