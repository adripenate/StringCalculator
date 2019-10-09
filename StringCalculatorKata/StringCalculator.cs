using System;

namespace Kata
{
    public class StringCalculator
    {
        public static int Add(String numbers)
        {
            if (numbers.Length == 0) return 0;
            String delimiter;
            if (numbers.Contains("//"))
            {
                delimiter = numbers[2] + "";
                numbers = numbers.Substring(4);
            }
            else
            {
                delimiter = ",";
            }
            return sumOf(extractNumbers(correctFormat(numbers, delimiter), delimiter));
        }

        private static string[] extractNumbers(string numbers, string delimiter)
        {
            return numbers.Split(new String[] {delimiter}, StringSplitOptions.None);
        }

        private static String correctFormat(string numbers, String delimiter)
        {
            return numbers.Replace("\n", delimiter);
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