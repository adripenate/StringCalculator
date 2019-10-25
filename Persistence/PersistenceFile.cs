using System;
using System.IO;

namespace Persistence
{
    public class PersistenceFile : IPersistence
    {
        private string path;

        public PersistenceFile(string path)
        {
            this.path = path;
        }

        public void Save(string operation, int result)
        {
            Write(operation + " -> El resultado es " + result);
        }

        public void Save(string operation, Exception error)
        {
            Write(operation + " -> " + error.Message);
        }

        private void Write(string line)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, append: true))
            {
                streamWriter.WriteLine(line);
            }
        }
    }
}
