using System;

namespace Kata
{
    public class StringCalculator
    {
        public static int Add(String numbers)
        {
            return numbers.Length == 1 ? Int32.Parse(numbers) : 0;
        }
    }
}