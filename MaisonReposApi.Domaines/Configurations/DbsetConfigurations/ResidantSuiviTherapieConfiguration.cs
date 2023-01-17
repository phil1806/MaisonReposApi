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
    public class ResidantSuiviTherapieConfiguration :ConfigurationDesEntites<residantSuiviTherapie>
    {

        public override void Configure(EntityTypeBuilder<residantSuiviTherapie> builder)
        {
            builder.ToTable("ResidantSuiviTherapies");

            // One to many => (Personnel - ResidantSuivi)
            builder.HasOne<Personnel>()
            .WithMany(p => p.residantSuiviTherapies)
            .HasForeignKey(rsTh => rsTh.PersonnelDoneId)
            .OnDelete(DeleteBehavior.NoAction);






            //Many- to - Many (residantSuivi -Therapies)
            // builder.HasOne<ResidantSuivi>()
            //.WithMany(rs => rs.ResidantSuiviTherapies)
            //.HasForeignKey(rsTh => rsTh.IdResidantSuivi)
            // .OnDelete(DeleteBehavior.NoAction);


            // builder.HasOne<Therapie>()
            //.WithMany(t => t.ResidantSuiviTherapies)
            //.HasForeignKey(rsTh => rsTh.IdTherapie)
            // .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.residantSuivi)
            .WithMany(x => x.ResidantSuiviTherapies)
            .HasForeignKey(x => x.IdResidantSuivi)
             .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.therapie)
           .WithMany(x => x.ResidantSuiviTherapies)
           .HasForeignKey(x => x.IdTherapie)
           .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
