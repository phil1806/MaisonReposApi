using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class TherapieTrancheHoraireService : IBaseInterfaceService<TherapieTrancheHoraire>
    {
        private readonly MyDbContext _context;

        public TherapieTrancheHoraireService(MyDbContext context)
        {
            _context = context;
        }

        public ICollection<TherapieTrancheHoraire> GetAllElements()
        {
            return _context.TherapieTrancheHoraires.ToList();
        }

        public bool CreateElement(TherapieTrancheHoraire element)
        {
            _context.Add(element);
            return Save();
        }

        public bool DeleteElement(TherapieTrancheHoraire element)
        {
            _context.Remove(element);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        /*-------------------------------------------------------------*/
        public bool ElementExists(int Id)
        {
           return _context.TherapieTrancheHoraires.Any(x => x.IdTherapie == Id);
        }

        public TherapieTrancheHoraire GetElementById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateElement(TherapieTrancheHoraire element)
        {
            throw new NotImplementedException();
        }
    }
}
