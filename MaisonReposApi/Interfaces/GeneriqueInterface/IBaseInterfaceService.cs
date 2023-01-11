namespace MaisonReposApi.Interfaces.GeneriqueInterface
{
    public interface IBaseInterfaceService<T>
        where T : class
    {
        ICollection<T> GetAllElements();
        T GetElementById(int id);
        bool CreateElement(T element);
        bool DeleteElement(T element);
        bool UpdateElement(T element);
        bool ElementExists(int Id);
        bool Save();

    }
}
