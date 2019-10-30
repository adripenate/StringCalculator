using System;

namespace Model
{
    public interface IPersistence 
    {
        void Save(string operation, int res);
        void Save(string operation, Exception error);
    }
}
