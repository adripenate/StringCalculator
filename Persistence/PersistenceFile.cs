using System;
using System.IO;

namespace Persistence
{
    public class PersistenceFile : IPersistence
    {
        public void Save(string operation, int result, string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(operation + " -> El resultado es " + result);
            }
        }

        public void Save(string operation, Exception error, string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                streamWriter.WriteLine(operation + " -> " + error.Message);
            }
        }
    }
}
