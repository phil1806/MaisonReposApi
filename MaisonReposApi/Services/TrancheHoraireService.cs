using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;
using System.Xml.Linq;

namespace MaisonReposApi.Services
{
    public class TrancheHoraireService : IBaseInterfaceService<TrancheHoraire>
    {
        private readonly MyDbContext _context;

        public TrancheHoraireService(MyDbContext context)
        {
            _context = context;
        }


        public ICollection<TrancheHoraire> GetAllElements()
        {
            return _context.TrancheHoraires.ToList();
        }


        public TrancheHoraire GetElementById(int id)
        {
            return _context.TrancheHoraires.Where(t => t.Id == id).FirstOrDefault();
        }


        public bool ElementExists(int Id)
        {
            return _context.TrancheHoraires.Any(el => el.Id == Id);
        }
   
        public bool CreateElement(TrancheHoraire element)
        {
            _context.Add(element);
            return Save();
        }


        public bool UpdateElement(TrancheHoraire element)
        {
            _context.Update(element);
            return Save();
        }

        public bool DeleteElement(TrancheHoraire trancheHoraire)
        {
            //Je recupère la liste des élements se trouvant dans la tab Many-to-Many
            var listeElementTabManyToMany = _context.TherapieTrancheHoraires.Where(x => x.IdTrancheHoraire == trancheHoraire.Id);

            //Je remove les elements selections dans la tab => Raison :  c'est palier au pb du Delete No action
            if (listeElementTabManyToMany != null)
            {
                foreach (var item in listeElementTabManyToMany)
                {
                    _context.Remove(item);
                }
                _context.SaveChanges();
            }
            _context.Remove(trancheHoraire);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
