using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class PeliculaEntityTypeConfigurations:EntityTypeConfiguration<Pelicula>
    {
        public PeliculaEntityTypeConfigurations()
        {
            ToTable("Peliculas");
        }
    }
}
