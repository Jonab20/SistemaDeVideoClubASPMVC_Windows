using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Servicios.Servicios;
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
    public partial class FrmAlquileres : Form
    {
        private readonly IServicioAlquiler _servicio;
        private readonly IServiciosSocios _servicioSocio;
        private readonly IServicioPelicula _servicioPelicula;

        private IMapper _mapper;
        private List<AlquilerListDto> _lista;
        public FrmAlquileres(IServicioAlquiler servicio,IServiciosSocios servicioSocio, IServicioPelicula servicioPelicula)
        {
            _servicioSocio = servicioSocio;
            _servicioPelicula = servicioPelicula;
            _servicio = servicio;
            InitializeComponent();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmAlquileresAE frm = DI.Create<FrmAlquileresAE>();
            frm.Text = "Agregar Nueva Pelicula";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var alquilerEditDto = frm.GetAlquiler();
                    _servicio.Guardar(alquilerEditDto);
                    var alquilerListDto = _mapper.Map<AlquilerListDto>(alquilerEditDto);
                    var r = ConstruirFila();
                    SetearFila(r, alquilerListDto);
                    AgregarFila(r);
                    MessageBox.Show("Alquiler agregada", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                   

                }
            }
        }

        private void FrmAlquileres_Load(object sender, EventArgs e)
        {
            _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();
            try
            {
                ActualizarGrilla();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ActualizarGrilla()
        {
            _lista = _servicio.GetLista();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var alquilerListDto in _lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, alquilerListDto);
                AgregarFila(r);
            }
        }

        private void SetearFila(DataGridViewRow r, AlquilerListDto alquilerListDto)
        {
            //r.Cells[cmnSocio.Index].Value = alquilerListDto.SocioId;
            //r.Cells[CmnPelicula.Index].Value = alquilerListDto.;
            r.Cells[cmnFechaAlquiler.Index].Value = alquilerListDto.FechaAlquiler.ToShortDateString();
            r.Cells[cmnAlquilerId.Index].Value = alquilerListDto.AlquilerId;
            r.Tag = alquilerListDto;
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }


        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }

            try
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                var alquilerDto = (AlquilerListDto)r.Tag;
                alquilerDto = _servicio.GetAlquilerPorId(alquilerDto.AlquilerId);
                var socio = _servicioSocio.GetSocioPorId(alquilerDto.SocioId);
                //var peli = _servicioPelicula.GetPeliculaPorId(alquilerDto.pel)
                FrmDetalleAlquiler frm = new FrmDetalleAlquiler();
                frm.Text = $"Detalles del Alquiler {alquilerDto.AlquilerId}";
                frm.setSocio(socio);
                frm.SetDetalle(alquilerDto.ItemsAlquileres);
                frm.ShowDialog(this);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }


        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}
