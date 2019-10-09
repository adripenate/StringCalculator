using Kata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    class PersistenceFileShould
    {
        PersistenceFile persistenceFile;
        
        [TestInitialize]
        public void SetUp()
        {
            persistenceFile = new PersistenceFile();
        }

        [TestMethod]
        public void return_0_when_empty_string()
        {
            
        }
    }
}
