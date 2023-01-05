using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class TherapieTrancheHoraire
    {
        public int IdTherapie { get; set; }
        public int IdTrancheHoraire { get; set; }
        public Therapie? therapie   { get; set; }
        public TrancheHoraire? trancheHoraire { set; get; }
    }
}
