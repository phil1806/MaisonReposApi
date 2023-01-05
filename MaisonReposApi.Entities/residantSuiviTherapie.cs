using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class residantSuiviTherapie
    {
        public int IdResidantSuivi { get; set; }
        public int IdTherapie { get; set; }
        public ResidantSuivi? residant { get; set; }  
        public Therapie? therapie { get; set; }
    }
}
