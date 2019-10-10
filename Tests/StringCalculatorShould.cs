using Model;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void SetUp()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void return_0_when_empty_string()
        {
            Assert.That(stringCalculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        public void return_a_number_when_string_a_number()
        {
            Assert.That(stringCalculator.Add("1"), Is.EqualTo(1));
            Assert.That(stringCalculator.Add("2"), Is.EqualTo(2));
        }

        [Test]
        public void return_sum_when_string_has_unknown_amount_numbers()
        {
            Assert.That(stringCalculator.Add("1,2"), Is.EqualTo(3));
            Assert.That(stringCalculator.Add("1,2,1"), Is.EqualTo(4));
        }

        [Test]
        public void return_6_when_string_has_new_lines_and_1_2_3()
        {
            Assert.That(stringCalculator.Add("1\n2,3"), Is.EqualTo(6));
        }

        [Test]
        public void return_3_when_string_has_special_delimiter_and_1_2()
        {
            Assert.That(stringCalculator.Add("//;\n1;2"), Is.EqualTo(3));
        }

        [Test]
        public void throw_exception_when_string_has_negative_number()
        {
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("negatives not allowed: -1"),
                () => stringCalculator.Add("1,4,-1"));
            
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("negatives not allowed: -4"),
                () => stringCalculator.Add("1,-4,5"));
        }

        [Test]
        public void throw_exception_when_string_has_multiples_negative_numbers()
        {
            Assert.Throws(Is.TypeOf<Exception>().And.Message.EqualTo("negatives not allowed: -4 -1"), 
                () => stringCalculator.Add("1,-4,3,-1"));
        }

        [Test]
        public void return_sum_ignoring_numbers_bigger_than_1000()
        {
            Assert.AreEqual(2, stringCalculator.Add("2,1001"));
            Assert.AreEqual(2, stringCalculator.Add("2,1050"));
        }
    }
}
