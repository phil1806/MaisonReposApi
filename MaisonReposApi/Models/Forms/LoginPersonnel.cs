using System.ComponentModel.DataAnnotations;

namespace MaisonReposApi.Models.Forms
{
    public class LoginPersonnel
    {
        [Required]
        [EmailAddress]
        [MaxLength(30)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string? Password { get; set; }
    }
}
