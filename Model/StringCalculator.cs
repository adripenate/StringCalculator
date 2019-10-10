﻿using System;

namespace Model
{
    public class StringCalculator
    {
        private const char DEFAULT_DELIMITER = ',';

        public int Add(String numbers)
        {
            if (numbers.Length == 0) return 0;
            char delimiter = extractDelimiter(numbers);
            numbers = deleteDelimiterLine(numbers);
            return sumOf(separateNumbers(correctFormat(numbers, delimiter), delimiter));
        }

        private static char extractDelimiter(string numbers)
        {
            return hasSpecialDelimiter(numbers) ? numbers[2] : DEFAULT_DELIMITER;
        }

        private static string deleteDelimiterLine(string numbers)
        {
            return hasSpecialDelimiter(numbers) ? numbers.Substring(4) : numbers;
        }

        private static bool hasSpecialDelimiter(string numbers)
        {
            return numbers.Contains("//");
        }

        private static String correctFormat(string numbers, char delimiter)
        {
            return numbers.Replace('\n', delimiter);
        }

        private static string[] separateNumbers(string numbers, char delimiter)
        {
            return numbers.Split(new char[] {delimiter}, StringSplitOptions.None);
        }

        private static int sumOf(String[] numbers)
        {
            int result = 0;
            String negativeNumbers = "";
            foreach(String number in numbers){
                if (isNegative(number)) negativeNumbers += number + " ";
                if(isNotBigger(number)) result += valueOf(number);
            }
            if(existsNegatives(negativeNumbers)) generateException(negativeNumbers);
            return result;
        }

        private static void generateException(string negativeNumbers)
        {
            throw new Exception("negatives not allowed: " + negativeNumbers.Trim());
        }

        private static bool existsNegatives(String negativesNumbers)
        {
            return negativesNumbers.Length > 0;
        }

        private static bool isNotBigger(string number)
        {
            return valueOf(number) <= 1000;
        }

        private static bool isNegative(string number)
        {
            return valueOf(number) < 0;
        }

        private static int valueOf(String number)
        {
            return int.Parse(number);
        }
    }
}