using NUnit.Framework;

namespace consoleProject.Tests
{
    [TestFixture]
    public class MainScreenTests
    {
        [Test]
        public void ForAllNumberInput([Range(-5, 5)] int input)
        {
            Assert.DoesNotThrow(() => CustomException.ValidateInput(input, 0));
        }
    }
}
