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


            builder.HasOne(p => p.therapie)
                .WithMany(p => p.TherapieTrancheHoraires)
                .HasForeignKey(x => x.IdTherapie)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.trancheHoraire)
              .WithMany(p => p.TherapieTrancheHoraires)
              .HasForeignKey(x => x.IdTrancheHoraire)
              .OnDelete(DeleteBehavior.NoAction);


        }

    }
}
