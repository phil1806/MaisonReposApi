using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;

namespace MaisonReposApi.Services
{
    public class SoinsAjoutService : ISoinsAjoutService
    {
        private readonly MyDbContext _context;

        public SoinsAjoutService(MyDbContext context)
        {
           _context = context;
        }

        /// <summary>
        /// Permet de créer un nouveau soins
        /// </summary>
        /// <param name="soinsAjout"></param>
        /// <returns>Boolean</returns>
        public bool CreateSoinsAjout(SoinsAjout SoinsToCreate)
        {
            _context.Add(SoinsToCreate);
            return Save();
        }


        /// <summary>
        /// Suppression d'un soins ajouter
        /// </summary>
        /// <param name="soinsToDelete"></param>
        /// <returns></returns>
        public bool DeleteSoinsAjout(SoinsAjout soinsToDelete)
        {
            _context.Remove(soinsToDelete);
            return Save();
        }


        /// <summary>
        /// Permet de récuperer Liste des soins ajouter
        /// </summary>
        /// <returns>IColection<SoinsAjout></returns>
        public ICollection<SoinsAjout> GetAllSoinsAjouter()
        {
            return _context.SoinsAjouts.ToList();

        }

        /// <summary>
        /// Permet de récupérer un soins ajouter via son Id
        /// </summary>
        /// <param name="soinsAjouterId"></param>
        /// <returns>SoinsAjouter</returns>
        public SoinsAjout GetSoinsAjoutById(int soinsAjouterId)
        {
            return _context.SoinsAjouts.Where(s => s.Id == soinsAjouterId).FirstOrDefault();
        }


        /// <summary>
        /// Permet de save les données dans la base de données
        /// </summary>
        /// <returns>Boolean</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        /// <summary>
        /// Permet de verifier si un soin existe via son Id  dans base de données
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booléan</returns>
        public bool SoinsExistById(int id)
        {
            return _context.SoinsAjouts.Any(s => s.Id == id);
        }
    

        /// <summary>
        /// Permet de mettre à jour un soins ajouté
        /// </summary>
        /// <param name="soinsAjout"></param>
        /// <returns>Booléan</returns>
        public bool UpdateSoinsAjout(SoinsAjout soinsAjout)
        {
            _context.Update(soinsAjout);
            return Save();
        }
    }
}
