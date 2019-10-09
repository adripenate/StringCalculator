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
            if (numbers.Contains("//"))
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }
            else
            {
                delimiter = DEFAULT_DELIMITER;
            }
            return sumOf(extractNumbers(correctFormat(numbers, delimiter), delimiter));
        }

        private static char extractDelimiter(string numbers)
        {
            return numbers.Contains("//") ? numbers[2] : DEFAULT_DELIMITER;
        }

        private static string[] extractNumbers(string numbers, char delimiter)
        {
            return numbers.Split(new char[] {delimiter}, StringSplitOptions.None);
        }

        private static String correctFormat(string numbers, char delimiter)
        {
            return numbers.Replace('\n', delimiter);
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