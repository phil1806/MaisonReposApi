using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Repas
    {
        public int Id { get; set; }
        public string?  QteRepas { get; set; }
        public string? DescRepas { get; set; }
        public DateTime? DateTimeRepas { get; set; }

        //Liste des foreign key
        public int personnelId { get; set; }
        public int CategorieDesSoinId { get; set; }
        public int residantSuiviId { get; set; }


    }
}
