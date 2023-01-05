using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MaisonReposApi.Services
{
    public class FonctionService : IFonctionService
    {
        private readonly myDbContext _context;

        public FonctionService(myDbContext context)
        {
            _context = context;
        }
        public bool CreateFonction(Fonction fonction)
        {
            _context.Add(fonction);
            return Save();
        }

        public bool DeleteFonction(Fonction fonction)
        {
            _context.Remove(fonction);
            return Save();
        }

        public bool FonctionExitsById(int fonctionId)
        {
            return _context.Fonctions.Any(c=>c.Id ==fonctionId);

        }

        public bool FonctionExitsByName(string fonctionName)
        {
            return _context.Fonctions.Any(c => c.fonction == fonctionName);

        }

        public ICollection<Fonction> GetAllFonction()
        {
            return _context.Fonctions.ToList();
        }

        public Fonction GetFonctionById(int fonctionId)
        {
            return _context.Fonctions.Where(f => f.Id == fonctionId).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateFonction(Fonction fonction)
        {
            _context.Update(fonction);
            return Save();
        }
    }
}
