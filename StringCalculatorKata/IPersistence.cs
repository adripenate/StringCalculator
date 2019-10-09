namespace Kata
{
    public interface IPersistence
    {
        void save(string operation, int result);
    }
}