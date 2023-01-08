namespace MaisonReposApi.Models.Dtos
{
    public class ResidantDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Matricule { get; set; }
        public DateTime DateNass { get; set; } = DateTime.Now;
        public DateTime DateEntre { get; set; } = DateTime.Now;
        public DateTime DateSortie { get; set; } = DateTime.Now;
        public bool? IsActive { get; set; } = true;
    }
}
