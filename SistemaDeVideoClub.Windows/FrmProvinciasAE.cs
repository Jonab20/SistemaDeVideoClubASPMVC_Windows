using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using System;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmProvinciasAE : Form
    {
        public FrmProvinciasAE()
        {
            InitializeComponent();
        }
        private ProvinciaEditDto provinciaDto;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (provinciaDto != null)
            {
                TxtDescripcion.Text = provinciaDto.NombreProvincia;
            }
        }
        internal ProvinciaEditDto GetProvincia()
        {
            return provinciaDto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (provinciaDto == null)
                {
                    provinciaDto = new ProvinciaEditDto();
                }
                provinciaDto.NombreProvincia = TxtDescripcion.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                valido = true;
                errorProvider1.SetError(TxtDescripcion, "El Campo Nombre de provincia es necesario");
            }
            return valido;
        }

        internal void SetProvincia(ProvinciaEditDto provinciaEditDto)
        {
            provinciaDto = provinciaEditDto;
        }
            
        private void FrmProvinciasAE_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
