using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces;
using System.Xml.Linq;

namespace MaisonReposApi.Services
{
    public class SoinsAjoutService : ISoinsAjoutService
    {
        private readonly MyDbContext _context;

        public SoinsAjoutService(MyDbContext context)
        {
           _context = context;
        }

        public ICollection<SoinsAjout> GetAllSoinsAjouter()
        {
            return _context.SoinsAjouts.ToList();

        }

        public SoinsAjout GetSoinsAjoutById(int soinsAjouterId)
        {
            return _context.SoinsAjouts.Where(s => s.Id == soinsAjouterId).FirstOrDefault();
        }


        public bool SoinsExistById(int id)
        {
            return _context.SoinsAjouts.Any(s => s.Id == id);
        }


        public bool CreateSoinsAjout(SoinsAjout SoinsToCreate)
        {
            _context.Add(SoinsToCreate);
            return Save();
        }

        public bool UpdateSoinsAjout(SoinsAjout soinsAjout)
        {
            _context.Update(soinsAjout);
            return Save();
        }

        public bool DeleteSoinsAjout(SoinsAjout soinsToDelete)
        {
            //Je recupère la liste des élements se trouvant dans la tab Many-to-Many
            var listeElementTabManyToMany = _context.SoinsAjoutResidantSuivis.Where(x => x.IdSoinsAjout == soinsToDelete.Id);

            //Je remove les elements selections dans la tab => Raison :  c'est pour palier au pb du Delete No action
            if (listeElementTabManyToMany != null)
            {
                foreach (var item in listeElementTabManyToMany)
                {
                    _context.Remove(item);
                }
                _context.SaveChanges();
            }
            _context.Remove(soinsToDelete);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

    }
}
