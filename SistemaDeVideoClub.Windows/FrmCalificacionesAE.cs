using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
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
    public partial class FrmCalificacionesAE : Form
    {
        private CalificacionEditDto calificacionDto;

        public FrmCalificacionesAE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void FrmCalificacionesAE_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (calificacionDto == null)
                {
                    calificacionDto = new CalificacionEditDto();
                }
                calificacionDto.Descripcion = TxtDescripcion.Text;
                DialogResult = DialogResult.OK;
            }

        }

        internal CalificacionEditDto GetCalificacion()
        {
            return calificacionDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (calificacionDto != null)
            {
                TxtDescripcion.Text = calificacionDto.Descripcion;
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

        internal void SetCalificacion(CalificacionEditDto calificacionEditDto)
        {
            calificacionDto = calificacionEditDto;
        }
    }
}
