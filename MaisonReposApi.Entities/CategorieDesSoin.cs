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
        public virtual ICollection<Boisson>? Boissons { get; set; } = new List<Boisson>();
        public virtual ICollection<Selle>? Selles { get; set; } = new List<Selle>();
        public virtual ICollection<Repas>? Repas { get; set; } = new List<Repas>();
        public virtual ICollection<Toillette>? Toillettes { get; set; } = new List<Toillette>();
        public virtual ICollection<Parametre>? Parametres { get; set; } = new List<Parametre>();
        public virtual ICollection<Therapie>? therapies { get; set; } = new List<Therapie>();
        public virtual ICollection<SoinsAjout>? SoinsAjouts { get; set; } = new List<SoinsAjout>();
    }
}
