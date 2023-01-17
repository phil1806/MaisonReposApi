using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class residantSuiviTherapie
    {
        public int Id { get; set; }
        public int IdResidantSuivi { get; set; }
        public int IdTherapie { get; set; }
        public int PersonnelDoneId { get; set; } //Foreign key
        public ResidantSuivi? residantSuivi { get; set; }  
        public Therapie? therapie { get; set; }    
      
    }
}
