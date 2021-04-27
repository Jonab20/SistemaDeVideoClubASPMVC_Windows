using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
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
    public partial class FrmSociosAE : Form
    {
        private SocioEditDto socioDto;

        public FrmSociosAE()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (socioDto == null)
                {
                    socioDto = new SocioEditDto();
                }
                socioDto.Nombre = txtNombre.Text;
                socioDto.Apellido = txtApellido.Text;
                socioDto.NroDocumento = txtNumDocumento.Text;
                socioDto.Direccion = txtDireccion.Text;
                socioDto.TelefonoFijo = txtNroTel.Text;
                socioDto.TelefonoMovil = txtNroCel.Text;
                socioDto.CorreoElectronico = txtCorreo.Text;
                socioDto.LocalidadId = ((LocalidadListDto)cboLocalidad.SelectedItem).LocalidadId;
                socioDto.ProvinciaId = ((ProvinciaListDto)cboProvincia.SelectedItem).ProvinciaId;
                socioDto.TipoDeDocumentoId = ((TipoDeDocumentoListDto)cboTipoDocumento.SelectedItem).TipoDeDocumentoId;
                socioDto.FechaDeNacimiento = dateTimeFechaNac.Value;
                socioDto.Activo = chbxActivo.Checked;
                socioDto.Sancionado = chcbxSancionado.Checked;
                DialogResult = DialogResult.OK;
            }


        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Campo obligatorio");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Campo obligatorio");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                errorProvider1.SetError(txtDireccion, "Campo obligatorio");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtNumDocumento.Text))
            {
                errorProvider1.SetError(txtNumDocumento, "Campo obligatorio");
                valido = false;
            }
            if (cboLocalidad.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboLocalidad, "Campo obligatorio");
                valido = false;
            }
            if (cboProvincia.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboProvincia, "Campo obligatorio");
                valido = false;
            }
            if (cboTipoDocumento.SelectedIndex == 0)
            {
                errorProvider1.SetError(cboTipoDocumento, "Campo obligatorio");
                valido = false;
            }
            if (dateTimeFechaNac.Value.AddYears(18)> DateTime.Today)
            {
                errorProvider1.SetError(dateTimeFechaNac, "Debe ser mayor de edad para ser socio");
                //dateTimeFechaNac.Value = DateTime.Today.AddYears(-18);
                valido = false;
            }
            return valido;
        }
        internal void SetPelicula(SocioEditDto socioEditDto)
        {
            socioDto = socioEditDto;
        }

        internal SocioEditDto GetSocio()
        {
            return socioDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboTipoDeDocumento(ref cboTipoDocumento);
            Helper.Helper.CargarComboLocalidad(ref cboLocalidad);
            Helper.Helper.CargarComboProvincia(ref cboProvincia);

            if (socioDto == null)
            {
                dateTimeFechaNac.Value = DateTime.Now;
                return;
            }
            txtNombre.Text = socioDto.Nombre;
            txtApellido.Text = socioDto.Apellido;
            txtNumDocumento.Text = socioDto.NroDocumento;
            txtCorreo.Text = socioDto.CorreoElectronico;
            txtDireccion.Text = socioDto.Direccion;
            txtNroTel.Text = socioDto.TelefonoFijo;
            txtNroCel.Text = socioDto.TelefonoMovil;
            socioDto.FechaDeNacimiento = dateTimeFechaNac.Value;
            cboLocalidad.SelectedValue = socioDto.LocalidadId;
            cboProvincia.SelectedValue = socioDto.ProvinciaId;
            cboTipoDocumento.SelectedValue = socioDto.TipoDeDocumentoId;
        }


        private void FrmSociosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
