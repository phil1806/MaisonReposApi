using AutoMapper;
using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using MaisonReposApi.Models.Forms;
using System.Security.Cryptography;
using System.Text;

namespace MaisonReposApi.Services
{
    public class AuthManagerService : IAuthManagerService
    {


        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public AuthManagerService(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public string LoginPersonnel(LoginPersonnel loginPersonnel)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permet d'enregister un menbre du Personel
        /// </summary>
        /// <param name="registerFormPersonnel"></param>
        /// <returns>Booleean</returns>
        public bool RegisterPersonnel(Personnel personnel)
        {
            _context.Add(personnel);
            return Save();
        }



        /// <summary>
        /// Permet d'enregistrer une Data dans la base de données,
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        /// <summary>
        /// Permet le hashage du mot de passe
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
