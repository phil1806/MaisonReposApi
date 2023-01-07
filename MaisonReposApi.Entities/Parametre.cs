 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Entities 
{
    public class Parametre
    {
        public int Id { get; set; }
        public int Saturation { get; set; }
        public double Tension { get; set; }
        public double Temperature { get; set; }
        public string? Desc { get; set; }

        //Liste des foreignKey
        public int personnelId { get; set; }
        public int CategorieDesSoinId { get; set; }
        public int residantSuiviId { get; set; }


    }
}
