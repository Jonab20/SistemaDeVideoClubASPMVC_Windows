using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmGeneros : Form
    {

        public FrmGeneros()
        {
            InitializeComponent();
        }
        private IServiciosGenero _Servicio;
        private List<GeneroListDto> _listaG;
        private IMapper _mapper;
        private void FrmGeneros_Load(object sender, EventArgs e)
        {
            try
            {
                _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();
                _Servicio = new ServiciosGenero();
                _listaG = _Servicio.GetLista();
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
            foreach (var Genero in _listaG)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, Genero);
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

        private void SetearFila(DataGridViewRow r, GeneroListDto genero)
        {
            r.Cells[cmnGenero.Index].Value = genero.Descripcion;

            r.Tag = genero;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmGenerosAE frm = new FrmGenerosAE();
            frm.Text = "Agregar Nuevo Genero";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                   GeneroEditDto generoEitDto = frm.GetGenero();
                    if (_Servicio.Existe(generoEitDto))
                    {
                        MessageBox.Show("Genero Repetido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    _Servicio.Guardar(generoEitDto);
                    
                    DataGridViewRow r = ConstruirFila();
                    var generoListDto = _mapper.Map<GeneroListDto>(generoEitDto);  
                    SetearFila(r, generoListDto);
                    AgregarFila(r);
                    MessageBox.Show("Genero Agregado con Exito","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information) ;
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
            var generoDto = r.Tag as GeneroListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el Genero {generoDto.Descripcion}?","Confirmar borrado",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(generoDto.GeneroId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Genero Eliminado con existo","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var generoDto = r.Tag as GeneroListDto;
            var generoDtoClon = (GeneroListDto)generoDto.Clone();
            FrmGenerosAE frm = new FrmGenerosAE();
            frm.Text = "Editar Genero";
            GeneroEditDto generoEditDto = _mapper.Map<GeneroEditDto>(generoDto);
            frm.SetGenero(generoEditDto);

            DialogResult dr = frm.ShowDialog(this);
            
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            generoEditDto = frm.GetGenero();
            if (_Servicio.Existe(generoEditDto))
            {
                MessageBox.Show("Genero Repetido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetearFila(r, generoDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(generoEditDto);
                var generoListDto = _mapper.Map<GeneroListDto>(generoEditDto);
                SetearFila(r, generoListDto);
                MessageBox.Show("Genero Editado con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, generoDtoClon);

            }

        }
    }
}
