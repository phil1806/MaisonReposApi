﻿// <auto-generated />
using System;
using MaisonReposApi.Domaines.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MaisonReposApi.Domaines.Migrations
{
    [DbContext(typeof(myDbContext))]
    partial class myDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MaisonReposApi.Entities.Boisson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategorieDesSoinId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeBoisson")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescBoisson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QteBoisson")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Normal");

                    b.Property<int?>("personnelId")
                        .HasColumnType("int");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDesSoinId");

                    b.HasIndex("personnelId");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Boissons", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.CategorieDesSoin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategorieSoin")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("CategorieDesSoins", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Fonction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("fonction")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("fonction")
                        .IsUnique();

                    b.ToTable("Fonctions", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Parametre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategorieDesSoinId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Saturation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(95);

                    b.Property<double>("Temperature")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(36.700000000000003);

                    b.Property<double>("Tension")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(12.6);

                    b.Property<int?>("personnelId")
                        .HasColumnType("int");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDesSoinId");

                    b.HasIndex("personnelId");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Parametres", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Personnel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("FonctionId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("FonctionId");

                    b.HasIndex("Matricule")
                        .IsUnique();

                    b.ToTable("Personnels", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Repas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategorieDesSoinId")
                        .HasColumnType("int");

                    b.Property<string>("DescRepas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QteRepas")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Normal");

                    b.Property<int?>("personnelId")
                        .HasColumnType("int");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDesSoinId");

                    b.HasIndex("personnelId");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Repas", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Residant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateEntre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateNass")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Matricule")
                        .IsUnique()
                        .HasFilter("[Matricule] IS NOT NULL");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Residants", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.ResidantSuivi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Matricule")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Matricule")
                        .IsUnique();

                    b.ToTable("ResidantSuivis", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.residantSuiviTherapie", b =>
                {
                    b.Property<int>("IdTherapie")
                        .HasColumnType("int");

                    b.Property<int>("IdResidantSuivi")
                        .HasColumnType("int");

                    b.Property<int?>("residantId")
                        .HasColumnType("int");

                    b.Property<int?>("therapieId")
                        .HasColumnType("int");

                    b.HasKey("IdTherapie", "IdResidantSuivi");

                    b.HasIndex("IdResidantSuivi");

                    b.HasIndex("residantId");

                    b.HasIndex("therapieId");

                    b.ToTable("ResidantSuiviTherapies", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Selle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategorieDesSoinId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeSelle")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescSelle")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Normal");

                    b.Property<int>("NbreDeSelle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int?>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDesSoinId");

                    b.HasIndex("PersonnelId");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Selles", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Therapie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategorieDesSoinId")
                        .HasColumnType("int");

                    b.Property<string>("DescTherapie")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasDefaultValue("Contactez medecin.");

                    b.Property<DateTime>("Horaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2023, 1, 5, 13, 59, 55, 217, DateTimeKind.Local).AddTicks(4482));

                    b.Property<int?>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDesSoinId");

                    b.HasIndex("PersonnelId");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Therapies", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.TherapieTrancheHoraire", b =>
                {
                    b.Property<int>("IdTherapie")
                        .HasColumnType("int");

                    b.Property<int>("IdTrancheHoraire")
                        .HasColumnType("int");

                    b.Property<int?>("therapieId")
                        .HasColumnType("int");

                    b.Property<int?>("trancheHoraireId")
                        .HasColumnType("int");

                    b.HasKey("IdTherapie", "IdTrancheHoraire");

                    b.HasIndex("IdTrancheHoraire");

                    b.HasIndex("therapieId");

                    b.HasIndex("trancheHoraireId");

                    b.ToTable("TherapieTrancheHoraires", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Toillette", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategorieDesSoinId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeToillette")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescToillete")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int?>("PersonnelId")
                        .HasColumnType("int");

                    b.Property<int?>("residantSuiviId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDesSoinId");

                    b.HasIndex("PersonnelId");

                    b.HasIndex("residantSuiviId");

                    b.ToTable("Toillettes", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.TrancheHoraire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Horaire")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonnelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonnelId");

                    b.ToTable("TrancheHoraires", (string)null);
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Boisson", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.CategorieDesSoin", "CategorieDesSoin")
                        .WithMany("Boissons")
                        .HasForeignKey("CategorieDesSoinId");

                    b.HasOne("MaisonReposApi.Entities.Personnel", "personnel")
                        .WithMany("Boissons")
                        .HasForeignKey("personnelId");

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("Boissons")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("CategorieDesSoin");

                    b.Navigation("personnel");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Parametre", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.CategorieDesSoin", "CategorieDesSoin")
                        .WithMany("Parametres")
                        .HasForeignKey("CategorieDesSoinId");

                    b.HasOne("MaisonReposApi.Entities.Personnel", "personnel")
                        .WithMany("Parametres")
                        .HasForeignKey("personnelId");

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("Parametres")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("CategorieDesSoin");

                    b.Navigation("personnel");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Personnel", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.Fonction", "Fonction")
                        .WithMany("Personnels")
                        .HasForeignKey("FonctionId");

                    b.Navigation("Fonction");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Repas", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.CategorieDesSoin", "CategorieDesSoin")
                        .WithMany("Repas")
                        .HasForeignKey("CategorieDesSoinId");

                    b.HasOne("MaisonReposApi.Entities.Personnel", "personnel")
                        .WithMany("Repas")
                        .HasForeignKey("personnelId");

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("Repas")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("CategorieDesSoin");

                    b.Navigation("personnel");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Residant", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("residants")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.residantSuiviTherapie", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", null)
                        .WithMany("ResidantSuivisTherapies")
                        .HasForeignKey("IdResidantSuivi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaisonReposApi.Entities.Therapie", null)
                        .WithMany("ResidantsuivisTherapies")
                        .HasForeignKey("IdTherapie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residant")
                        .WithMany()
                        .HasForeignKey("residantId");

                    b.HasOne("MaisonReposApi.Entities.Therapie", "therapie")
                        .WithMany()
                        .HasForeignKey("therapieId");

                    b.Navigation("residant");

                    b.Navigation("therapie");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Selle", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.CategorieDesSoin", "CategorieDesSoin")
                        .WithMany("Selles")
                        .HasForeignKey("CategorieDesSoinId");

                    b.HasOne("MaisonReposApi.Entities.Personnel", "Personnel")
                        .WithMany("Selles")
                        .HasForeignKey("PersonnelId");

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("Selles")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("CategorieDesSoin");

                    b.Navigation("Personnel");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Therapie", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.CategorieDesSoin", "CategorieDesSoin")
                        .WithMany("therapies")
                        .HasForeignKey("CategorieDesSoinId");

                    b.HasOne("MaisonReposApi.Entities.Personnel", "Personnel")
                        .WithMany("therapies")
                        .HasForeignKey("PersonnelId");

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("therapies")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("CategorieDesSoin");

                    b.Navigation("Personnel");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.TherapieTrancheHoraire", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.Therapie", null)
                        .WithMany("TherapieTrancheHoraires")
                        .HasForeignKey("IdTherapie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaisonReposApi.Entities.TrancheHoraire", null)
                        .WithMany("TherapieTrancheHoraires")
                        .HasForeignKey("IdTrancheHoraire")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MaisonReposApi.Entities.Therapie", "therapie")
                        .WithMany()
                        .HasForeignKey("therapieId");

                    b.HasOne("MaisonReposApi.Entities.TrancheHoraire", "trancheHoraire")
                        .WithMany()
                        .HasForeignKey("trancheHoraireId");

                    b.Navigation("therapie");

                    b.Navigation("trancheHoraire");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Toillette", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.CategorieDesSoin", "CategorieDesSoin")
                        .WithMany("Toillettes")
                        .HasForeignKey("CategorieDesSoinId");

                    b.HasOne("MaisonReposApi.Entities.Personnel", "Personnel")
                        .WithMany("Toillettes")
                        .HasForeignKey("PersonnelId");

                    b.HasOne("MaisonReposApi.Entities.ResidantSuivi", "residantSuivi")
                        .WithMany("Toillettes")
                        .HasForeignKey("residantSuiviId");

                    b.Navigation("CategorieDesSoin");

                    b.Navigation("Personnel");

                    b.Navigation("residantSuivi");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.TrancheHoraire", b =>
                {
                    b.HasOne("MaisonReposApi.Entities.Personnel", "Personnel")
                        .WithMany("trancheHoraires")
                        .HasForeignKey("PersonnelId");

                    b.Navigation("Personnel");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.CategorieDesSoin", b =>
                {
                    b.Navigation("Boissons");

                    b.Navigation("Parametres");

                    b.Navigation("Repas");

                    b.Navigation("Selles");

                    b.Navigation("Toillettes");

                    b.Navigation("therapies");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Fonction", b =>
                {
                    b.Navigation("Personnels");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Personnel", b =>
                {
                    b.Navigation("Boissons");

                    b.Navigation("Parametres");

                    b.Navigation("Repas");

                    b.Navigation("Selles");

                    b.Navigation("Toillettes");

                    b.Navigation("therapies");

                    b.Navigation("trancheHoraires");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.ResidantSuivi", b =>
                {
                    b.Navigation("Boissons");

                    b.Navigation("Parametres");

                    b.Navigation("Repas");

                    b.Navigation("ResidantSuivisTherapies");

                    b.Navigation("Selles");

                    b.Navigation("Toillettes");

                    b.Navigation("residants");

                    b.Navigation("therapies");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.Therapie", b =>
                {
                    b.Navigation("ResidantsuivisTherapies");

                    b.Navigation("TherapieTrancheHoraires");
                });

            modelBuilder.Entity("MaisonReposApi.Entities.TrancheHoraire", b =>
                {
                    b.Navigation("TherapieTrancheHoraires");
                });
#pragma warning restore 612, 618
        }
    }
}
