using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
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
    public partial class FrmDetalleAlquiler : Form
    {
        public FrmDetalleAlquiler()
        {
            InitializeComponent();
        }
        private List<ItemAlquilerListDto> _lista;
        private SocioEditDto socio;
        private void FrmDetalleAlquiler_Load(object sender, EventArgs e)
        {

        }

        internal void SetDetalle(List<ItemAlquilerListDto> itemsAlquileres)
        {
            _lista = itemsAlquileres;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var item in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, item);
                AgregarFila(r);

            }
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ItemAlquilerListDto item)
        {
            r.Cells[cmnPelicula.Index].Value = item.Pelicula;
            //r.Cells[cmnCodigo.Index].Value = item.Pelicula;
            r.Cells[cmnSocio.Index].Value = socio.ToString();
            r.Cells[cmnPrecioAlquiler.Index].Value = item.PrecioAlquiler;

        }

        internal void setSocio(SocioEditDto sociodto)
        {
            socio = sociodto;
        }
    }
}
