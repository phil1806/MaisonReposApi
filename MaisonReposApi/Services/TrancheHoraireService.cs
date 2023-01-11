using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class TrancheHoraireService : IBaseInterfaceService<TrancheHoraire>
    {
        private readonly MyDbContext _context;

        public TrancheHoraireService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permet de créer une tranche horaire
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool CreateElement(TrancheHoraire element)
        {
            _context.Add(element);
            return Save();
        }

        /// <summary>
        /// Delete les elemens
        /// </summary>
        /// <param name="trancheHoraire"></param>
        /// <returns>Boolean</returns>
        public bool DeleteElement(TrancheHoraire trancheHoraire)
        {
           _context.Remove(trancheHoraire);
            return Save();
        }

        /// <summary>
        /// Permet de verifier si l'élement existe
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Booléan</returns>
        public bool ElementExists(int Id)
        {
           return _context.TrancheHoraires.Any(el => el.Id == Id);
        }

        /// <summary>
        /// recupère la liste des tranches horaires
        /// </summary>
        /// <returns>Icollection<TrancheHoire></returns>
        public ICollection<TrancheHoraire> GetAllElements()
        {
            return _context.TrancheHoraires.ToList();
        }


        /// <summary>
        /// Permet de recupérer une tranche hoiraire
        /// </summary>
        /// <param name="id"></param>
        /// <returns>tracheHoire</returns>
        public TrancheHoraire GetElementById(int id)
        {
            return _context.TrancheHoraires.Where(t => t.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Peremet de save  les données
        /// </summary>
        /// <returns>Boolean</returns>
        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// Pemet de faire une mise à jour
        /// </summary>
        /// <param name="element"></param>
        /// <returns>Boolean</returns>
        public bool UpdateElement(TrancheHoraire element)
        {
            _context.Update(element);
            return Save();
        }
    }
}
