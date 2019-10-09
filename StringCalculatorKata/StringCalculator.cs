using System;

namespace Kata
{
    public class StringCalculator
    {
        public static int Add(String numbers)
        {
            return numbers.Length == 1 ? int.Parse(numbers) : 0;
        }
    }
}