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
        public string? PasswordSalt { get; set; }
        public string? PasswordHash { get; set; }
        public bool? IsActive { get; set; }

    }
}
