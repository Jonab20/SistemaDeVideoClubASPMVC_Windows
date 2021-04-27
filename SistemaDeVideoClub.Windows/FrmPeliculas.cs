using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
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
    public partial class FrmPeliculas : Form
    {
        private readonly IServicioPelicula _Servicio;
        private readonly IServiciosGenero _ServicioGenero;
        private readonly IServicioCalificaciones _ServicioCalificacion;
        private readonly IServicioEstados _ServicioEstado;
        private List<PeliculaListDto> lista;
        private IMapper _mapper;
        public FrmPeliculas(IServicioPelicula servicio, IServiciosGenero servicioGenero, IServicioCalificaciones servicioCalificacion, IServicioEstados servicioEstado)
        {
            _Servicio = servicio;
            _ServicioGenero = servicioGenero;
            _ServicioCalificacion = servicioCalificacion;
            _ServicioEstado = servicioEstado;
            InitializeComponent();
        }


        private void FrmPeliculas_Load(object sender, EventArgs e)
        {
            _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            try
            {
                lista = _Servicio.GetLista(null);
                MostrarDatosEnGrilla();
            }
            catch (Exception exepcion)
            {
                MessageBox.Show(exepcion.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarDatosEnGrilla()
        {
            DatosDataGridView.Rows.Clear();
            foreach (var Localidad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, Localidad);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            DatosDataGridView.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, PeliculaListDto pelicula)
        {
            r.Cells[cmnTitulo.Index].Value = pelicula.Titulo;
            r.Cells[CmnGenero.Index].Value = pelicula.Genero;
            r.Cells[CmnCalificacion.Index].Value = pelicula.Calificacion;
            r.Cells[CmnEstado.Index].Value = pelicula.Estado;
            r.Cells[CmnFechaIncorporacion.Index].Value = pelicula.FechaIncorporacion;
            r.Cells[CmnAlquilada.Index].Value = pelicula.Alquilado;
            r.Cells[CmnActiva.Index].Value = pelicula.Activa;
            r.Tag = pelicula;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(DatosDataGridView);
            return r;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FrmPeliculasAE frm = DI.Create<FrmPeliculasAE>();
            frm.Text = "Agregar Nueva Pelicula";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    PeliculaEditDto peliculaEditDto = frm.GetPelicula();
                    if (_Servicio.Existe(peliculaEditDto))
                    {
                        MessageBox.Show("Pelicula Repetida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    _Servicio.Guardar(peliculaEditDto);

                    DataGridViewRow r = ConstruirFila();
                    var peliculaListDto = _mapper.Map<PeliculaListDto>(peliculaEditDto);
                    peliculaListDto.Calificacion = (_ServicioCalificacion.GetCalificacionPorId(peliculaEditDto.CalificacionId)).Descripcion;
                    peliculaListDto.Estado = (_ServicioEstado.GetEstadoPorId(peliculaEditDto.EstadoId)).Descripcion;
                    peliculaListDto.Genero = (_ServicioGenero.GetGeneroPorId(peliculaEditDto.GeneroId)).Descripcion;

                    SetearFila(r, peliculaListDto);
                    AgregarFila(r);
                    MessageBox.Show("Pelicula Agregada con Exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var peliculaDto = r.Tag as PeliculaListDto;
            var peliculaDtoClon = (PeliculaListDto)peliculaDto.Clone();
            FrmPeliculasAE frm = DI.Create<FrmPeliculasAE>();
            frm.Text = "Editar Pelicula";
            PeliculaEditDto peliculaEditDto = _Servicio.GetPeliculaPorId(peliculaDto.PeliculaId);
            frm.SetPelicula(peliculaEditDto);

            DialogResult dr = frm.ShowDialog(this);

            if (dr == DialogResult.Cancel)
            {
                return;
            }
            peliculaEditDto = frm.GetPelicula();
            if (_Servicio.Existe(peliculaEditDto))
            {
                MessageBox.Show("pelicula Repetida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SetearFila(r, peliculaDtoClon);
                return;
            }
            try
            {
                _Servicio.Guardar(peliculaEditDto);
                var peliculaListDto = _mapper.Map<PeliculaListDto>(peliculaEditDto);

                peliculaListDto.Calificacion = (_ServicioCalificacion.GetCalificacionPorId(peliculaEditDto.CalificacionId)).Descripcion;
                peliculaListDto.Estado = (_ServicioEstado.GetEstadoPorId(peliculaEditDto.EstadoId)).Descripcion;
                peliculaListDto.Genero = (_ServicioGenero.GetGeneroPorId(peliculaEditDto.GeneroId)).Descripcion;
                SetearFila(r, peliculaListDto);
                MessageBox.Show("Pelicula Editada con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetearFila(r, peliculaDtoClon);

            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }
            var r = DatosDataGridView.SelectedRows[0];
            var peliculaDto = r.Tag as PeliculaListDto;
            DialogResult dr = MessageBox.Show($"¿Desea borrar la pelicula de {peliculaDto.Titulo}?", "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No)
            {
                return;
            }
            try
            {
                _Servicio.Borrar(peliculaDto.PeliculaId);
                DatosDataGridView.Rows.Remove(r);
                MessageBox.Show("Pelicula Eliminada con existo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exepcion)
            {

                MessageBox.Show(exepcion.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            lista = _Servicio.GetLista(null);
            MostrarDatosEnGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            //FrmBuscarPelicula frm = DI.Create<FrmBuscarPelicula>();
            //DialogResult dr = frm.ShowDialog(this);
            //if (dr == DialogResult.Cancel)
            //{
            //    return;
            //}
            //var generoDto = frm.GetGenero();
            //try
            //{
            //    lista = _Servicio.GetLista(generoDto.Descripcion);
            //    MostrarDatosEnGrilla();
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }
    }
}
