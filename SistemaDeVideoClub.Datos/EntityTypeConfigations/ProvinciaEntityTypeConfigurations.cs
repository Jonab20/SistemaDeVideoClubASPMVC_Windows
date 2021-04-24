using SistemaDeVideoClub.Entidades.Entidades;
//using SistemaDeVideoClubASPMVC.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class ProvinciaEntityTypeConfigurations:EntityTypeConfiguration<Provincia>
    {
        public ProvinciaEntityTypeConfigurations()
        {
            ToTable("Provincias");
        }
    }
}
