using SistemaDeVideoClub.Entidades.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class TipoDeDocumentoEntityTypeConfigurations:EntityTypeConfiguration<TipoDeDocumento>
    {
        public TipoDeDocumentoEntityTypeConfigurations()
        {
            ToTable("TiposDeDocumento");
        }
    }
}
