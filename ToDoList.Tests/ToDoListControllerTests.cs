using Moq;
using ToDoList.Interfaces;

namespace ToDoList.Tests
{
    [TestFixture]
    public class ToDoListControllerTests
    {
        private Mock<IToDoList>? _mockToDoList;
        private Mock<IConsoleFunctions>? _mockConsoleFunctions;

        private ToDoListController? _toDoListController;

        [SetUp]
        public void SetUp()
        {
            _mockToDoList = new Mock<IToDoList>();
            _mockConsoleFunctions = new Mock<IConsoleFunctions>();

            _toDoListController = new ToDoListController(_mockToDoList.Object, _mockConsoleFunctions.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockToDoList = null;
            _mockConsoleFunctions = null;

            _toDoListController = null;
        }

        [Test]
        public void AddItem_ValidItem_CallsAddItemOnToDoList()
        {
            // Arrange
            var item = "Finish project";

            // Act
            _toDoListController?.AddItem(item);

            // Assert
            _mockToDoList?.Verify(t => t.AddItem(item), Times.Once);
        }

        [Test]
        public void RemoveItem_ItemExists_CallsRemoveItemOnce()
        {
            // Arrange
            var item = "item";

            // Act
            _toDoListController?.AddItem(item);
            _toDoListController?.RemoveItem(item);

            // Assert
            _mockToDoList?.Verify(x => x.RemoveItem(item), Times.Once());
        }


        [Test]
        public void Test_Can_Remove_Item_By_Index()
        {
            // Arrange
            var item = "item";

            // Act
            _toDoListController?.AddItem(item);
            _toDoListController?.RemoveItem(0);

            // Assert
            _mockToDoList?.Verify(x => x.RemoveItem(0), Times.Once());
        }

        [Test]
        public void PrintItems_CallsWriteLine_ForEachItemWithCorrectMessage()
        {
            // Arrange
            var items = new List<string> { "item1", "item2" };
            _mockToDoList?.Setup(x => x.GetItems()).Returns(items);

            // Act
            _toDoListController?.PrintItems();

            // Assert
            _mockConsoleFunctions?.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(items.Count));
            _mockConsoleFunctions?.Verify(x => x.WriteLine("item1"), Times.Once);
            _mockConsoleFunctions?.Verify(x => x.WriteLine("item2"), Times.Once);
        }

        [Test]
        public void PrintItems_NoItems_DoesNotCallWriteLine()
        {
            // Arrange
            _mockToDoList?.Setup(x => x.GetItems()).Returns(new List<string>());

            // Act
            _toDoListController?.PrintItems();

            // Assert
            _mockConsoleFunctions?.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never);
        }
    }
}
