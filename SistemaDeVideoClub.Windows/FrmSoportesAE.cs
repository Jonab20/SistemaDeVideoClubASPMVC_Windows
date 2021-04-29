using SistemaDeVideoClub.Entidades.DTOs.Soporte;
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
    public partial class FrmSoportesAE : Form
    {
        private SoporteEditDto soporteDto;

        public FrmSoportesAE()
        {
            InitializeComponent();
        }

        internal SoporteEditDto GetSoporte()
        {
            return soporteDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (soporteDto != null)
            {
                TxtDescripcion.Text = soporteDto.Descripcion;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                valido = true;
                errorProvider1.SetError(TxtDescripcion, "El Campo descripcion es necesario");
            }
            return valido;
        }

        internal void SetSoporte(SoporteEditDto SoporteEditDto)
        {
            soporteDto = SoporteEditDto; ;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (soporteDto == null)
                {
                    soporteDto = new SoporteEditDto();
                }
                soporteDto.Descripcion = TxtDescripcion.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
