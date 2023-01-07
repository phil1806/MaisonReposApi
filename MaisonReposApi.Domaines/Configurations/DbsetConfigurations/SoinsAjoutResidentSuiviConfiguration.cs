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
    public class SoinsAjoutResidentSuiviConfiguration : ConfigurationDesEntites<SoinsAjoutResidantSuivi>
    {
        

        public override void Configure(EntityTypeBuilder<SoinsAjoutResidantSuivi> builder)
        {
            builder.ToTable("SoinsAjoutResidantSuivis");


            //Relation Many to many
            builder.HasOne<SoinsAjout>()
            .WithMany(s => s.SoinsAjoutResidantSuivis)
            .HasForeignKey(t => t.IdSoinsAjout)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<ResidantSuivi>()
           .WithMany(s => s.SoinsAjoutResidantSuivis)
           .HasForeignKey(sr => sr.IdResidantSuivi)
           .OnDelete(DeleteBehavior.NoAction);



            //Relation one-to-many
            builder.HasOne<Personnel>()
                .WithMany(C => C.SoinsAjoutResidantsSuivis)
                .HasForeignKey(b => b.PersonnelId)
           .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
