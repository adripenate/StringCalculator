using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IPersistence 
    {
        void Save(string line, string path);

    }
}
