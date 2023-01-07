using MaisonReposApi.Domaines.Configurations.DbsetConfigurations;
using MaisonReposApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Domaines.DataContext
{
    public class MyDbContext : DbContext
    {
        //Contructeurs
        public MyDbContext (DbContextOptions< MyDbContext >options): base(options)
        {

        }

        /*--- listes des DbSet ----*/

        //Dbset des acteurs de l'app et les differents rôles 
        public DbSet<Fonction>? Fonctions { get; set; }
        public DbSet <Personnel>?  Personnels { get; set; }
        public DbSet<Residant>? Residants { get; set; }


        //Dbset Pour la liste  des residants suivi et la liste des categories des soins
        public DbSet<ResidantSuivi >? ResidantSuivis { get; set; }
        public DbSet<CategorieDesSoin>? CategorieDesSoins { get; set; }
        public DbSet<SoinsAjout>? SoinsAjouts { get; set; }


        //Dbset  des soins
        public DbSet <Repas>? Repas { get; set; }
        public DbSet<Boisson>? Boissons { get; set; }
        public DbSet<Selle>? Selles { get; set; }
        public DbSet<Toillette>? Toillettes { get; set; }
        public DbSet <Therapie>?  Therapies { get; set; }
        public DbSet<Parametre>? Parametres { get; set; }


        //Dbset Pour la tranche des Horaires
        public DbSet<TrancheHoraire>? TrancheHoraires { get; set; }

        //Dbset relation ManyToMany
        public DbSet<TherapieTrancheHoraire>? TherapieTrancheHoraires { get; set; }
        public DbSet<residantSuiviTherapie>? residantSuiviTherapies { get; set; }
        public DbSet<SoinsAjoutResidantSuivi>? SoinsAjoutResidantSuivis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)  // Configuration des differentes tables
        {
            
            modelBuilder.ApplyConfiguration(new PersonnelConfiguration());
            modelBuilder.ApplyConfiguration(new ResidantConfiguration());
            modelBuilder.ApplyConfiguration(new FontionConfiguration());
            modelBuilder.ApplyConfiguration(new ResidantSuivisConfiguration());
            modelBuilder.ApplyConfiguration(new CategorieDesSoinsConfiguration());

            modelBuilder.ApplyConfiguration(new RepasConfiguration());

            modelBuilder.ApplyConfiguration(new SelleConfiguration());
            modelBuilder.ApplyConfiguration(new BoissonConfiguration());
            modelBuilder.ApplyConfiguration(new ToiletteConfiguration());

            modelBuilder.ApplyConfiguration(new TherapieConfiguration());
            modelBuilder.ApplyConfiguration(new ParametreConfiguration());

            modelBuilder.ApplyConfiguration(new TrancheHoraireConfiguration());
            modelBuilder.ApplyConfiguration(new ResidantSuiviTherapieConfiguration());

            modelBuilder.ApplyConfiguration(new TherapieTrancheHoraireConfiguration());
            modelBuilder.ApplyConfiguration(new SoinsAjoutConfiguration());
            modelBuilder.ApplyConfiguration(new SoinsAjoutResidentSuiviConfiguration());

        }




    }
}
