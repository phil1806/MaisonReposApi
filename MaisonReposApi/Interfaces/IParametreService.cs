using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface IParametreService
    {
        ICollection<Parametre> GetAllParametres();
        Parametre GetParametreById(int parmatreId);
        bool AddParametre(Parametre parametre);
        bool DeleteParametre(Parametre parametre);
        bool UpdateParametre(Parametre paramètre);
        bool ParametreExist(int parmatreId);
        bool Save();
    }
}
