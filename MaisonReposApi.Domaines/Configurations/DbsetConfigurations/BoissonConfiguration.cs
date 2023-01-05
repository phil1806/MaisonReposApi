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
    public class BoissonConfiguration : ConfigurationDesEntites<Boisson>
    {
        public override void Configure(EntityTypeBuilder<Boisson> builder)
        {
            builder.ToTable("Boissons");

            builder.Property(b =>b.QteBoisson)
            .HasDefaultValue("Normal")
            .IsRequired();
        }
    }
}
