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
    public class RepasConfiguration : ConfigurationDesEntites<Repas>
    {
        public override void Configure(EntityTypeBuilder<Repas> builder)
        {
            builder.ToTable("Repas");

            builder.Property(r => r.QteRepas)    
            .HasDefaultValue("Normal")            
            .IsRequired();

            //Relation one-to-many
            builder.HasOne<CategorieDesSoin>()
                .WithMany(C => C.Repas)
                .HasForeignKey(b => b.CategorieDesSoinId);
        }
    }
}
