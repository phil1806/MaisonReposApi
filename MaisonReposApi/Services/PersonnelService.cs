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
        /// <returns>IEnumerable<Personne></Personne></returns>
        public IEnumerable<Personnel> GetAllPersonnels()
        {
           return  _context.Personnels.ToList();
        }


        /// <summary>
        /// Permet de Verifier si une personne existe via son adresse Mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Booléan</returns>
        public bool PersonnelExistByEmail(string email)
        {
            return _context.Personnels.Any(x => x.Email.ToLower() == email.ToLower());


        }

        /// <summary>
        /// Permet de vérifier si un menbre du Personel existe via son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean</returns>
        public bool PersonnelExistById(int id)
        {
            return _context.Personnels.Any(x => x.Id == id );

        }


        /// <summary>
        /// Permet de recupérer un  menbre du Personel via son Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Personnel GetPersonnelByEmail(string email)
        {
            return _context.Personnels.Where(p => p.Email.Trim().ToUpper() == email.Trim().ToUpper()).FirstOrDefault();
        }

        /// <summary>
        /// Permet de récuperer  un menbre de personnel via son Id 
        /// </summary>
        /// <param name="persoId"></param>
        /// <returns>Personnel</returns>
        public Personnel GetPersonnelById(int persoId)
        {
            return _context.Personnels.Where(p => p.Id == persoId).FirstOrDefault();
        }


        /// <summary>
        /// Permet de faire les modification sur un menbre du personnel
        /// </summary>
        /// <param name="personnel"></param>
        /// <returns>Boolean</returns>
        public bool UpdatePerrsonnel(Personnel personnel)
        {
            _context.Update(personnel);
            return Save();
        }


        /// <summary>
        /// Permet la suppresion d'un menbre du menbre du personnel (Le rendre inactif)
        /// </summary>
        /// <param name="personnel"></param>
        /// <returns>Boolean</returns>
        public bool DeletePersonnel(Personnel personnel)
        {
            _context.Update(personnel);
            return Save();
        }


        /// <summary>
        /// Permet de save les datas dans la Db
        /// </summary>
        /// <returns>booléan</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
