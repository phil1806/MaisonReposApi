using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Boisson
    {
        public int Id { get; set; }
        public string? QteBoisson { get; set; } = "Normal";
        public string? DescBoisson { get; set; }
        public DateTime DateTimeBoisson { get; set; } = DateTime.Now;
        public Personnel? personnel { get; set; }
        public CategorieDesSoin? CategorieDesSoin { get; set; }
        public ResidantSuivi? residantSuivi { get; set; }

    }
}
