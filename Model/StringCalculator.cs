using System;

namespace Model
{
    public class StringCalculator
    {
        private const char DEFAULT_DELIMITER = ',';

        public int Add(String numbers)
        {
            if (isEmpty(numbers)) return 0;
            char delimiter = extractDelimiter(numbers);
            numbers = getCorrectFormat(getWithoutDelimiterLine(numbers), delimiter);
            return sumOf(separateNumbers(numbers, delimiter));
        }

        private static char extractDelimiter(string numbers)
        {
            return hasSpecialDelimiter(numbers) ? numbers[2] : DEFAULT_DELIMITER;
        }

        private static string getWithoutDelimiterLine(string numbers)
        {
            return hasSpecialDelimiter(numbers) ? numbers.Substring(4) : numbers;
        }

        private static bool hasSpecialDelimiter(string numbers)
        {
            return numbers.Contains("//");
        }

        private static String getCorrectFormat(string numbers, char delimiter)
        {
            return numbers.Replace('\n', delimiter);
        }

        private static string[] separateNumbers(string numbers, char delimiter)
        {
            return numbers.Split(new char[] {delimiter}, StringSplitOptions.None);
        }

        private static bool isEmpty(string numbers)
        {
            return numbers.Length == 0;
        }

        private static int sumOf(String[] numbers)
        {
            int result = 0;
            String negativeNumbers = "";
            foreach(String number in numbers){
                if (isNegative(number)) negativeNumbers += number + " ";
                if(isNotBiggerThan1000(number)) result += valueOf(number);
            }
            if(!isEmpty(negativeNumbers)) generateException(negativeNumbers);
            return result;
        }

        private static void generateException(string negativeNumbers)
        {
            throw new Exception("negatives not allowed: " + negativeNumbers.Trim());
        }

        private static bool isNotBiggerThan1000(string number)
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
