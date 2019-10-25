using System;

namespace Model
{
    public class StringCalculator
    {
        private const char DefaultDelimiter = ',';
        private const string StartOfDelimiterLine = "//";
        private const char NewLine = '\n';
        private const int MaxNumberValue = 1000;
        private const int MinNumberValue = 0;
        private const int DelimiterPosition = 2;
        private const int StartOfNumbersLine = 4;

        public int Add(string chainNumbers)
        {
            if (IsEmpty(chainNumbers)) return 0;
            char delimiter = ExtractDelimiter(chainNumbers);
            return SumOf(SeparateNumbers(chainNumbers, delimiter));
        }

        private static char ExtractDelimiter(string numbers)
        {
            return HasSpecialDelimiter(numbers) ? numbers[DelimiterPosition] : DefaultDelimiter;
        }

        private static string GetWithoutDelimiterLine(string numbers)
        {
            return HasSpecialDelimiter(numbers) ? numbers.Substring(StartOfNumbersLine) : numbers;
        }

        private static bool HasSpecialDelimiter(string numbers)
        {
            return numbers.Contains(StartOfDelimiterLine);
        }

        private static string GetCorrectFormat(string numbers, char delimiter)
        {
            return numbers.Replace(NewLine, delimiter);
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
            return ValueOf(number) <= MaxNumberValue;
        }

        private static bool IsNegative(string number)
        {
            return ValueOf(number) < MinNumberValue;
        }

        private static int ValueOf(String number)
        {
            return int.Parse(number);
        }
    }
}
