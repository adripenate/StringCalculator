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
            if (IsEmpty(chainNumbers)) return 0;
            char delimiter = ExtractDelimiter(chainNumbers);
            return SumOf(SeparateNumbers(chainNumbers, delimiter));
        }

        private static char ExtractDelimiter(string numbers)
        {
            return HasSpecialDelimiter(numbers) ? numbers[DELIMITER_POSITION] : DEFAULT_DELIMITER;
        }

        private static string GetWithoutDelimiterLine(string numbers)
        {
            return HasSpecialDelimiter(numbers) ? numbers.Substring(START_OF_NUMBERS_LINE) : numbers;
        }

        private static bool HasSpecialDelimiter(string numbers)
        {
            return numbers.Contains(START_OF_DELIMITER_LINE);
        }

        private static string GetCorrectFormat(string numbers, char delimiter)
        {
            return numbers.Replace(NEW_LINE, delimiter);
        }

        private static string[] SeparateNumbers(string numbers, char delimiter)
        {
            numbers = GetCorrectFormat(GetWithoutDelimiterLine(numbers), delimiter);
            return numbers.Split(new char[] {delimiter}, StringSplitOptions.None);
        }

        private static bool IsEmpty(string numbers)
        {
            return numbers.Length == 0;
        }

        private static int SumOf(String[] numbers)
        {
            int result = 0;
            String negativeNumbers = "";
            foreach(String number in numbers){
                if (IsNegative(number)) negativeNumbers += number + " ";
                if(IsNotBiggerThan1000(number)) result += ValueOf(number);
            }
            if(!IsEmpty(negativeNumbers)) GenerateException(negativeNumbers);
            return result;
        }

        private static void GenerateException(string negativeNumbers)
        {
            throw new Exception("negatives not allowed: " + negativeNumbers.Trim());
        }

        private static bool IsNotBiggerThan1000(string number)
        {
            return ValueOf(number) <= MAX_NUMBER_VALUE;
        }

        private static bool IsNegative(string number)
        {
            return ValueOf(number) < MIN_NUMBER_VALUE;
        }

        private static int ValueOf(String number)
        {
            return int.Parse(number);
        }
    }
}
