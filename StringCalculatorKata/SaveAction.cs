using Persistence;
using Model;
using System;

namespace Kata
{
    public class SaveAction
    {
        private StringCalculator stringCalculator;
        private IPersistence persistenceFile;

        public SaveAction(StringCalculator stringCalculator, IPersistence persistenceFile)
        {
            this.stringCalculator = stringCalculator;
            this.persistenceFile = persistenceFile;
        }

        public StringCalculatorResult execute(string numbers)
        {
            StringCalculatorResult stringCalculatorResult = null;
            try
            {
                var result = stringCalculator.Add(numbers);
                stringCalculatorResult = new StringCalculatorResult {Result = result};
                persistenceFile.Save(numbers, result);
            } 
            catch (Exception exception)
            {
                persistenceFile.Save(numbers, exception);
            }

            return stringCalculatorResult;
        }
    }
}
