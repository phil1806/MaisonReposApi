using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface ISoinsAjoutService
    {
        ICollection<SoinsAjout> GetAllSoinsAjouter();
        SoinsAjout GetSoinsAjoutById(int id);
        bool UpdateSoinsAjout(SoinsAjout soinsAjout);
        bool CreateSoinsAjout(SoinsAjout soinsAjout);
        bool DeleteSoinsAjout(SoinsAjout soinsAjout);
        bool SoinsExistById(int id);
   
        bool Save();
    }
}
