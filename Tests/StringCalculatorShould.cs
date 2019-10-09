using Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StringCalculatorShould
    {
        [TestMethod]
        public void return_0_when_empty_string()
        {
            Assert.AreEqual(0, StringCalculator.Add(""));
        }

        [TestMethod]
        public void return_1_when_string_1()
        {
            Assert.AreEqual(1, StringCalculator.Add("1"));
        }
    }
}
