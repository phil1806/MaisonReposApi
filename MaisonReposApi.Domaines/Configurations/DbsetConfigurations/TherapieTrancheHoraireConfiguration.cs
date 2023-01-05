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
    public class TherapieTrancheHoraireConfiguration : ConfigurationDesEntites<TherapieTrancheHoraire>
    {
        public override void Configure(EntityTypeBuilder<TherapieTrancheHoraire> builder)
        {

            builder.ToTable("TherapieTrancheHoraires");

            builder.HasKey(tTH => new {tTH.IdTherapie, tTH.IdTrancheHoraire });

            builder.HasOne<Therapie>()
           .WithMany(t => t.TherapieTrancheHoraires)
           .HasForeignKey(tTH => tTH.IdTherapie);

            builder.HasOne<TrancheHoraire>()
           .WithMany(t => t.TherapieTrancheHoraires)
           .HasForeignKey(tTH => tTH.IdTrancheHoraire);

        }
          
    }
}
