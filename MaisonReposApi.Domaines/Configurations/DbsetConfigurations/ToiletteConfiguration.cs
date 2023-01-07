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
    public class ToiletteConfiguration : ConfigurationDesEntites<Toillette>
    {
        public override void Configure(EntityTypeBuilder<Toillette> builder)
        {
            builder.ToTable("Toillettes");

            builder.Property(T => T.IsDone)
            .IsRequired()
            .HasDefaultValue(true);

            //Relation one-to-many
            builder.HasOne<CategorieDesSoin>()
                .WithMany(C => C.Toillettes)
                .HasForeignKey(b => b.CategorieDesSoinId);

        }
    }
}
