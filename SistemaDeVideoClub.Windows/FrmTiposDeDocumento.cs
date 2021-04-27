using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
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
    public partial class FrmTiposDeDocumento : Form
    {
        private IServicioTipoDeDocumento _Servicio;
        private List<TipoDeDocumentoListDto> _lista;
        private IMapper _mapper;
        public FrmTiposDeDocumento(IServicioTipoDeDocumento servicio)
        {
            _Servicio = servicio;
            InitializeComponent();
        }

        private void FrmTiposDeDocumento_Load(object sender, EventArgs e)
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
            FrmTiposDeDocumentoAE frm = DI.Create<FrmTiposDeDocumentoAE>();
            frm.Text = "Agregar Nuevo Tipo de Documento";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    TipoDeDocumentoEditDto tipoEditDto = frm.GetTipoDeDocumento();
                    if (_Servicio.Existe(tipoEditDto))
                    {
                        MessageBox.Show("Tipo Repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    _Servicio.Guardar(tipoEditDto);

                    DataGridViewRow r = ConstruirFila();
                    var soporteListDto = _mapper.Map<TipoDeDocumentoListDto>(tipoEditDto);
                    SetearFila(r, soporteListDto);
                    AgregarFila(r);
                    MessageBox.Show("Tipo Agregado con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exepcion)
                {

                    MessageBox.Show(exepcion.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var Tipo in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, Tipo);
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

        private void SetearFila(DataGridViewRow r, TipoDeDocumentoListDto tipo)
        {
            r.Cells[cmnTipo.Index].Value = tipo.Descripcion;

            r.Tag = tipo;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var tipoDto = r.Tag as TipoDeDocumentoListDto;
            var tipoDtoClon = (TipoDeDocumentoListDto)tipoDto.Clone();
            FrmTiposDeDocumentoAE frm = DI.Create<FrmTiposDeDocumentoAE>();
            frm.Text = "Editar Tipo de Documento";
            TipoDeDocumentoEditDto tipoEditDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoDto);
            frm.SetTipoDeDocumento(tipoEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            tipoEditDto = frm.GetTipoDeDocumento();
            if (_Servicio.Existe(tipoEditDto))
            {
                MessageBox.Show("Tipo de documento Repetido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, tipoDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(tipoEditDto);
                var tipoListDto = _mapper.Map<TipoDeDocumentoListDto>(tipoEditDto);
                SetearFila(r, tipoListDto);
                MessageBox.Show("Tipo Editado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, tipoDtoClon);

            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var tipoDto = r.Tag as TipoDeDocumentoListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el {tipoDto.Descripcion}?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(tipoDto.TipoDeDocumentoId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Tipo Eliminado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
