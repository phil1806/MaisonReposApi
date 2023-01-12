using MaisonReposApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Forms
{
    public class RegisterFormPersonnel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string? Nom { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        public string? Prenom { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(8)]
        public string? password { get; set; } = "test1234";

        [Required]
        public bool? IsActive { get; set; } = true;

        [Required]
        public int fonctionId { get; set; }

    }
}
