using EeshaNoor.FlaUI.Base;
using EeshaNoor.FlaUI.Pages;
using FluentAssertions;
using NUnit.Framework;

namespace EeshaNoor.FlaUI.Tests
{
    [TestFixture]
    [Category("Calculator")]
    public class CalculatorTests : BaseTest
    {
        protected override string AppPath => "calc.exe";

        private CalculatorPage _calculator = null!;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            _calculator = new CalculatorPage(App!, Automation!);
        }

        [Test]
        [Description("Verify basic addition: 2 + 3 = 5")]
        public void Addition_TwoPlusThree_ReturnsFive()
        {
            _calculator.Clear();
            _calculator.Calculate("2+3=");
            _calculator.GetResult().Should().Be("5");
        }

        [Test]
        [Description("Verify basic subtraction: 9 - 4 = 5")]
        public void Subtraction_NineMinusFour_ReturnsFive()
        {
            _calculator.Clear();
            _calculator.Calculate("9-4=");
            _calculator.GetResult().Should().Be("5");
        }

        [Test]
        [Description("Verify multiplication: 6 x 7 = 42")]
        public void Multiplication_SixTimesSeven_Returns42()
        {
            _calculator.Clear();
            _calculator.Calculate("6*7=");
            _calculator.GetResult().Should().Be("42");
        }

        [Test]
        [Description("Verify division: 15 / 3 = 5")]
        public void Division_FifteenDivByThree_ReturnsFive()
        {
            _calculator.Clear();
            _calculator.Calculate("15/3=");
            _calculator.GetResult().Should().Be("5");
        }

        [Test]
        [Description("Clear resets display to zero")]
        public void Clear_AfterInput_ResetsToZero()
        {
            _calculator.Calculate("999");
            _calculator.Clear();
            _calculator.GetResult().Should().Be("0");
        }

        [Test]
        [Description("Chained operations: 2 + 3 * 2 = 10")]
        public void ChainedOperations_ReturnsCorrectResult()
        {
            _calculator.Clear();
            _calculator.Calculate("2+3=");
            _calculator.Calculate("*2=");
            _calculator.GetResult().Should().Be("10");
        }
    }
}