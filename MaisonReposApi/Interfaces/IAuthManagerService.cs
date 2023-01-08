using MaisonReposApi.Entities;
using MaisonReposApi.Models.Forms;

namespace MaisonReposApi.Interfaces
{
    public interface IAuthManagerService
    {
         bool RegisterPersonnel (Personnel personnel);
         String LoginPersonnel (LoginPersonnel loginPersonnel);
         void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
         bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
         string GenerateToken(Personnel personnel);
         bool MatriculeExistsPersonnel(string matricule);
         bool Save();
    }
}
