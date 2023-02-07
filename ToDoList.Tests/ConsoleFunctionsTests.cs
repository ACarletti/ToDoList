using Moq;
using ToDoList.Interfaces;

namespace ToDoList.Tests
{
    [TestFixture]
    public class ConsoleFunctionsTests
    {
        private Mock<IConsoleWrapper>? _mockConsoleWrapper;
        private ConsoleFunctions? _consoleFunctions;

        [SetUp]
        public void Setup()
        {
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();
            _consoleFunctions = new ConsoleFunctions(_mockConsoleWrapper.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockConsoleWrapper = null;
            _consoleFunctions = null;
        }

        [Test]
        public void ReadLine_ValidInput_ReturnsParsedValue()
        {
            // Arrange
            _mockConsoleWrapper?.Setup(x => x.ReadLineWrapper()).Returns("123");

            // Act
            var result = _consoleFunctions?.ReadLine();

            // Assert
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void ReadLine_InvalidInput_ThrowsException()
        {
            // Arrange
            _mockConsoleWrapper?.Setup(x => x.ReadLineWrapper()).Returns("invalid");

            // Act & Assert
            Assert.Throws<Exception>(() => _consoleFunctions?.ReadLine(), "Invalid input. Please enter a valid integer.");
        }

        [Test]
        public void ReadLine_NullOrEmptyInput_ThrowsException()
        {
            // Arrange
            _mockConsoleWrapper?.Setup(x => x.ReadLineWrapper()).Returns(string.Empty);

            // Act & Assert
            Assert.Throws<Exception>(() => _consoleFunctions?.ReadLine(), "Input cannot be null or empty");
        }

        [Test]
        public void WriteLine_ValidMessage_CallsWriteLineWrapper()
        {
            // Act
            _consoleFunctions?.WriteLine("test message");

            // Assert
            _mockConsoleWrapper?.Verify(x => x.WriteLineWrapper("test message"), Times.Once);
        }

        [Test]
        public void ReadItem_ValidInput_ReturnsParsedValue()
        {
            // Arrange
            _mockConsoleWrapper?.Setup(x => x.ReadLineWrapper()).Returns("Item");

            // Act
            var result = _consoleFunctions?.ReadItem();

            // Assert
            Assert.That(result, Is.EqualTo("Item"));
        }
    }
}
