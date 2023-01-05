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
    public class ResidantConfiguration : ConfigurationDesEntites<Residant>
    {
        public override void Configure(EntityTypeBuilder<Residant> builder)
        {
            builder.ToTable("Residants");

            builder.Property(r => r.Nom)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(r => r.DateNass)
            .IsRequired();
    
            builder.HasIndex(r => r.Matricule)
            .IsUnique();

            builder.Property(r => r.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        }
    }
}
