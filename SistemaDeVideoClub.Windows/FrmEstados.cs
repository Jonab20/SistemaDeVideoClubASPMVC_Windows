using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
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
    public partial class FrmEstados : Form
    {
        private IServicioEstados _Servicio;
        private List<EstadoListDto> _lista;
        private IMapper _mapper;
        public FrmEstados(IServicioEstados servicio)
        {
            _Servicio = servicio;
            InitializeComponent();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();

        }
        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var estado in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, estado);
                AgregarFila(r);
            }
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, EstadoListDto estado)
        {
            r.Cells[cmnEstado.Index].Value = estado.Descripcion;

            r.Tag = estado;
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmEstadosAE frm = DI.Create<FrmEstadosAE>();
            frm.Text = "Agregar Nuevo Estado";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    EstadoEditDto estadoEitDto = frm.GetGenero();
                    if (_Servicio.Existe(estadoEitDto))
                    {
                        MessageBox.Show("Estado Repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    _Servicio.Guardar(estadoEitDto);

                    DataGridViewRow r = ConstruirFila();
                    var estadoListDto = _mapper.Map<EstadoListDto>(estadoEitDto);
                    SetearFila(r, estadoListDto);
                    AgregarFila(r);
                    MessageBox.Show("Estado Agregado con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exepcion)
                {

                    MessageBox.Show(exepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void FrmEstados_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();
                _lista = _Servicio.GetLista();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var estadoDto = r.Tag as EstadoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar {estadoDto.Descripcion}?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(estadoDto.EstadoId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Estado Eliminado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var estadoDto = r.Tag as EstadoListDto;
            var estadoDtoClon = (EstadoListDto)estadoDto.Clone();
            FrmEstadosAE frm = DI.Create<FrmEstadosAE>();
            frm.Text = "Editar Estado";
            EstadoEditDto estadoEditDto = _mapper.Map<EstadoEditDto>(estadoDto);
            frm.SetEstado(estadoEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            estadoEditDto = frm.GetGenero();
            if (_Servicio.Existe(estadoEditDto))
            {
                MessageBox.Show("Estado Repetido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, estadoDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(estadoEditDto);
                var generoListDto = _mapper.Map<EstadoListDto>(estadoEditDto);
                SetearFila(r, generoListDto);
                MessageBox.Show("Estado Editado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, estadoDtoClon);

            }


        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            _lista = _Servicio.GetLista();
            MostrarDatosEnGrilla();
        }
    }
}
