using System;

namespace Persistence
{
    public interface IPersistence 
    {
        void Save(string operation, int res);
        void Save(string operation, Exception error);
    }
}
