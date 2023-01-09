namespace MaisonReposApi.Models.Dtos
{
    public class SoinsAjoutDto
    {
        public int Id { get; set; }
        public string? Titre { get; set; }
        public string? DescSoins { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public int CategorieDesSoinsId { get; set; }
        public int PersonnelCreatedId { get; set; }
    }
}
