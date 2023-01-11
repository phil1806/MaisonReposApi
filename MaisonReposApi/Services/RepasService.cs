using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class RepasService : IBaseInterfaceService<Repas>
    {
        private readonly MyDbContext _context;

        public RepasService(MyDbContext context)
        {
            _context = context;
        }
        public bool CreateElement(Repas element)
        {
            _context.Add(element);
            return Save();
        }

        public bool DeleteElement(Repas element)
        {
            _context.Remove(element);
            return Save();
        }

        public bool ElementExists(int Id)
        {
            return _context.Repas.Any(r => r.Id == Id);
        }

        public ICollection<Repas> GetAllElements()
        {
            return _context.Repas.ToList();
        }

        public Repas GetElementById(int id)
        {
            return _context.Repas.Where(r => r.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;

        }

        public bool UpdateElement(Repas element)
        {
           _context.Update(element);
            return Save();
        }
    }
}
