using MaisonReposApi.Entities;
using System.Diagnostics.Metrics;

namespace MaisonReposApi.Interfaces
{
    public interface IFonctionService
    {
         ICollection<Fonction> GetAllFonction();
         Fonction GetFonctionById(int fonctionId);
         bool FonctionExitsById(int fonctionId);
         bool FonctionExitsByName(string fonctionName);
         bool UpdateFonction(Fonction fonction);
         bool CreateFonction(Fonction fonction);
         bool DeleteFonction(Fonction fonction);
        bool Save();



    }
}
