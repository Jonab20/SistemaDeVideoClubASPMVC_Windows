using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClub.Windows.Ninject;
using System;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmLocalidadAE : Form
    {
        private LocalidadEditDto localidadDto;
        public FrmLocalidadAE()
        {
            InitializeComponent();
        }

        internal LocalidadEditDto GetLocalidad()
        {
            return localidadDto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                if (localidadDto == null)
                {
                    localidadDto = new LocalidadEditDto();
                }
                localidadDto.NombreLocalidad = LocalidadTxt.Text;
                localidadDto.ProvinciaId = ((ProvinciaListDto)cboProvincias.SelectedItem).ProvinciaId;

                DialogResult = DialogResult.OK;
            }
        }

        private bool validarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(LocalidadTxt.Text))
            {
                errorProvider1.SetError(LocalidadTxt, "Campo obligatorio");
                valido = false;
            } 
            return valido;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Helper.Helper.CargarComboProvincia(ref cboProvincias);
            if (localidadDto == null)
            {
                return;
            }
            LocalidadTxt.Text = localidadDto.NombreLocalidad;
            //cboProvincias.SelectedIndex = localidadDto.ProvinciaId;
            cboProvincias.SelectedValue = localidadDto.ProvinciaId;

        }
        private void FrmLocalidadAE_Load(object sender, EventArgs e)
        {

        }

        internal void SetGenero(LocalidadEditDto localidadEditDto)
        {
            localidadDto = localidadEditDto;
        }
    }
}
