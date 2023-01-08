using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Forms
{
    public class FormCreateResidant
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string? Nom { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        public string? Prenom { get; set; }

        [Required]
        public DateTime DateNass { get; set; } = DateTime.Now;

        [Required]
        public DateTime DateEntre { get; set; } = DateTime.Now;
        public DateTime DateSortie { get; set; } = DateTime.Now;

        [Required]
        public bool? IsActive { get; set; } = true;
    }
}
