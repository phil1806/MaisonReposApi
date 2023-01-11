using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class ToilletesService : IBaseInterfaceService<Toillette>
    {
        private readonly MyDbContext _context;

        public ToilletesService(MyDbContext context)
        {
            _context = context;
        }
        public bool CreateElement(Toillette element)
        {
            _context.Add(element);
            return Save();
        }

        public bool DeleteElement(Toillette element)
        {
            _context.Remove(element);
            return Save();
        }

        public bool ElementExists(int Id)
        {
            return _context.Toillettes.Any(r => r.Id == Id);
        }

        public ICollection<Toillette> GetAllElements()
        {
            return _context.Toillettes.ToList();
        }

        public Toillette GetElementById(int id)
        {
            return _context.Toillettes.Where(r => r.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;

        }

        public bool UpdateElement(Toillette element)
        {
            _context.Update(element);
            return Save();
        }
    }
}
