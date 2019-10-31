using System;
using System.Linq;

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
            return SumOf(ExtractNumbersFrom(chainNumbers));
        }

        private static int[] ExtractNumbersFrom(string numbers)
        {
            return SeparateNumbers(numbers).Select(int.Parse).ToArray();
        }

        private static string[] SeparateNumbers(string numbers)
        {
            var delimiter = ExtractDelimiter(numbers);
            numbers = GetCorrectFormat(GetWithoutDelimiterLine(numbers), delimiter);
            return numbers.Split(new[] {delimiter}, StringSplitOptions.None);
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

        private static bool IsEmpty(string numbers)
        {
            return numbers.Length == 0;
        }

        private static int SumOf(int[] numbers)
        {
            var negatives = numbers.Where(IsNegative).ToList();
            if (negatives.Any()) throw new Exception("negatives not allowed: " + string.Join(" ", negatives));
            return numbers.Where(IsNotBiggerThan1000).Sum();
        }

        private static bool IsNegative(int number)
        {
            return number < MinNumberValue;
        }

        private static bool IsNotBiggerThan1000(int number)
        {
            return number <= MaxNumberValue;
        }
    }
}
