using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaisonReposApi.Domaines.Configurations
{
    public abstract class ConfigurationDesEntites<T> : IEntityTypeConfiguration<T>  //classe Génerique pour la configuration des entites (Models)
        where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);
       
    }
}
