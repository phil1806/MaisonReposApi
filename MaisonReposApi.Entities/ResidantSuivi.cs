using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class ResidantSuivi
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Matricule { get; set; }
        public int residantId { get; set; } // Foreign Key 

        public  ICollection<residantSuiviTherapie>? ResidantSuiviTherapies { get; set; } = new List<residantSuiviTherapie>();
        public  ICollection<SoinsAjoutResidantSuivi>? SoinsAjoutResidantSuivis { get; set; } = new List<SoinsAjoutResidantSuivi>();

        public virtual ICollection<Boisson>? Boissons { get; set; } =new List<Boisson>();
        public virtual ICollection<Selle>? Selles { get; set; } = new List<Selle>();
        public virtual ICollection<Repas>? Repas { get; set; } = new List<Repas>();
        public virtual ICollection<Toillette>? Toillettes { get; set; } = new List<Toillette>();
        public virtual ICollection<Parametre>? Parametres { get; set; } = new List<Parametre>();
        public virtual ICollection<Therapie>? therapies { get; set; } = new List<Therapie>();


    }
}
