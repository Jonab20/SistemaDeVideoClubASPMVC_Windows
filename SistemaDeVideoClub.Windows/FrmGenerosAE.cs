using SistemaDeVideoClub.Entidades.DTOs.Genero;
using System;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmGenerosAE : Form
    {
        public FrmGenerosAE()
        {
            InitializeComponent();
        }

        private GeneroEditDto generoDto;
        private void button1_Click(object sender,  EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (generoDto!=null)
            {
                TxtDescripcion.Text = generoDto.Descripcion;
            }
        }

        internal GeneroEditDto GetGenero()
        {
            return generoDto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (generoDto ==null)
                {
                    generoDto = new GeneroEditDto();
                }
                generoDto.Descripcion = TxtDescripcion.Text;
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
                errorProvider1.SetError(TxtDescripcion,"El Campo descripcion es necesario");
            }
            return valido;
        }

        internal void SetGenero(GeneroEditDto generoEditDto)
        {
            generoDto = generoEditDto;
        }

        private void FrmGenerosAE_Load(object sender, EventArgs e)
        {

        }
    }
}
