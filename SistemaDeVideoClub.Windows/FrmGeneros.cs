using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
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
    public partial class FrmGeneros : Form
    {

        public FrmGeneros()
        {
            InitializeComponent();
        }
        private IServiciosGenero _Servicio;
        private List<GeneroListDto> _listaG;
        private void FrmGeneros_Load(object sender, EventArgs e)
        {
            try
            {
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
    }
}
