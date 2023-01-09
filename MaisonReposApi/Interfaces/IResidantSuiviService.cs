using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface IResidantSuiviService
    {
        IEnumerable<ResidantSuivi> GetAllResidantSuivis();
        ResidantSuivi GetResidantSuiviById(int Id);
        ResidantSuivi GetResidantSuiviByMatricule(string matricule);
        bool ResidantSuiviExistById(int Id);
        bool ResidantSuiviExistByMatricule(string matricule);
        bool DeleteResidantSuivi(ResidantSuivi residantSuivi);
        bool CreateResidantSuivi(ResidantSuivi residantSuivi);
        bool Save();
    }
}
