using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class TipoDeSoporteEntityTypeConfigurations:EntityTypeConfiguration<TipoDeSoporte>
    {
        public TipoDeSoporteEntityTypeConfigurations()
        {
            ToTable("TiposDeSoporte");
        }
    }
}
