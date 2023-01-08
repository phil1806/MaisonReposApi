using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface IResidantService
    {
        IEnumerable<Residant> GetAllResidants();
        Residant GetResidantById(int id);
        bool ResidantExistById(int Id);
        bool ResidantExistByMatricule(string matricule);
        bool CreateResidant(Residant Residant);
        bool DeleteResidant(Residant residant);
        bool UpdateResidant(Residant residant);
        public bool GetStatusResidant(int residantId);
        bool Save();
    }
}
