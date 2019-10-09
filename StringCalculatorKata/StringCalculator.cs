using System;

namespace Kata
{
    public class StringCalculator
    {
        public static int Add(String numbers)
        {
            if(numbers.Length == 3)
            {
                String[] numbersSplit = numbers.Split(new String[] {","}, StringSplitOptions.None);
                int result = 0;
                for(int i = 0; i < 2; i++)
                {
                    result += int.Parse(numbersSplit[i]);
                }
                return result;
            }
            return numbers.Length == 1 ? int.Parse(numbers) : 0;
        }
    }
}