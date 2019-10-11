using System;
using NUnit.Framework;
using FluentAssertions;
using Persistence;
using System.IO;

namespace Tests
{
    [TestFixture]
    class PersistenceFileShould
    {
        String path;
        PersistenceFile persistenceFile;

        [SetUp]
        public void SetUp()
        {
            path = @"C:\Users\apenate\Desktop\StringCalculatorKata\TestFile.txt";
            persistenceFile = new PersistenceFile();
        }

        [Test]
        public void write_line_in_file()
        {
            var given = path;

            persistenceFile.Save("Test line", path);
            using (StreamReader streamReader = new StreamReader(path))
            {
                string when = streamReader.ReadLine();

                when.Should().Be("Test line");
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
