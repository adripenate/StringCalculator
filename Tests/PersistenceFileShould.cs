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
        string path;
        PersistenceFile persistenceFile;

        [SetUp]
        public void SetUp()
        {
            path = @".\TestFile.txt";
            persistenceFile = new PersistenceFile(path);
        }

        [Test]
        public void write_line_in_file()
        {
            persistenceFile.Save("Operation", 3);
            
            using (StreamReader streamReader = new StreamReader(path))
            {
                string lineInFile = streamReader.ReadLine();

                lineInFile.Should().Be("Operation -> El resultado es " + 3);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (File.Exists(path)) File.Delete(path);
        }
    }
}
