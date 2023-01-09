using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Forms
{
    public class FormAjoutSoins
    {
        [Required]
        [MaxLength(30)]
        [MinLength(10)]
        public string? Titre { get; set; }

        [Required]
        [MaxLength(255)]
        public string? DescSoins { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Required]
        public int CategorieDesSoinsId { get; set; }

        [Required]
        public int PersonnelCreatedId { get; set; }
    }
}
