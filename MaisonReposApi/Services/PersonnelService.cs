using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;

namespace MaisonReposApi.Services
{
    public class PersonnelService : IPersonnelService
    {
        private readonly MyDbContext _context;


        //Constructeur
        public PersonnelService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permet  de recuperer la liste des menbres du Personnel
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Personnel> GetAllPersonnels()
        {
           return  _context.Personnels.ToList();
        }

        public Personnel GetPersonnelByEmail(string email)
        {
            return _context.Personnels.Where(p => p.Email.Trim().ToUpper() == email.Trim().ToUpper()).FirstOrDefault();
        }


        /// <summary>
        /// Permet de Verifier si une personne existe via son adresse Mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool PersonnelExistByEmail(string email)
        {
            return _context.Personnels.Any(x => x.Email.ToLower() == email.ToLower());


        }
    }
}
