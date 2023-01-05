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
    public class TherapieConfiguration : ConfigurationDesEntites<Therapie>
    {
        public override void Configure(EntityTypeBuilder<Therapie> builder)
        {
            builder.ToTable("Therapies");

            builder.Property(th => th.DescTherapie)
            .IsRequired()
            .HasDefaultValue("Contactez medecin.")
            .HasMaxLength(100);

            builder.Property(th => th.Horaire)
            .IsRequired()
            .HasDefaultValue(DateTime.Now);
   


        }
    }
}
