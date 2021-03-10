using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos
{
   public class SistemaDeVideoClubDbContext:DbContext
    {
        public SistemaDeVideoClubDbContext():base("VideoClubDbContext")
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SistemaDeVideoClubDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());  
        }

        public DbSet<Genero> generos { get; set; }
        public DbSet<Provincia> provincias { get; set; }
    }
}
