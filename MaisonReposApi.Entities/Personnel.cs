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
        public Fonction? Fonction { get; set; }
        public ICollection<Boisson>? Boissons { get; set; }
        public ICollection<Selle>? Selles { get; set; }
        public ICollection<Repas>? Repas { get; set; }
        public ICollection<Toillette>? Toillettes { get; set; }
        public ICollection<Parametre>? Parametres { get; set; }
        public ICollection<Therapie>? therapies { get; set; }
        public ICollection<TrancheHoraire>? trancheHoraires { get; set; }

    }
}
