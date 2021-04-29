using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Soporte;
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
    public partial class FrmSoportes : Form
    {
        private IServicioSoporte _Servicio;
        private List<SoporteListDto> _lista;
        private IMapper _mapper;
        public FrmSoportes(IServicioSoporte Servicio)
        {
            _Servicio = Servicio;
            InitializeComponent();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmSoportesAE frm = DI.Create<FrmSoportesAE>();
            frm.Text = "Agregar Nuevo Soporte";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    SoporteEditDto soporteEditDto = frm.GetSoporte();
                    if (_Servicio.Existe(soporteEditDto))
                    {
                        MessageBox.Show("Soporte Repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        _Servicio.Guardar(soporteEditDto);

                        DataGridViewRow r = ConstruirFila();
                        var soporteListDto = _mapper.Map<SoporteListDto>(soporteEditDto);
                        SetearFila(r, soporteListDto);
                        AgregarFila(r);
                        MessageBox.Show("Soporte Agregado con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception exepcion)
                {

                    MessageBox.Show(exepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmSoportes_Load(object sender, EventArgs e)
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
        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var Soporte in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, Soporte);
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

        private void SetearFila(DataGridViewRow r, SoporteListDto soporte)
        {
            r.Cells[cmnSoporte.Index].Value = soporte.Descripcion;

            r.Tag = soporte;
        }



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var soporteDto = r.Tag as SoporteListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el soporte {soporteDto.Descripcion}?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(soporteDto.SoporteId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Soporte Eliminado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var soporteDto = r.Tag as SoporteListDto;
            var soporteDtoClon = (SoporteListDto)soporteDto.Clone();
            FrmSoportesAE frm = DI.Create<FrmSoportesAE>();
            frm.Text = "Editar Soporte";
            SoporteEditDto soporteEditDto = _mapper.Map<SoporteEditDto>(soporteDto);
            frm.SetSoporte(soporteEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            soporteEditDto = frm.GetSoporte();
            if (_Servicio.Existe(soporteEditDto))
            {
                MessageBox.Show("Soporte Repetido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, soporteDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(soporteEditDto);
                var soporteListDto = _mapper.Map<SoporteListDto>(soporteEditDto);
                SetearFila(r, soporteListDto);
                MessageBox.Show("Soporte Editado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, soporteDtoClon);

            }


        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            _lista = _Servicio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
