using SistemaDeVideoClubASPMVC.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    class ProvinciaEntityTypeConfigurations:EntityTypeConfiguration<Provincia>
    {
        public ProvinciaEntityTypeConfigurations()
        {
            ToTable("Provincias");
        }
    }
}
