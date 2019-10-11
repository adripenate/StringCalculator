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
            if (File.Exists(path)) File.Delete(path);
            persistenceFile = new PersistenceFile();
        }

        [Test]
        public void write_line_in_file()
        {
            var given = path;

            persistenceFile.Save("Test line", path);
            using (StreamReader streamReader = new StreamReader(path))
            {
                String when = streamReader.ReadLine();

                when.Should().NotBeNull().And.Should().Be("Test line");
            }
        }
    }
}
