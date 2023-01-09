using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;

namespace MaisonReposApi.Services
{
    public class ResidantSuiviService : IResidantSuiviService
    {
        private readonly MyDbContext _context;

        public ResidantSuiviService(MyDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Permet d'ajouter un résiandant actif à la liste des residant suivi
        /// </summary>
        /// <param name="residantSuivi"></param>
        /// <returns>Booléan</returns>
        public bool CreateResidantSuivi(ResidantSuivi residantSuivi)
        {
            _context.Add(residantSuivi);
            return Save();
        }

        /// <summary>
        /// Supprimer un residant dans la liste des résidants suivis
        /// </summary>
        /// <param name="residantSuivi"></param>
        /// <returns>Booléan</returns>
        public bool DeleteResidantSuivi(ResidantSuivi residantSuivi)
        {
            _context.Remove(residantSuivi);
            return Save();
        }

        /// <summary>
        /// Permet recuperer la liste des residants suivi
        /// </summary>
        /// <returns>IEnumerable<ResidantSuivi></returns>
        public IEnumerable<ResidantSuivi> GetAllResidantSuivis()
        {
            return _context.ResidantSuivis.ToList();
        }


        /// <summary>
        /// Permet de récupérer le residant suivis
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>ResidantSuivi</returns>
        public ResidantSuivi GetResidantSuiviById(int Id)
        {
            return _context.ResidantSuivis.Where(r => r.Id == Id).FirstOrDefault();
        }


        /// <summary>
        /// Permet de récupérer un residant suivi via sont Matricule
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns>ResidantSuivi</returns>
        public ResidantSuivi GetResidantSuiviByMatricule(string matricule)
        {
            return _context.ResidantSuivis.Where(r => r.Matricule.ToUpper() == matricule.ToUpper()).FirstOrDefault();
        }


        /// <summary>
        /// Permet de verifier si le résidant existe bien dans la liste des residants suivi
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Booléan</returns>
        public bool ResidantSuiviExistById(int Id)
        {
            return _context.ResidantSuivis.Any(r => r.Id == Id);
        }

        /// <summary>
        /// Permet deverifier si le résidant existe déjà la liste des residant suivi
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>
        public bool ResidantSuiviExistByMatricule(string matricule)
        {
            return _context.ResidantSuivis.Any(rs => rs.Matricule.ToUpper() == matricule.ToUpper());
        }


        /// <summary>
        /// Permet de save les données dans la Db
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }



    }
}
