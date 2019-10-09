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
        public void return_a_number_when_string_a_number()
        {
            Assert.AreEqual(1, StringCalculator.Add("1"));
            Assert.AreEqual(2, StringCalculator.Add("2"));
        }

        [TestMethod]
        public void return_sum_when_string_has_unknown_amount_numbers()
        {
            Assert.AreEqual(3, StringCalculator.Add("1,2"));
            Assert.AreEqual(4, StringCalculator.Add("1,2,1"));
        }

        [TestMethod]
        public void return_6_when_string_has_new_lines_and_1_2_3()
        {
            Assert.AreEqual(6, StringCalculator.Add("1\n2,3"));
        }

    }
}
