using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface ICategorieDesSoinsService
    {
        IEnumerable<CategorieDesSoin> GetAllCategorieDesSoins();
        CategorieDesSoin GetCategorieDesSoinsById(int id);
        bool CategorieDesSoinsExits(int categorieId);
        bool CreateCategorieDesSoins(CategorieDesSoin categorieDesSoin);
        bool UpdateCategorieDesSoins(CategorieDesSoin categorieDesSoin);
        bool DeleteCategorieDesSoins(CategorieDesSoin categorieDessoin);
        bool Save();
    }
}
