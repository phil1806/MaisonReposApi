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
    public class ResidantSuivisConfiguration : ConfigurationDesEntites<ResidantSuivi>
    {
        public override void Configure(EntityTypeBuilder<ResidantSuivi> builder)
        {
            builder.ToTable("ResidantSuivis");


            builder.Property(rs => rs.Nom)
           .IsRequired()
           .HasMaxLength(30);

            builder.HasIndex(rs => rs.Matricule)
           .IsUnique();

            builder.Property(rs => rs.Matricule)
           .IsRequired()
           .HasMaxLength(30);

          


        }
    }
}
