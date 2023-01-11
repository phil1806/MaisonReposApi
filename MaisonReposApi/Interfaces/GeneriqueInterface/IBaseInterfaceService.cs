namespace MaisonReposApi.Interfaces.GeneriqueInterface
{
    public interface IBaseInterfaceService<T>
        where T : class
    {
        ICollection<T> GetAllElements();
        T GetElementById(int id);
        T CreateElement(T element);
        bool DeleteElement(int Id);
        bool UpdateElement(T element);
        bool ElementExists(int Id);
        bool Save();

    }
}
