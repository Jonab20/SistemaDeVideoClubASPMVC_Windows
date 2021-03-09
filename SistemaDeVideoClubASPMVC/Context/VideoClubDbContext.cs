using SistemaDeVideoClubASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SistemaDeVideoClubASPMVC.Context
{
    public class VideoClubDbContext:DbContext
    {
        public VideoClubDbContext()
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VideoClubDbContext>(null);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Pelicula>().ToTable("Peliculas");
            modelBuilder.Entity<Genero>().ToTable("Generos");
            modelBuilder.Entity<Calificacion>().ToTable("Calificaciones");
            modelBuilder.Entity<Localidad>().ToTable("Localidades");
            modelBuilder.Entity<Provincia>().ToTable("Provincias");
            modelBuilder.Entity<Estado>().ToTable("Estados");
            modelBuilder.Entity<Socio>().ToTable("Socios");
            modelBuilder.Entity<TipoDeDocumento>().ToTable("TiposDeDocumento");
            modelBuilder.Entity<Soporte>().ToTable("Soportes");
        }

        public DbSet<Pelicula> Peliculas { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<TipoDeDocumento> TiposDeDocumento { get; set; }
        public DbSet<Soporte> Soportes { get; set; }
    }
}