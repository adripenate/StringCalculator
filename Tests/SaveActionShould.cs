using Model;
using Persistence;
using Kata;
using NUnit.Framework;
using FluentAssertions;
using System.IO;
using System;

namespace Tests
{
    [TestFixture]
    class SaveActionShould
    {
        private SaveAction saveAction;
        private string filePath;

        [SetUp]
        public void SetUp()
        {
            saveAction = new SaveAction(new StringCalculator(), new PersistenceFile());
            filePath = @"C:\Users\apenate\Desktop\StringCalculatorKata\LogTest.txt";
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        [Test]
        public void write_operation_with_result_in_file()
        {
            var given = "1,2";

            saveAction.execute(given, filePath);

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                var when = streamReader.ReadToEnd().Trim();
                when.Should().Be(given + " -> El resultado es 3");
            }
        }

        [Test]
        public void write_operation_with_exception_message_in_file()
        {
            var given = "1,4,-1";

            saveAction.execute(given, filePath);

            using (StreamReader streamReader = new StreamReader(filePath))
            {
                var when = streamReader.ReadToEnd().Trim();
                when.Should().Be(given + " -> negatives not allowed: -1");
            }
        }
    }
}