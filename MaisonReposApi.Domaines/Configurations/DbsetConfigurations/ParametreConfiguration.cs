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
    public class ParametreConfiguration : ConfigurationDesEntites<Parametre>
    {
        public override void Configure(EntityTypeBuilder<Parametre> builder)
        {

            builder.ToTable("Parametres");

            builder.Property(r => r.Temperature)
            .IsRequired()
            .HasDefaultValue(36.7);

            builder.Property(r => r.Saturation)
           .IsRequired()
           .HasDefaultValue(95);

            builder.Property(r => r.Tension)
           .IsRequired()
           .HasDefaultValue(12.6);

            //Relation one-to-many
            builder.HasOne<CategorieDesSoin>()
                .WithMany(C => C.Parametres)
                .HasForeignKey(b => b.CategorieDesSoinId);

        }
    }
}
