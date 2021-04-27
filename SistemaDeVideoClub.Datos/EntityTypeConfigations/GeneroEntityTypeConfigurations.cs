using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos
{
    public class GeneroEntityTypeConfigurations:EntityTypeConfiguration<Genero>
    {
        public GeneroEntityTypeConfigurations()
        {
            ToTable("Generos");
        }
    }
}
