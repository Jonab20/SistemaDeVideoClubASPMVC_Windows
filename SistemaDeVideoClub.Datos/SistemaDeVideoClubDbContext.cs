using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace SistemaDeVideoClub.Datos
{
    public class SistemaDeVideoClubDbContext : DbContext
    {
        public SistemaDeVideoClubDbContext() : base("MiConexion")
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

        public DbSet<Genero> Generos { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<TipoDeDocumento> TiposDeDocumento { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Soporte> Soporte { get; set; }
        public DbSet<Pelicula> Pelicula { get; set; }
        public DbSet<Alquiler> Alquiler { get; set; }
        public DbSet<ItemAlquiler> ItemAlquiler { get; set; }

    }

}
