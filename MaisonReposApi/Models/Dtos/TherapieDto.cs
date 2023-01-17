namespace MaisonReposApi.Models.Dtos
{
    public class TherapieDto
    {
        public int Id { get; set; }
        public DateTime Horaire { get; set; } = DateTime.Now;
        public string? DescTherapie { get; set; }

        //Liste des Foreign Key
        public int personnelCreatedId { get; set; }
        public int CategorieDesSoinId { get; set; }
        public int residantSuiviId { get; set; }

    }
}
