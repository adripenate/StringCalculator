using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Persistence
{
    public class PersistenceFile : IPersistence
    {
        public void Save(string line, string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(line);
            }
        }
    }
}
