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
        public Personnel? Personnel { get; set; }
        public CategorieDesSoin? CategorieDesSoin { get; set; }
        public ResidantSuivi? residantSuivi { get; set; }

    }
}
