using SistemaDeVideoClub.Entidades.DTOs.Estado;
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
    public partial class FrmEstadosAE : Form
    {
        private EstadoEditDto estadoDto;
        public FrmEstadosAE()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (estadoDto != null)
            {
                TxtDescripcion.Text = estadoDto.Descripcion;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (estadoDto == null)
                {
                    estadoDto = new EstadoEditDto();
                }
                estadoDto.Descripcion = TxtDescripcion.Text;
                DialogResult = DialogResult.OK;
            }

        }

        internal EstadoEditDto GetGenero()
        {
            return estadoDto;
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
        internal void SetEstado(EstadoEditDto estadoEditDto)
        {
            estadoDto = estadoEditDto;
        }

    }
}
