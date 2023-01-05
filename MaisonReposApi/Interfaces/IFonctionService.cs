using MaisonReposApi.Entities;
using System.Diagnostics.Metrics;

namespace MaisonReposApi.Interfaces
{
    public interface IFonctionService
    {
        public ICollection<Fonction> GetAllFonction();
        public Fonction GetFonctionById(int fonctionId);
        public bool FonctionExitsById(int fonctionId);
        public bool FonctionExitsByName(string fonctionName);
        public bool UpdateFonction(Fonction fonction);
        public bool CreateFonction(Fonction fonction);
        public bool DeleteFonction(Fonction fonction);
        bool Save();



    }
}
