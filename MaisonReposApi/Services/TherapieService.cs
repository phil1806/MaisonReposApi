using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class TherapieService : IBaseInterfaceService<Therapie>
    {
        private readonly MyDbContext _context;

        public TherapieService(MyDbContext context)
        {
           _context = context;
        }
        public bool CreateElement(Therapie element)
        {
             _context.Add(element);
            return Save();
        }

        public bool DeleteElement(Therapie element)
        {
            var listeElementTabManyToMany = _context.TherapieTrancheHoraires.Where(x => x.IdTherapie == element.Id);

            if(listeElementTabManyToMany != null)
            {
                foreach (var item in listeElementTabManyToMany)
                {
                    _context.Remove(item);
                }
                    _context.SaveChanges();
            }
            _context.Remove(element);

            return Save();

        }
        public bool ElementExists(int Id)
        {
            return _context.Therapies.Any(x => x.Id == Id);
        }

        public ICollection<Therapie> GetAllElements()
        {
            return _context.Therapies.ToList();
        }

        public Therapie GetElementById(int id)
        {
            return _context.Therapies.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateElement(Therapie element)
        {
            _context.Update(element);
            return Save();
        }
    }
}
