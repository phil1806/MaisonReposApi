using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Selle
    {
        public int Id { get; set; }
        public int NbreDeSelle { get; set; }
        public string?  DescSelle { get; set; }
        public DateTime DateTimeSelle { get; set; } = DateTime.Now;

        // liste Foreign Key
        public int personnelId { get; set; }
        public int CategorieDesSoinId { get; set; }
        public int residantSuiviId { get; set; }


    }
}
