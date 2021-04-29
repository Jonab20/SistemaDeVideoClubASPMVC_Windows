using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class AlquileresEntityTypeConfigurations:EntityTypeConfiguration<Alquiler>
    {
        public AlquileresEntityTypeConfigurations()
        {
            ToTable("Alquileres");
        }
    }
}
