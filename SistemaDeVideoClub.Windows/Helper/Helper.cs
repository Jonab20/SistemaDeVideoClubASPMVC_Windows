using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClub.Windows.Ninject;
using System;
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

        public static void CargarComboCalificaion(ref ComboBox cbo)
        {
            IServicioCalificaciones servicioCalificacion = DI.Create<IServicioCalificaciones>();
            var lista = servicioCalificacion.GetLista();
            var defautlCalificacion = new CalificacionListDto
            {
                CalificacionId = 0,
                Descripcion = "<Seleccione una Calificacion>"
            };
            lista.Insert(0, defautlCalificacion);
            cbo.DataSource = lista;
            cbo.ValueMember = "CalificacionId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;

        }

        internal static void CargarComboEstado(ref ComboBox cbo)
        {
            IServicioEstados servicioEstado = DI.Create<IServicioEstados>();
            var lista = servicioEstado.GetLista();
            var defautlEstado = new EstadoListDto
            {
                EstadoId = 0,
                Descripcion = "<Seleccione un Estado>"
            };
            lista.Insert(0, defautlEstado);
            cbo.DataSource = lista;
            cbo.ValueMember = "EstadoId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }

        internal static void CargarComboGenero(ref ComboBox cbo)
        {
            IServiciosGenero servicioGenero = DI.Create<IServiciosGenero>();
            var lista = servicioGenero.GetLista();
            var defautlGenero = new GeneroListDto
            {
                GeneroId = 0,
                Descripcion = "<Seleccione un Genero>"
            };
            lista.Insert(0, defautlGenero);
            cbo.DataSource = lista;
            cbo.ValueMember = "GeneroId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }

        internal static void CargarComboTipoDeDocumento(ref ComboBox cbo)
        {
            IServicioTipoDeDocumento servicioTipo = DI.Create<IServicioTipoDeDocumento>();
            var lista = servicioTipo.GetLista();
            var defautlTipo = new TipoDeDocumentoListDto
            {
                TipoDeDocumentoId = 0,
                Descripcion = "<Seleccione un Tipo De DocumentoId>"
            };
            lista.Insert(0, defautlTipo);
            cbo.DataSource = lista;
            cbo.ValueMember = "TipoDeDocumentoId";
            cbo.DisplayMember = "Descripcion";
            cbo.SelectedIndex = 0;
        }

        internal static void CargarComboLocalidad(ref ComboBox cbo)
        {
            IServicioLocalidades servicioLocalidades = DI.Create<IServicioLocalidades>();
            var lista = servicioLocalidades.GetLista(null);
            var defautlLoc = new LocalidadListDto
            {
                LocalidadId = 0,
                NombreLocalidad = "<Seleccione una localidad>"
            };
            lista.Insert(0, defautlLoc);
            cbo.DataSource = lista;
            cbo.ValueMember = "LocalidadId";
            cbo.DisplayMember = "NombreLocalidad";
            cbo.SelectedIndex = 0;
        }
    }
}
