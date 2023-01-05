using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class CategorieDesSoin
    {
        public int Id { get; set; }
        public string? CategorieSoin { get; set; }  
        public ICollection<Boisson>? Boissons { get; set; }  
        public ICollection<Selle>? Selles { get; set; }
        public ICollection<Repas>? Repas { get; set; }
        public ICollection<Toillette>? Toillettes { get; set; }
        public ICollection<Parametre>? Parametres { get; set; }
        public ICollection<Therapie>? therapies { get; set; }
    }
}
