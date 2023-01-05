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
    public class CategorieDesSoinsConfiguration : ConfigurationDesEntites<CategorieDesSoin>
    {
        public override void Configure(EntityTypeBuilder<CategorieDesSoin> builder)
        {
            builder.ToTable("CategorieDesSoins");

            builder.Property(p => p.CategorieSoin)
            .IsRequired()
            .HasMaxLength(30);


        }
    }
}
