using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Dtos
{
    public class ParametreDto
    {

        public int Id { get; set; }
        public int Saturation { get; set; }
        public double Tension { get; set; }
        public double Temperature { get; set; }
        public string? Desc { get; set; }

        //Liste des foreignKey
        [Required]
        public int personnelId { get; set; }

        [Required]
        public int CategorieDesSoinId { get; set; }

        [Required]
        public int residantSuiviId { get; set; }
    }
}
