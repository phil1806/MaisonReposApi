using MaisonReposApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Dtos
{
    public class PersonnelDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public  string? Nom  { get; set; }

        [MaxLength(30)]
        public string? Prenom {get; set; }
        [Required]
        [MaxLength(30)]
        [EmailAddress]
        public string? Email { get; set; }

        public string? Matricule { get; set; }

        [Required]
        public bool? IsActive { get; set; } = true;
        [Required]
        public int? FonctionId { get; set; } //Foreign key 
    }
}
