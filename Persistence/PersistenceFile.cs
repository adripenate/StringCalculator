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
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(operation + " -> El resultado es " + result);
            }
        }

        public void Save(string operation, Exception error)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(operation + " -> " + error.Message);
            }
        }
    }
}
