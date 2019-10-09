using System;

namespace Kata
{
    public class StringCalculator
    {
        private const char DEFAULT_DELIMITER = ',';

        public static int Add(String numbers)
        {
            if (numbers.Length == 0) return 0;
            char delimiter = extractDelimiter(numbers);
            numbers = deleteDelimiterLine(numbers);
            return sumOf(extractNumbers(correctFormat(numbers, delimiter), delimiter));
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

        private static string[] extractNumbers(string numbers, char delimiter)
        {
            return numbers.Split(new char[] {delimiter}, StringSplitOptions.None);
        }

        private static int sumOf(String[] numbers)
        {
            int result = 0;
            for (int i = 0; i < numbers.Length; i++) result += valueOf(numbers[i]);
            return result;
        }

        private static int valueOf(String number)
        {
            return int.Parse(number);
        }
    }
}