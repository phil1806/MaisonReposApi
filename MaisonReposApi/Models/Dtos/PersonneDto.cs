using MaisonReposApi.Entities;

namespace MaisonReposApi.Models.Dtos
{
    public class PersonneDto
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
        public string? Email { get; set; }
        public string? Matricule { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public bool? IsActive { get; set; } = true;
        public Fonction? Fonction { get; set; }
    }
}
