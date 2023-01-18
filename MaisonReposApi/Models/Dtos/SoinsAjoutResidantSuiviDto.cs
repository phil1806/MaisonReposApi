namespace MaisonReposApi.Models.Dtos
{
    public class SoinsAjoutResidantSuiviDto
    {
        public int Id { get; set; }
        public int IdSoinsAjout { get; set; }
        public int IdResidantSuivi { get; set; }
        public int PersonnelId { get; set; } //Foreign Key
    }
}
