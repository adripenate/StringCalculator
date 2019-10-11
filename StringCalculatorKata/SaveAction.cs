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

        public void execute(string numbers, string filePath)
        {
            var log = getOperationRegister(numbers);
            persistenceFile.Save(log, filePath);
        }

        private string getOperationRegister(string numbers)
        {
            return numbers + " -> El resultado es " + stringCalculator.Add(numbers);
        }
    }
}
