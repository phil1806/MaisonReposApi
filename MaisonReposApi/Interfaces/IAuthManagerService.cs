using MaisonReposApi.Entities;
using MaisonReposApi.Models.Forms;

namespace MaisonReposApi.Interfaces
{
    public interface IAuthManagerService
    {
        public bool RegisterPersonnel (Personnel personnel);
        public String LoginPersonnel (LoginPersonnel loginPersonnel);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool Save();
    }
}
