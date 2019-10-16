using Model;
using NUnit.Framework;
using FluentAssertions;
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
            var given = "";
            
            var when = stringCalculator.Add(given);
            
            when.Should().Be(0);         
        }

        [TestCase("1", 1), TestCase("2", 2)]
        public void return_a_number_when_string_a_number(string number, int sumResult)
        {
            var given = number;
            
            var when = stringCalculator.Add(given);
            
            when.Should().Be(sumResult);
        }

        [Test]
        public void return_sum_when_string_has_unknown_amount_numbers()
        {
            var given = "1,2";
            
            var when = stringCalculator.Add(given);
            
            when.Should().Be(3);


            given = "1,2,1";
            
            when = stringCalculator.Add(given);
            
            when.Should().Be(4);
        }

        [Test]
        public void return_6_when_string_has_new_lines_and_1_2_3()
        {
            var given = "1\n2,3";
            
            var when = stringCalculator.Add(given);
            
            when.Should().Be(6);
        }

        [Test]
        public void return_3_when_string_has_special_delimiter_and_1_2()
        {
            var given = "//;\n1;2";
            
            var when = stringCalculator.Add(given);
            
            when.Should().Be(3);
        }

        [Test]
        public void throw_exception_when_string_has_negative_number()
        {
            var given = "1,4,-1";
            
            Action when = () => stringCalculator.Add(given);
            
            when.Should().Throw<Exception>().WithMessage("negatives not allowed: -1");

            given = "1,-4,5";
            
            when = () => stringCalculator.Add(given);
            
            when.Should().Throw<Exception>().WithMessage("negatives not allowed: -4");
        }

        [Test]
        public void throw_exception_when_string_has_multiples_negative_numbers()
        {
            var given = "1,-4,3,-1";
            
            Action when = () => stringCalculator.Add(given);
            
            when.Should().Throw<Exception>().WithMessage("negatives not allowed: -4 -1");
        }

        [Test]
        public void return_sum_ignoring_numbers_bigger_than_1000()
        {
            var given = "2,1001";
            
            var when = stringCalculator.Add(given);
            
            when.Should().Be(2);


            given = "2,1050";
            
            when = stringCalculator.Add(given);
            
            when.Should().Be(2);
        }
    }
}
