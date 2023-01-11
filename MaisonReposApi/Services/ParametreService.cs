using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;

namespace MaisonReposApi.Services
{
    public class ParametreService : IParametreService
    {
        private readonly MyDbContext _context;

        public ParametreService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add  parmaetre 
        /// </summary>
        /// <param name="parametre"></param>
        /// <returns>Boolean</returns>
        public bool AddParametre(Parametre parametre)
        {
            _context.Add(parametre);
            return Save();

        }

        /// <summary>
        /// Delete parametre 
        /// </summary>
        /// <param name="parametre"></param>
        /// <returns>Boolean</returns>
        public bool DeleteParametre(Parametre parametre)
        {
             _context.Remove(parametre);
            return Save();
        }


        /// <summary>
        /// Liste des parametres
        /// </summary>
        /// <returns></returns>
        public ICollection<Parametre> GetAllParametres()
        {
            return _context.Parametres.ToList();
        }


        /// <summary>
        /// Get paramètres by Id
        /// </summary>
        /// <param name="parmatreId"></param>
        /// <returns> parametre</returns>
        public Parametre GetParametreById(int paramId)
        {
          return _context.Parametres.Where(p => p.Id == paramId).FirstOrDefault();
            
        }


        /// <summary>
        /// Permet de verifier si un parmètre existe
        /// </summary>
        /// <param name="paramId"></param>
        /// <returns>Boolean</returns>
        public bool ParametreExist(int paramId)
        {
            return _context.Parametres.Any(p => p.Id == paramId);
        }

        /// <summary>
        /// Save les datas
        /// </summary>
        /// <returns>Booléan</returns>
        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }


        /// <summary>
        /// Modifier un paramètre
        /// </summary>
        /// <param name="param"></param>
        /// <returns>Booléan</returns>
        public bool UpdateParametre(Parametre param)
        {
            _context.Update(param);
            return Save();
        }
    }
}
