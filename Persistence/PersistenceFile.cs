using System.IO;

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
