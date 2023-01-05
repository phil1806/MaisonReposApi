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
    public class ResidantSuiviTherapieConfiguration :ConfigurationDesEntites<residantSuiviTherapie>
    {

        public override void Configure(EntityTypeBuilder<residantSuiviTherapie> builder)
        {
            builder.ToTable("ResidantSuiviTherapies");

            builder.HasKey(rsTh => new { rsTh.IdTherapie, rsTh.IdResidantSuivi });

            builder.HasOne<ResidantSuivi>()
           .WithMany(rs => rs.ResidantSuivisTherapies)
           .HasForeignKey(rsTh => rsTh.IdResidantSuivi);

            builder.HasOne<Therapie>()
            .WithMany(t => t.ResidantsuivisTherapies)
            .HasForeignKey(rsTh => rsTh.IdTherapie);

        }
    }
}
