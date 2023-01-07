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

        //Liste des Foreign Key
        public int personnelCreatedId { get; set; }
        public int CategorieDesSoinId { get; set; }
        public int residantSuiviId { get; set; }

        public  virtual ICollection<residantSuiviTherapie>? ResidantSuiviTherapies { get; set; } = new List<residantSuiviTherapie>();
        public virtual ICollection<TherapieTrancheHoraire>? TherapieTrancheHoraires { get; set; } = new List<TherapieTrancheHoraire>();

    }
}
