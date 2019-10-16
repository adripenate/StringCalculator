using System;

namespace Model
{
    public class StringCalculator
    {
        private const char DEFAULT_DELIMITER = ',';
        private const string START_OF_DELIMITER_LINE = "//";
        private const char NEW_LINE = '\n';
        private const int MAX_NUMBER_VALUE = 1000;
        private const int MIN_NUMBER_VALUE = 0;
        private const int DELIMITER_POSITION = 2;
        private const int START_OF_NUMBERS_LINE = 4;

        public int Add(string chainNumbers)
        {
            if (isEmpty(chainNumbers)) return 0;
            char delimiter = extractDelimiter(chainNumbers);
            string[] numbers = separateNumbers(getCorrectFormat(getWithoutDelimiterLine(chainNumbers), delimiter), delimiter);
            return sumOf(numbers);
        }

        private static char extractDelimiter(string numbers)
        {
            return hasSpecialDelimiter(numbers) ? numbers[DELIMITER_POSITION] : DEFAULT_DELIMITER;
        }

        private static string getWithoutDelimiterLine(string numbers)
        {
            return hasSpecialDelimiter(numbers) ? numbers.Substring(START_OF_NUMBERS_LINE) : numbers;
        }

        private static bool hasSpecialDelimiter(string numbers)
        {
            return numbers.Contains(START_OF_DELIMITER_LINE);
        }

        private static String getCorrectFormat(string numbers, char delimiter)
        {
            return numbers.Replace(NEW_LINE, delimiter);
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
            return valueOf(number) <= MAX_NUMBER_VALUE;
        }

        private static bool isNegative(string number)
        {
            return valueOf(number) < MIN_NUMBER_VALUE;
        }

        private static int valueOf(String number)
        {
            return int.Parse(number);
        }
    }
}
