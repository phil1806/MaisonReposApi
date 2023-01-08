using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;

namespace MaisonReposApi.Services
{
    public class ResidantService : IResidantService
    {
        private readonly MyDbContext _context;


        //Constructeur
        public ResidantService(MyDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Permet de créer un nouveau Residant
        /// </summary>
        /// <param name="residant"></param>
        /// <returns>Booléan</returns>
        public bool CreateResidant(Residant residant)
        {
            _context.Add(residant);
            return Save();
        }


        /// <summary>
        /// Permet de supprimer un Residant (le mettre  inactif)
        /// </summary>
        /// <param name="residant"></param>
        /// <returns>Booléan</returns>
        public bool DeleteResidant(Residant residant)
        {
            _context.Update(residant);
            return Save();
        }


        /// <summary>
        /// Permet de recupérer la liste des residants
        /// </summary>
        /// <returns> IEnumerable<Residant></returns>
        public IEnumerable<Residant> GetAllResidants()
        {
            return _context.Residants.ToList();
        }

        /// <summary>
        /// Permet de recupérer un residant Via son Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Residant</returns>
        public Residant GetResidantById(int Id)
        {
            return _context.Residants.Where(r => r.Id == Id).FirstOrDefault();
        }


        /// <summary>
        /// Permet de veriefier si le residant existe bien dans la Db
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Boolean</returns>
        public bool ResidantExistById(int Id)
        {
            return _context.Residants.Any(r => r.Id == Id);
        }

        /// <summary>
        /// Permet de verifier si un residant déjà dans la Db avec le matricule passé en paramètre 
        /// </summary>
        /// <param name="matricule"></param>
        /// <returns></returns>
        public bool ResidantExistByMatricule(string matricule)
        {
            return _context.Residants.Any(m => m.Matricule.ToUpper() == matricule.ToUpper());
        }

        /// <summary>
        /// Permet de save les data
        /// </summary>
        /// <returns>Booléan</returns>
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        /// <summary>
        /// Permet de Update le residant
        /// </summary>
        /// <param name="residant"></param>
        /// <returns>Booléan</returns>
        public bool UpdateResidant(Residant residant)
        {
            _context.Update(residant);
            return Save();
        }

        /// <summary>
        /// Permet de recupérer le status d'un residant (actif ou inactif)
        /// </summary>
        /// <param name="residantId"></param>
        /// <returns>Booléan</returns>
        public bool GetStatusResidant(int residantId)
        {
            Residant residant = GetResidantById(residantId);
            if(residant != null)
                return residant.IsActive == true ? true : false;
            return false;
        }
    }
}
