using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;

namespace MaisonReposApi.Services
{
    public class CategorieDesSoinService : ICategorieDesSoinsService
    {
        private readonly MyDbContext _context;

        public CategorieDesSoinService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permet de vérifier si une categorie existe
        /// </summary>
        /// <param name="catgorieId"></param>
        /// <returns>Booléen</returns>
        public bool CategorieDesSoinsExits(int catgorieId)
        {
            return _context.CategorieDesSoins.Any(x => x.Id == catgorieId);
        }

        /// <summary>
        /// Permet de créer une categorie
        /// </summary>
        /// <param name="categorieDesSoin"></param>
        /// <returns>Booléan</returns>
        public bool CreateCategorieDesSoins(CategorieDesSoin categorieDesSoin)
        {
            _context.Add(categorieDesSoin);
            return Save();
        }


        /// <summary>
        /// Suppression d'une categorie
        /// </summary>
        /// <param name="categorieDessoin"></param>
        /// <returns>Booléan</returns>
        public bool DeleteCategorieDesSoins(CategorieDesSoin categorieDesSoin)
        {
            _context.Remove(categorieDesSoin);
            return Save();
        }


        /// <summary>
        /// Permet de récupérer la liste des categories des soins
        /// </summary>
        /// <returns>IEnumerable<CtegorieDesSoin></returns>
        public IEnumerable<CategorieDesSoin> GetAllCategorieDesSoins()
        {
            return _context.CategorieDesSoins.ToList();
        }

        /// <summary>
        /// Permet de recupérer une categorie via son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CategorieDesSoin</returns>
        public CategorieDesSoin GetCategorieDesSoinsById(int categorieId)
        {
            return _context.CategorieDesSoins.Where(c => c.Id == categorieId).FirstOrDefault();
        }


        /// <summary>
        /// Permet de sauvegardee les datas dans la Db
        /// </summary>
        /// <returns>Booléan</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }


        /// <summary>
        /// Update  une categorie
        /// </summary>
        /// <param name="categorieDesSoin"></param>
        /// <returns>Boolean</returns>
        public bool UpdateCategorieDesSoins(CategorieDesSoin categorieDesSoin)
        {
            _context.Update(categorieDesSoin);
            return Save();
        }
    }
}
