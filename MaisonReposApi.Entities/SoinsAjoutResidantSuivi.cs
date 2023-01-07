using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class SoinsAjoutResidantSuivi
    {
        public int Id { get; set; }
        public int IdSoinsAjout { get; set; }
        public int IdResidantSuivi { get; set; }
        public int PersonnelId { get; set; } //Foreign Key
        public ResidantSuivi? ResidantSuivi { get; set; }
        public SoinsAjout? SoinsAjout { get; set; }
     
    }
}
