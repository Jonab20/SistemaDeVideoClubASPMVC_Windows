using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
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
    public partial class FrmCalificaciones : Form
    {
        private IServicioCalificaciones _Servicio;
        private List<CalificacionListDto> _lista;
        private IMapper _mapper;

        public FrmCalificaciones(IServicioCalificaciones servicio)
        {
            InitializeComponent();
            _Servicio = servicio;
        }
        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var calificacion in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, calificacion);
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

        private void SetearFila(DataGridViewRow r, CalificacionListDto calificacion)
        {
            r.Cells[cmnCalificaciones.Index].Value = calificacion.Descripcion;

            r.Tag = calificacion;
        }


        private void FrmCalificaciones_Load(object sender, EventArgs e)
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmCalificacionesAE frm = DI.Create<FrmCalificacionesAE>();
            frm.Text = "Agregar Nueva Calificacion";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    CalificacionEditDto calificacionEditDto = frm.GetCalificacion();
                    if (_Servicio.Existe(calificacionEditDto))
                    {
                        MessageBox.Show("Calificacion Repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        _Servicio.Guardar(calificacionEditDto);

                        DataGridViewRow r = ConstruirFila();
                        var calificacionListDto = _mapper.Map<CalificacionListDto>(calificacionEditDto);
                        SetearFila(r, calificacionListDto);
                        AgregarFila(r);
                        MessageBox.Show("Calificacion Agregada con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            var calificacionDto = r.Tag as CalificacionListDto;
            var calificacionDtoClon = (CalificacionListDto)calificacionDto.Clone();
            FrmCalificacionesAE frm = DI.Create<FrmCalificacionesAE>();
            frm.Text = "Editar Calificacion";
            CalificacionEditDto calificacionEditDto = _mapper.Map<CalificacionEditDto>(calificacionDto);
            frm.SetCalificacion(calificacionEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            calificacionEditDto = frm.GetCalificacion();
            if (_Servicio.Existe(calificacionEditDto))
            {
                MessageBox.Show("Calificacion Repetida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, calificacionDto);
                return;
            }
            try
            {
                _Servicio.Guardar(calificacionEditDto);
                var generoListDto = _mapper.Map<CalificacionListDto>(calificacionEditDto);
                SetearFila(r, generoListDto);
                MessageBox.Show("Calificacion Editada con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, calificacionDto);

            }


        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            _lista = _Servicio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var calificacionDto = r.Tag as CalificacionListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar {calificacionDto.Descripcion}?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(calificacionDto.CalificacionId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("calificacion Eliminado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}
