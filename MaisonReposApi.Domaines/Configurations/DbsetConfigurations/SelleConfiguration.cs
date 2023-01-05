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
    public class SelleConfiguration : ConfigurationDesEntites<Selle>
    {
        public override void Configure(EntityTypeBuilder<Selle> builder)
        {
            builder.ToTable("Selles");

            builder.Property(s => s.NbreDeSelle)
            .IsRequired()
            .HasDefaultValue(1);

            builder.Property(s => s.DescSelle)
            .IsRequired()
            .HasDefaultValue("Normal");

        }
    }
}
