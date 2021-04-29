using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClub.Windows.Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmLocalidades : Form
    {
        private readonly IServicioLocalidades _Servicio;
        private readonly IServiciosProvincia _ServicioProvincia;
        private List<LocalidadListDto> lista;
        private IMapper _mapper;
        public FrmLocalidades(IServicioLocalidades servicio,IServiciosProvincia serviciosProvincia)
        {
            InitializeComponent();
            _ServicioProvincia = serviciosProvincia;
            _Servicio = servicio;
        }

        private void FrmLocalidades_Load(object sender, EventArgs e)
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
            foreach (var Localidad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, Localidad);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, LocalidadListDto Localidad)
        {
            r.Cells[cmnLocalidad.Index].Value = Localidad.NombreLocalidad;
            r.Cells[CmnProvincia.Index].Value = Localidad.Provincia;
            r.Tag = Localidad;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmLocalidadAE frm = DI.Create<FrmLocalidadAE>();
            frm.Text = "Agregar Nueva localidad";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    LocalidadEditDto LocalidadEditDto = frm.GetLocalidad();
                    if (_Servicio.Existe(LocalidadEditDto))
                    {
                        MessageBox.Show("Localidad Repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        _Servicio.Guardar(LocalidadEditDto);

                        DataGridViewRow r = ConstruirFila();
                        var localidadListDto = _mapper.Map<LocalidadListDto>(LocalidadEditDto);
                        localidadListDto.Provincia = (_ServicioProvincia.GetProvinciaPorId(LocalidadEditDto.ProvinciaId)).NombreProvincia;
                        SetearFila(r, localidadListDto);
                        AgregarFila(r);
                        MessageBox.Show("Localidad Agregada con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception exepcion)
                {

                    MessageBox.Show(exepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var localidadDto = r.Tag as LocalidadListDto;
            var localidadDtoClon = (LocalidadListDto)localidadDto.Clone();
            FrmLocalidadAE frm = DI.Create<FrmLocalidadAE>();
            frm.Text = "Editar Localidad";
            LocalidadEditDto localidadEditDto = _Servicio.GetLocalidadPorId(localidadDto.LocalidadId);
            frm.SetGenero(localidadEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            localidadEditDto = frm.GetLocalidad();
            if (_Servicio.Existe(localidadEditDto))
            {
                MessageBox.Show("Localidad Repetida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, localidadDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(localidadEditDto);
                var localidadListDto = _mapper.Map<LocalidadListDto>(localidadEditDto);
                localidadListDto.Provincia = (_ServicioProvincia.GetProvinciaPorId(localidadEditDto.ProvinciaId)).NombreProvincia;
                SetearFila(r, localidadListDto);
                MessageBox.Show("Localidad Editada con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, localidadDtoClon);

            }


        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var localidadDto = r.Tag as LocalidadListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar la localidad de {localidadDto.NombreLocalidad}?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(localidadDto.LocalidadId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Localidad Eliminada con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            FrmBuscarLocalidad frm = DI.Create<FrmBuscarLocalidad>();
            DialogResult dr = frm.ShowDialog(this);
            if (dr==DialogResult.Cancel)
            {
                return;
            }
            var provinciaDto = frm.GetProvincia();
            try
            {
                lista = _Servicio.GetLista(provinciaDto.NombreProvincia);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}
