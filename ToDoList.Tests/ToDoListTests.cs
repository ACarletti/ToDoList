using ToDoList.Interfaces;

namespace ToDoList.Tests
{
    [TestFixture]
    public class ToDoListTests
    {
        private IToDoList? toDoList;

        [SetUp]
        public void SetUp()
        {
            toDoList = new ToDoList();
        }

        [TearDown]
        public void TearDown()
        {
            toDoList = null;
        }

        [Test]
        public void Test_Can_Add_Item()
        {
            toDoList?.AddItem("item1");

            Assert.That(toDoList?.GetItems(), Has.One.EqualTo("item1"));
        }

        [Test]
        public void Test_Can_Remove_Item_By_Name()
        {
            toDoList?.AddItem("item1");
            toDoList?.AddItem("item2");

            toDoList?.RemoveItem("item1");

            Assert.That(toDoList?.GetItems(), Has.One.EqualTo("item2"));
        }

        [Test]
        public void Test_Can_Remove_Item_By_Index()
        {
            toDoList?.AddItem("item1");
            toDoList?.AddItem("item2");

            toDoList?.RemoveItem(0);

            Assert.That(toDoList?.GetItems(), Has.One.EqualTo("item2"));
        }
    }
}
