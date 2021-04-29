using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.EntityTypeConfigations
{
    public class ItemAlquilerEntityTypeConfigurations:EntityTypeConfiguration<ItemAlquiler>
    {
        public ItemAlquilerEntityTypeConfigurations()
        {
            ToTable("ItemAlquileres");
        }
    }
}
