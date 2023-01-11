using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Personnel
    {
      
        public int Id { get; set; }
        public  string? Nom  { get; set; }
        public  string? Prenom {get; set; }
        public string? Email { get; set; }
        public string? Matricule { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public bool? IsActive { get; set; } = true;
        public int ? FonctionId { get; set; } //Foreign key 
       
        public virtual ICollection<Boisson>? Boissons { get; set; } = new List<Boisson>();
        public virtual ICollection<Selle>? Selles { get; set; } = new List<Selle>();
        public virtual ICollection<Toillette>? Toillette { get; set; } = new List<Toillette>();
        public virtual ICollection<Repas>? Repas { get; set; } = new List<Repas>();
        public virtual ICollection<Parametre>? Parametres { get; set; } = new List<Parametre>();
        public virtual ICollection<Therapie>? therapies { get; set; } = new List<Therapie>();
        public virtual ICollection<TrancheHoraire>? trancheHoraires { get; set; } = new List<TrancheHoraire>();
        public virtual ICollection<SoinsAjoutResidantSuivi> SoinsAjoutResidantsSuivis { get; set; } = new List<SoinsAjoutResidantSuivi>();
        public virtual ICollection<SoinsAjout> SoinsAjouts { get; set; } = new List<SoinsAjout>();
        public virtual ICollection<residantSuiviTherapie> residantSuiviTherapies { get; set; } = new List<residantSuiviTherapie>();
        

    }
}
