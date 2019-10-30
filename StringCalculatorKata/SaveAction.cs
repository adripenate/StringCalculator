using System;
using Model;

namespace UseCases
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

        public StringCalculatorResult Execute(string numbers)
        {
            try
            {
                var result = stringCalculator.Add(numbers);
                persistenceFile.Save(numbers, result);
                return new StringCalculatorResult {Result = result};
            } 
            catch (Exception exception)
            {
                persistenceFile.Save(numbers, exception);
                return null;
            }
        }
    }
}
