using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Dtos
{
    public class CategorieDesSoinsDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string? CategorieSoin { get; set; }
    }
}
