using MaisonReposApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Domaines.Configurations.DbsetConfigurations
{
    public class TrancheHoraireConfiguration : ConfigurationDesEntites<TrancheHoraire>
    {
 

        public override void Configure(EntityTypeBuilder<TrancheHoraire> builder)
        {

            builder.ToTable("TrancheHoraires");

            builder.Property(tranche => tranche.Horaire)
                     .IsRequired();
        }
    }
}
