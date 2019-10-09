using System;

namespace Kata
{
    public class StringCalculator
    {
        public static int Add(String numbers)
        {
            if (numbers.Length == 0) return 0;
            String[] numbersChain = numbers.Split(new String[] { "," }, StringSplitOptions.None);
            int result = 0;
            for (int i = 0; i < numbersChain.Length; i++) result += valueOf(numbersChain[i]);
            return result;
        }

        private static int valueOf(String number)
        {
            return int.Parse(number);
        }
    }
}