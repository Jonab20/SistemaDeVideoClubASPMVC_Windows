using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClub.Windows.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmSocios : Form
    {
        private readonly IServiciosSocios _Servicio;
        private readonly IServicioTipoDeDocumento _ServicioTipo;
        private readonly IServicioLocalidades _ServicioLocalidad;
        private readonly IServiciosProvincia _ServicioProvincia;
        private List<SocioListDto> lista;
        private IMapper _mapper;
        public FrmSocios(IServiciosSocios servicio, IServicioTipoDeDocumento servicioTipo, IServicioLocalidades servicioLocalidad, IServiciosProvincia servicioProvincia)
        {
            _Servicio = servicio;
            _ServicioLocalidad = servicioLocalidad;
            _ServicioProvincia = servicioProvincia;
            _ServicioTipo = servicioTipo;
            InitializeComponent();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmSocios_Load(object sender, EventArgs e)
        {
            _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _Servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception exepcion)
            {
                MessageBox.Show(exepcion.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var socio in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, socio);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, SocioListDto socio)
        {
            r.Cells[cmnNombre.Index].Value = socio.Nombre;
            r.Cells[CmnApellido.Index].Value = socio.Apellido;
            r.Cells[cmnTipoDoc.Index].Value = socio.TipoDeDocumento;
            r.Cells[CmnLocalidad.Index].Value = socio.Localidad;
            r.Cells[CmnProvincia.Index].Value = socio.Provincia;
            r.Cells[CmnNumDoc.Index].Value = socio.NroDocumento;
            r.Cells[CmnNumTel.Index].Value = socio.TelefonoMovil;
            r.Cells[CmnSancionado.Index].Value = socio.Sancionado;
            r.Cells[CmnActivo.Index].Value = socio.Activo;
            r.Tag = socio;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var socioDto = r.Tag as SocioListDto;
            var socioDtoClon = (SocioListDto)socioDto.Clone();
            FrmSociosAE frm = DI.Create<FrmSociosAE>();
            frm.Text = "Editar Socio";
            SocioEditDto socioEditDto = _Servicio.GetSocioPorId(socioDto.SocioId);
            frm.SetPelicula(socioEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            socioEditDto = frm.GetSocio();
            if (_Servicio.Existe(socioEditDto))
            {
                MessageBox.Show("Socio Existente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, socioDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(socioEditDto);
                var socioListDto = _mapper.Map<SocioListDto>(socioEditDto);
                socioListDto.TipoDeDocumento = (_ServicioTipo.GetTipoPorId(socioEditDto.TipoDeDocumentoId)).Descripcion;
                socioListDto.Localidad = (_ServicioLocalidad.GetLocalidadPorId(socioEditDto.LocalidadId)).NombreLocalidad;
                socioListDto.Provincia = (_ServicioProvincia.GetProvinciaPorId(socioEditDto.ProvinciaId)).NombreProvincia;

                SetearFila(r, socioListDto);
                MessageBox.Show("Socio Editado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, socioDtoClon);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmSociosAE frm = DI.Create<FrmSociosAE>();
            frm.Text = "Agregar Nuevo Socio";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    SocioEditDto socioEditDto = frm.GetSocio();
                    if (_Servicio.Existe(socioEditDto))
                    {
                        MessageBox.Show("Socio Existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    _Servicio.Guardar(socioEditDto);

                    DataGridViewRow r = ConstruirFila();
                    var socioListDto = _mapper.Map<SocioListDto>(socioEditDto);

                    socioListDto.TipoDeDocumento = (_ServicioTipo.GetTipoPorId(socioEditDto.TipoDeDocumentoId)).Descripcion;
                    socioListDto.Localidad = (_ServicioLocalidad.GetLocalidadPorId(socioEditDto.LocalidadId)).NombreLocalidad;
                    socioListDto.Provincia = (_ServicioProvincia.GetProvinciaPorId(socioEditDto.ProvinciaId)).NombreProvincia;

                    SetearFila(r, socioListDto);
                    AgregarFila(r);
                    MessageBox.Show("Socio Agregado con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exepcion)
                {

                    MessageBox.Show(exepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var socioDto = r.Tag as SocioListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar a {socioDto.Nombre} {socioDto.Apellido} de los socios?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(socioDto.SocioId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Socio Eliminado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            lista = _Servicio.GetLista(null);
            MostrarDatosEnGrilla();
        }
    }
}
