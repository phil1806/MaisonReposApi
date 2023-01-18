using MaisonReposApi.Domaines.DataContext;
using MaisonReposApi.Entities;
using MaisonReposApi.Interfaces.GeneriqueInterface;

namespace MaisonReposApi.Services
{
    public class SoinsAjout_ResidantSuiviService : IBaseInterfaceService<SoinsAjoutResidantSuivi>
    {
        private readonly MyDbContext _context;

        public SoinsAjout_ResidantSuiviService(MyDbContext context)
        {
            _context = context;
        }

        public ICollection<SoinsAjoutResidantSuivi> GetAllElements()
        {
            return _context.SoinsAjoutResidantSuivis.ToList();
        }

        public SoinsAjoutResidantSuivi GetElementById(int id)
        {
            return _context.SoinsAjoutResidantSuivis.Where(x => x.Id == id).FirstOrDefault();
        }


        public bool CreateElement(SoinsAjoutResidantSuivi element)
        {
            _context.Add(element);
            return Save();
        }

        public bool ElementExists(int Id)
        {
            return _context.SoinsAjoutResidantSuivis.Any(x => x.Id == Id);
        }

        public bool DeleteElement(SoinsAjoutResidantSuivi element)
        {
            _context.Remove(element);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }



        /*-----------------------------------------------------------------------------*/

        public bool UpdateElement(SoinsAjoutResidantSuivi element)
        {
            throw new NotImplementedException();
        }
    }
}
