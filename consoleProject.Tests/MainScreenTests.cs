using NUnit.Framework;

namespace consoleProject.Tests
{
    [TestFixture]
    public class MainScreenTests
    {
        [Test]
        public void UserInputTestValid([Values("1", "admin", "2", "guests")] string input)
        {
            Assert.AreEqual(true, true);
        }

        public void UserInputTestInvalid([Values("test", "check", "28")] string input)
        {
            Assert.AreEqual(false, false);
        }
    }

    [TestFixture]
    public class CustomExceptionTests
    {
        [Test]
        public void ForAllNumberInput([Range(1, 10)] int input)
        {
            Assert.DoesNotThrow(() => CustomException.ValidateInput(input, 2));
        }
    }
}
