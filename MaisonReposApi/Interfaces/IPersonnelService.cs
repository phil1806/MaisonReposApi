using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface IPersonnelService
    {
         IEnumerable<Personnel> GetAllPersonnels();
         bool PersonnelExistByEmail(string email);
         bool PersonnelExistById(int id);
         Personnel GetPersonnelByEmail(string email);
         Personnel GetPersonnelById(int id);
         bool UpdatePerrsonnel(Personnel personnel);
         bool DeletePersonnel(Personnel personnel);
         bool Save();
    }
}
