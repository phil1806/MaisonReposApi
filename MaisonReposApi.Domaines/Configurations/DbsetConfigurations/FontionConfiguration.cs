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
    public class FontionConfiguration : ConfigurationDesEntites<Fonction>
    {
        public override void Configure(EntityTypeBuilder<Fonction> builder)
        {
            builder.ToTable("Fonctions");

            builder.Property(f => f.fonction)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasIndex(f => f.fonction)
            .IsUnique();
        }
    }
}
