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
    public class SoinsAjoutConfiguration : ConfigurationDesEntites<SoinsAjout>
    {
        public override void Configure(EntityTypeBuilder<SoinsAjout> builder)
        {
            builder.ToTable("SoinsAjouts");

      

            ////Relation one-to-many
            builder.HasOne<CategorieDesSoin>()
            .WithMany(C => C.SoinsAjouts)
            .HasForeignKey(b => b.CategorieDesSoinsId);

            builder.HasOne<Personnel>()
           .WithMany(C => C.SoinsAjouts)
           .HasForeignKey(b => b.PersonnelCreatedId);
        }
    }
}
