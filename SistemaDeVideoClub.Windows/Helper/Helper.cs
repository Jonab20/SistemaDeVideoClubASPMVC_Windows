using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClub.Windows.Ninject;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows.Helper
{
    public class Helper
    {
        public static void CargarComboProvincia(ref ComboBox cbo)
        {
            IServiciosProvincia servicioProvincia = DI.Create<IServiciosProvincia>();
            var lista = servicioProvincia.GetLista();
            var defautlProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccione una provincia>"
            };
            lista.Insert(0, defautlProvincia);
            cbo.DataSource = lista;
            cbo.ValueMember = "ProvinciaId";
            cbo.DisplayMember = "NombreProvincia";
            cbo.SelectedIndex = 0;

        }
    }
}
