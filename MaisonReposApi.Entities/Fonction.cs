using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Fonction
    {      
        public int Id { get; set; }
        public string? fonction { get; set; }
        public virtual ICollection<Personnel>? Personnels { get; set; }  = new List<Personnel>();

    }
}
