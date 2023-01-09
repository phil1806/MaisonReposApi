using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class SoinsAjout
    {
        public int Id { get; set; }
        public string? Titre { get; set; }
        public string? DescSoins { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CategorieDesSoinsId { get; set; }
        public int PersonnelCreatedId { get; set; }
        public  ICollection<SoinsAjoutResidantSuivi>? SoinsAjoutResidantSuivis { get; set; } = new List<SoinsAjoutResidantSuivi>();
    }
}
