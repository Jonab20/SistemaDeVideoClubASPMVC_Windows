//using SistemaDeVideoClubASPMVC.Entidades;
using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class LocalidadesEntityTypeConfigurations:EntityTypeConfiguration<Localidad>
    {
        public LocalidadesEntityTypeConfigurations()
        {
            ToTable("Localidades");
        }
    }
}
