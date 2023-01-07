using MaisonReposApi.Entities;

namespace MaisonReposApi.Interfaces
{
    public interface IPersonnelService
    {
        public IEnumerable<Personnel> GetAllPersonnels();
        public bool PersonnelExistByEmail(string email);

        public Personnel GetPersonnelByEmail(string email);
    }
}
