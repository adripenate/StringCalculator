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
        public void sum_0_when_empty_string()
        {
            var emptyString = "";
            
            var resultOfOperation = stringCalculator.Add(emptyString);
            
            resultOfOperation.Should().Be(0);         
        }

        [TestCase("1", 1), TestCase("2", 2)]
        public void return_a_number_when_string_a_number(string number, int sumResult)
        {
            var given = number;
            
            var resultOfOperation = stringCalculator.Add(given);
            
            resultOfOperation.Should().Be(sumResult);
        }

        [Test]
        public void return_sum_when_string_has_unknown_amount_numbers()
        {
            var unknowAmountOfNumbers = "1,2";
            
            var resultOfOperation = stringCalculator.Add(unknowAmountOfNumbers);
            
            resultOfOperation.Should().Be(3);


            unknowAmountOfNumbers = "1,2,1";
            
            resultOfOperation = stringCalculator.Add(unknowAmountOfNumbers);
            
            resultOfOperation.Should().Be(4);
        }

        [Test]
        public void return_6_when_string_has_new_lines_and_1_2_3()
        {
            var numbersWithNewLine = "1\n2,3";
            
            var resultOfOperation = stringCalculator.Add(numbersWithNewLine);
            
            resultOfOperation.Should().Be(6);
        }

        [Test]
        public void return_3_when_string_has_special_delimiter_and_1_2()
        {
            var numbersWithSpecialDelimiter = "//;\n1;2";
            
            var resultOfOperation = stringCalculator.Add(numbersWithSpecialDelimiter);
            
            resultOfOperation.Should().Be(3);
        }

        [Test]
        public void throw_exception_when_string_has_negative_number()
        {
            var negativeNumber = "1,4,-1";
            
            Action resultOfOperation = () => stringCalculator.Add(negativeNumber);
            
            resultOfOperation.Should().Throw<Exception>().WithMessage("negatives not allowed: -1");

            negativeNumber = "1,-4,5";
            
            resultOfOperation = () => stringCalculator.Add(negativeNumber);
            
            resultOfOperation.Should().Throw<Exception>().WithMessage("negatives not allowed: -4");
        }

        [Test]
        public void throw_exception_when_string_has_multiples_negative_numbers()
        {
            var multipleNegativeNumbers = "1,-4,3,-1";
            
            Action resultOfOperation = () => stringCalculator.Add(multipleNegativeNumbers);
            
            resultOfOperation.Should().Throw<Exception>().WithMessage("negatives not allowed: -4 -1");
        }

        [Test]
        public void return_sum_ignoring_numbers_bigger_than_1000()
        {
            var numberBiggerThan1000 = "2,1001";
            
            var resultOfOperation = stringCalculator.Add(numberBiggerThan1000);
            
            resultOfOperation.Should().Be(2);


            numberBiggerThan1000 = "2,1050";
            
            resultOfOperation = stringCalculator.Add(numberBiggerThan1000);
            
            resultOfOperation.Should().Be(2);
        }
    }
}
