using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class TrancheHoraire
    {
        public int Id { get; set; }
        public DateTime Horaire { get; set; }
        public int personnelId { get; set; } //Foreign Key 
        public ICollection<TherapieTrancheHoraire>? TherapieTrancheHoraires { get; set; } = new List<TherapieTrancheHoraire>();


    }
}
