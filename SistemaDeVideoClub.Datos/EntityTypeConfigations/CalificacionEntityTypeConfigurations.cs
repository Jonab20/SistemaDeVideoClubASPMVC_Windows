using SistemaDeVideoClub.Entidades.Entidades;
//using SistemaDeVideoClubASPMVC.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class CalificacionEntityTypeConfigurations: EntityTypeConfiguration<Calificacion>
    {
        public CalificacionEntityTypeConfigurations()
        {
            ToTable("Calificaciones");
        }
    }
}
