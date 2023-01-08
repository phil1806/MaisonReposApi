namespace MaisonReposApi.Models.Dtos
{
    public class ResidantSuiviDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Matricule { get; set; }
        public DateTime DateInscription { get; set; } = DateTime.Now;
        public int residantId { get; set; } // Foreign Key 
    }
}
