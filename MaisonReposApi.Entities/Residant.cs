using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Residant
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Matricule { get; set; }
        public DateTime DateNass { get; set; } = DateTime.Now;
        public DateTime DateEntre { get; set; } = DateTime.Now;
        public DateTime DateSortie { get; set; }=DateTime.Now;
        public bool? IsActive { get; set; }
    }
}
