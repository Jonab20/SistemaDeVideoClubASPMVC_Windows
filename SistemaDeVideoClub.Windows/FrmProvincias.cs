using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClub.Windows.Ninject;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmProvincias : Form
    { 
        public FrmProvincias(IServiciosProvincia servicio)
        {
            InitializeComponent();
            _Servicio = servicio;
        }

        private IServiciosProvincia _Servicio;
        private List<ProvinciaListDto> _listaP;
        private IMapper _mapper;

        private void FrmProvincias_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();
                _listaP = _Servicio.GetLista();
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
            foreach (var provincia in _listaP)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, provincia);
                AgregarFila(r);
            }
        }
        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }
        private void SetearFila(DataGridViewRow r, ProvinciaListDto provincia)
        {
            r.Cells[cmnProvincia.Index].Value = provincia.NombreProvincia;
            r.Tag = provincia;
        }
        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmProvinciasAE frm = DI.Create<FrmProvinciasAE>();
            frm.Text = "Agregar Nueva Provincia";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    ProvinciaEditDto provinciaEditDto = frm.GetProvincia();
                    if (_Servicio.Existe(provinciaEditDto))
                    {
                        MessageBox.Show("Provincia Repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    _Servicio.Guardar(provinciaEditDto);

                    DataGridViewRow r = ConstruirFila();
                    var provinciaListDto = _mapper.Map<ProvinciaListDto>(provinciaEditDto);
                    SetearFila(r, provinciaListDto);
                    AgregarFila(r);
                    MessageBox.Show("Provincia Agregada con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var provinciaDto = r.Tag as ProvinciaListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar a pronc{provinciaDto.NombreProvincia}?","Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(provinciaDto.ProvinciaId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Provincia Eliminada con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var provinciaDto = r.Tag as ProvinciaListDto;
            var generoDtoClon = (ProvinciaListDto)provinciaDto.Clone();
            FrmProvinciasAE frm = DI.Create<FrmProvinciasAE>();
            frm.Text = "Editar Provincia";
            ProvinciaEditDto provinciaEditDto = _mapper.Map<ProvinciaEditDto>(provinciaDto);
            frm.SetProvincia(provinciaEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            provinciaEditDto = frm.GetProvincia();
            if (_Servicio.Existe(provinciaEditDto))
            {
                MessageBox.Show("Provincia Repetida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetearFila(r, generoDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(provinciaEditDto);
                var provinciaListDto = _mapper.Map<ProvinciaListDto>(provinciaEditDto);
                SetearFila(r, provinciaListDto);
                MessageBox.Show("Provincia Editada con exito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {
                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, generoDtoClon);
            }
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            _listaP = _Servicio.GetLista();
            MostrarDatosEnGrilla();
        }
    }
}
