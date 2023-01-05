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
        DateTime DateTimeRepas{ get; set; } = DateTime.Now;
        public Personnel? personnel { get; set; }
        public CategorieDesSoin? CategorieDesSoin { get; set; }
        public ResidantSuivi? residantSuivi { get; set; }


    }
}
