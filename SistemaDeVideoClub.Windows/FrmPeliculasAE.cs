using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
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
    public partial class FrmPeliculasAE : Form
    {
        private PeliculaEditDto peliculaDto;

        public FrmPeliculasAE()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (peliculaDto == null)
                {
                    peliculaDto = new PeliculaEditDto();
                }
                peliculaDto.Titulo = txtTitulo.Text;
                peliculaDto.CalificacionId = ((CalificacionListDto)cboCalificacion.SelectedItem).CalificacionId;
                peliculaDto.GeneroId = ((GeneroListDto)cboGenero.SelectedItem).GeneroId;
                peliculaDto.EstadoId = ((EstadoListDto)cboEstado.SelectedItem).EstadoId;
                peliculaDto.DuracionEnMinutos = int.Parse(txtDuracion.Text);
                peliculaDto.FechaIncorporacion = DateTime.Parse(dateTimeFechaIncorporacion.Text);
                peliculaDto.Activa = chkbxActiva.Checked;
                peliculaDto.Alquilado = chkbxAlquilada.Checked;
                DialogResult = DialogResult.OK;
            }

        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                errorProvider1.SetError(txtTitulo, "Campo obligatorio");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtDuracion.Text))
            {     
                errorProvider1.SetError(txtDuracion, "Campo obligatorio");
                valido = false;
            }
            if (cboCalificacion.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboCalificacion, "Debe seleccionar una calificacion");
                valido = false;
            }
            if (cboEstado.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboEstado, "Debe seleccionar un estado");
                valido = false;
            }
            if (cboGenero.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboGenero, "Debe seleccionar un genero");
                valido = false;
            }
            return valido;

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboCalificaion(ref cboCalificacion);
            Helper.Helper.CargarComboEstado(ref cboEstado);
            Helper.Helper.CargarComboGenero(ref cboGenero);

            if (peliculaDto == null)
            {
                dateTimeFechaIncorporacion.Value = DateTime.Now;
                return;
            }
            txtTitulo.Text = peliculaDto.Titulo;
            txtDuracion.Text = peliculaDto.DuracionEnMinutos.ToString();
            cboCalificacion.SelectedValue = peliculaDto.CalificacionId;
            cboEstado.SelectedValue = peliculaDto.EstadoId;
            cboGenero.SelectedValue = peliculaDto.GeneroId;
            dateTimeFechaIncorporacion.Value = peliculaDto.FechaIncorporacion;
            chkbxActiva.Checked = peliculaDto.Activa;
            chkbxAlquilada.Checked = peliculaDto.Alquilado;
            txtObservaciones.Text = peliculaDto.Observaciones;

        }

        internal PeliculaEditDto GetPelicula()
        {
            return peliculaDto;
        }

        private void FrmPeliculasAE_Load(object sender, EventArgs e)
        {
            
        }

        internal void SetPelicula(PeliculaEditDto peliculaEditDto)
        {
            peliculaDto = peliculaEditDto;
        }
    }
}
