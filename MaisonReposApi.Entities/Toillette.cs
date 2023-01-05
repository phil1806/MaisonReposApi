using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities
{
    public class Toillette
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public string?  DescToillete { get; set; }
        public DateTime DateTimeToillette { get; set; } = DateTime.Now;
        public Personnel? Personnel { get; set; }
        public CategorieDesSoin? CategorieDesSoin { get; set; }
        public ResidantSuivi? residantSuivi { get; set; }


    }
}
