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
    }
}
