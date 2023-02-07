using Moq;
using ToDoList.Interfaces;

namespace ToDoList.Tests
{
    [TestFixture]
    public class ToDoListMenuUITests
    {
        private Mock<IToDoListController> _toDoListControllerMock;
        private Mock<IConsoleFunctions> _consoleFunctionsMock;
        private ToDoListMenuUI _toDoListMenuUI;

        [SetUp]
        public void SetUp()
        {
            _toDoListControllerMock = new Mock<IToDoListController>();
            _consoleFunctionsMock = new Mock<IConsoleFunctions>();

            _toDoListMenuUI = new ToDoListMenuUI(_toDoListControllerMock.Object, _consoleFunctionsMock.Object);
        }

        [Test]
        public void Run_WhenCalled_ShouldWriteLineWithOptions()
        {
            // Act
            _toDoListMenuUI.Run();

            // Assert
            _consoleFunctionsMock.Verify(x => x.WriteLine("Enter 1 to add item"), Times.Once);
            _consoleFunctionsMock.Verify(x => x.WriteLine("Enter 2 to remove item"), Times.Once);
            _consoleFunctionsMock.Verify(x => x.WriteLine("Enter 3 to print items"), Times.Once);
            _consoleFunctionsMock.Verify(x => x.WriteLine("Enter 0 to exit"), Times.Once);
        }

        [Test]
        public void Run_WhenOption1Selected_ShouldCallAddItem()
        {
            // Arrange
            _consoleFunctionsMock.SetupSequence(x => x.ReadLine())
                .Returns(1)
                .Returns(0);
            _consoleFunctionsMock.Setup(x => x.ReadItem()).Returns("item");

            // Act
            _toDoListMenuUI.Run();

            // Assert
            _toDoListControllerMock.Verify(x => x.AddItem("item"), Times.Once);
        }

        [Test]
        public void Run_WhenOption2Selected_ShouldCallRemoveItem()
        {
            // Arrange
            _consoleFunctionsMock.SetupSequence(x => x.ReadLine())
                .Returns(2)
                .Returns(0);
            _consoleFunctionsMock.Setup(x => x.ReadItem()).Returns("item");

            // Act
            _toDoListMenuUI.Run();

            // Assert
            _toDoListControllerMock.Verify(x => x.RemoveItem("item"), Times.Once);
        }

        [Test]
        public void Run_WhenOption3Selected_ShouldCallPrintItems()
        {
            // Arrange
            _consoleFunctionsMock.SetupSequence(x => x.ReadLine())
                .Returns(3)
                .Returns(0);

            // Act
            _toDoListMenuUI.Run();

            // Assert
            _toDoListControllerMock.Verify(x => x.PrintItems(), Times.Once);
        }

        [Test]
        public void Run_WhenOption0Selected_ShouldNotCallAnyMethodsAndExit()
        {
            // Arrange
            _consoleFunctionsMock.SetupSequence(x => x.ReadLine())
                .Returns(0)
                .Returns(0);

            // Act
            _toDoListMenuUI.Run();

            // Assert
            _toDoListControllerMock.Verify(x => x.PrintItems(), Times.Never);
        }
    }
}
