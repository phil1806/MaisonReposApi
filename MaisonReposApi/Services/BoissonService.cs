using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class BoissonService : IBaseInterfaceService<Boisson>
    {
        private readonly MyDbContext _context;

        public BoissonService(MyDbContext context)
        {
            _context = context;
        }
        public bool CreateElement(Boisson element)
        {
           _context.Add(element);
            return Save();
        }

        public bool DeleteElement(Boisson element)
        {
            _context.Boissons.Remove(element);
            return Save();
        }

        public bool ElementExists(int Id)
        {
            return _context.Boissons.Any(x=> x.Id == Id);  
        }

        public ICollection<Boisson> GetAllElements()
        {
            return _context.Boissons.ToList();
        }

        public Boisson GetElementById(int id)
        {
            return _context.Boissons.Where(x=>x.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;   
        }

        public bool UpdateElement(Boisson element)
        {
            _context?.Update(element);
            return Save();

        }
    }
}
