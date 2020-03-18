using NUnit.Framework;
using System;

namespace consoleProject.Tests
{
    [TestFixture]
    public class TestCases
    {
        [Test]
        public void UserInputTestValid([Values("1", "Admin", "2", "GUests")] string input)
        {
            bool testInput = MainScreen.UserInput(input);
            Assert.AreEqual(false, testInput);

            var ex = Assert.Throws<FormatException>(() => MainScreen.UserInput(input));
            Assert.That(ex.Message, Is.EqualTo("\n\n  The inserted value was not a number."));
        }

        [Test]
        public void UserInputTestInvalid([Values("test", "check", 28)] string input)
        {
            bool testInput = MainScreen.UserInput(input);
            Assert.AreEqual(true, testInput);
        }

        [Test]
        public void UserInputTestNegative([Values(-28)] string input)
        {
            bool testInput = MainScreen.UserInput(input);
            Assert.AreEqual(true, testInput);
        }

    }

    [TestFixture]
    public class CustomExceptionTests
    {
        [Test]
        public void ValidateInputTest([Range(-5, 10)] int input)
        {
            Assert.DoesNotThrow(() => CustomException.ValidateInput(input, 2));
        }

        [Test]
        public void ValidateGuestAgeTest([Range(-5, 150)] int input)
        {
            Assert.DoesNotThrow(() => CustomException.ValidateGuestAge(input, input));
        }

        [Test]
        public void ValidateMovieChoiceTest([Range(-5, 10)] int input)
        {
            Assert.DoesNotThrow(() => CustomException.ValidateMovieChoice(input));
        }
    }
}
