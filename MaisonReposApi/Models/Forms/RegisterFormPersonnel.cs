using MaisonReposApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Forms
{
    public class RegisterFormPersonnel
    {
        [Required]
        public string? Nom { get; set; }
        public string? Prenom { get; set; }

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? password { get; set; }
        [Required]
        public string? Matricule { get; set; }
        public bool? IsActive { get; set; } = true;
        [Required]
        public int fonctionId { get; set; }

    }
}
