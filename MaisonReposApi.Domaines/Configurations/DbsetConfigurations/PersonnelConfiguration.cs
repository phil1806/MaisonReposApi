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
    public class PersonnelConfiguration : ConfigurationDesEntites<Personnel>
    {
        public override void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.ToTable("Personnels");

            builder.Property(p => p.Nom)
            .IsRequired()
            .HasMaxLength(30);

            builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(30);

            builder.HasIndex(p => p.Email,"Key_unique_email")
            .IsUnique();

            builder.HasIndex(p => p.Matricule,"Key_unique_matricule")
            .IsUnique();

            builder.Property(p => p.Matricule)
           .IsRequired()
           .HasMaxLength(30);

            builder.Property(p => p.PasswordHash)
            .IsRequired();

            builder.Property(p => p.PasswordSalt)
           .IsRequired();

            builder.Property(p => p.IsActive)
            .HasDefaultValue(true)
            .IsRequired();
        }
    }
}
