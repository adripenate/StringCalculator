using Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void return_3_when_string_has_special_delimiter_and_1_2()
        {
            Assert.AreEqual(3, StringCalculator.Add("//;\n1;2"));
        }
        
        [TestMethod]
        public void throw_exception_when_string_has_negative_number()
        {
            try
            {
                StringCalculator.Add("1,4,-1");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "negatives not allowed: -1");
            }

            try
            {
                StringCalculator.Add("1,-4,5");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "negatives not allowed: -4");
            }
        }
        
        [TestMethod]
        public void throw_exception_when_string_has_multiples_negative_numbers()
        {
            try
            {
                StringCalculator.Add("1,-4,3,-1");
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.AreEqual(e.Message, "negatives not allowed: -4 -1");
            }
        }

        [TestMethod]
        public void return_2_when_string_2_1001()
        {
            Assert.AreEqual(2, StringCalculator.Add("2,1001"));
        }

        [TestMethod]
        public void return_2_when_string_2_1050()
        {
            Assert.AreEqual(2, StringCalculator.Add("2,1050"));
        }
    }
}
