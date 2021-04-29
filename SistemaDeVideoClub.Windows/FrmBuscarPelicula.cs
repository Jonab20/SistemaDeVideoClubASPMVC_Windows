using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
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
    public partial class FrmBuscarPelicula : Form
    {
        private IServicioPelicula _Servicio;
        private IMapper _mapper;
        private List<PeliculaListDto> lista;
        private PeliculaListDto pelicula;
        public FrmBuscarPelicula(IServicioPelicula servicio)
        {
            _Servicio = servicio;
            InitializeComponent();
        }

        private void FrmBuscarPelicula_Load(object sender, EventArgs e)
        {
            lista = _Servicio.GetLista(null);
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var pelicula in lista)
            {
                DataGridViewRow r = ConstruirFila(pelicula);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(PeliculaListDto pelicula)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, pelicula);

            return r;
        }

        private void SetearFila(DataGridViewRow r, PeliculaListDto pelicula)
        {
            r.Cells[cmnTitulo.Index].Value = pelicula.Titulo;
            r.Cells[cmnCodigo.Index].Value = pelicula.CodigoPelicula;
            r.Cells[cmnEstado.Index].Value = pelicula.Estado;
            r.Cells[cmnActiva.Index].Value = pelicula.Activa;


            r.Tag = pelicula;
        }
        public PeliculaListDto GetPelicula()
        {
            return pelicula;
        }


        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                pelicula = (PeliculaListDto)r.Tag;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
