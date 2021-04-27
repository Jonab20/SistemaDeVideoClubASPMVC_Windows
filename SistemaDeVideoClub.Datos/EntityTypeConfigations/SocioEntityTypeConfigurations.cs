using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class SocioEntityTypeConfigurations:EntityTypeConfiguration<Socio>
    {
        public SocioEntityTypeConfigurations()
        {
            ToTable("Socios");
        }
    }
}
