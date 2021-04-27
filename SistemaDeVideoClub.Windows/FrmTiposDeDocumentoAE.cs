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
    public partial class FrmTiposDeDocumentoAE : Form
    {
        private TipoDeDocumentoEditDto TipoDoceDto;

        public FrmTiposDeDocumentoAE()
        {
            InitializeComponent();
        }
        internal TipoDeDocumentoEditDto GetTipoDeDocumento()
        {
            return TipoDoceDto;
        }
        internal void SetTipoDeDocumento(TipoDeDocumentoEditDto TipoEditDto)
        {
            TipoDoceDto = TipoEditDto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (TipoDoceDto == null)
                {
                    TipoDoceDto = new TipoDeDocumentoEditDto();
                }
                TipoDoceDto.Descripcion = TxtDescripcion.Text;
                DialogResult = DialogResult.OK;
            }

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (TipoDoceDto != null)
            {
                TxtDescripcion.Text = TipoDoceDto.Descripcion;
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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
