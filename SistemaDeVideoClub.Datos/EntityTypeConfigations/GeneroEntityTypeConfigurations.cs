using SistemaDeVideoClubASPMVC.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos
{
    class GeneroEntityTypeConfigurations:EntityTypeConfiguration<Genero>
    {
        public GeneroEntityTypeConfigurations()
        {
            ToTable("Generos");
        }
    }
}
