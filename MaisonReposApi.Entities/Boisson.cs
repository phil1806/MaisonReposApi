using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Boisson
    {
        public int Id { get; set; }
        public string? QteBoisson { get; set; } = "Normal";
        public string? DescBoisson { get; set; }
        public DateTime DateTimeBoisson { get; set; } = DateTime.Now;

        // liste Foreign Key
        public int personnelId { get; set; } 
        public int CategorieDesSoinId { get; set; }
        public int residantSuiviId { get; set; }
        
    }
}
