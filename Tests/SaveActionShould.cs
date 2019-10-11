using Model;
using Persistence;
using Kata;
using NUnit.Framework;
using FluentAssertions;
using System.IO;

namespace Tests
{
    [TestFixture]
    class SaveActionShould
    {
        private SaveAction saveAction;
        private string path;

        [SetUp]
        public void SetUp()
        {
            saveAction = new SaveAction(new StringCalculator(), new PersistenceFile());
            path = @"C:\Users\apenate\Desktop\StringCalculatorKata\LogTest.txt";
            if (File.Exists(path)) File.Delete(path);
        }

        [Test]
        public void write_operation_with_result_in_file()
        {
            
        }
    }
}
