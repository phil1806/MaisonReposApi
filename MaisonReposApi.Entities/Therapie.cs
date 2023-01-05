using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{  
    public class Therapie
    {
        public int Id { get; set; }
        public DateTime Horaire { get; set; } = DateTime.Now;        
        public string? DescTherapie { get; set; }
        public CategorieDesSoin? CategorieDesSoin { get; set; }
        public Personnel? Personnel { get; set; }
        public ResidantSuivi? residantSuivi { get; set; }
        public ICollection<residantSuiviTherapie>? ResidantsuivisTherapies { get; set; }
        public ICollection<TherapieTrancheHoraire>? TherapieTrancheHoraires { get; set; }




    }
}
