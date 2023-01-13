using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class SelleService : IBaseInterfaceService<Selle>
    {
        private readonly MyDbContext _context;

        public SelleService(MyDbContext context)
        {
             _context = context;
        }
        public bool CreateElement(Selle element)
        {
            _context.Add(element);
            return Save();
        }

        public bool DeleteElement(Selle element)
        {
            _context.Remove(element);
            return Save();
        }

        public bool ElementExists(int Id)
        {
            return _context.Selles.Any(s => s.Id == Id);
        }

        public ICollection<Selle> GetAllElements()
        {
            return _context.Selles.ToList();
        }

        public Selle GetElementById(int id)
        { 
            return _context.Selles.Where(s=>s.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
           return _context.SaveChanges() > 0 ? true : false;
            
        }

        public bool UpdateElement(Selle element)
        {
           _context.Update(element);
            return Save();
        }
    }
}
