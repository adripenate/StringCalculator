using System;

namespace Kata
{
    public class StringCalculator
    {
        public static int Add(String numbers)
        {
            if (numbers.Length == 0) return 0;
            return sumOf(numbers.Split(new String[] { "," }, StringSplitOptions.None));
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