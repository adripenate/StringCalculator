using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IPersistence 
    {
        void Save(string operation, int res, string path);
        void Save(string operation, Exception error, string path);
    }
}
