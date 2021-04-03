using SistemaDeVideoClub.Entidades.DTOs.Provincia;
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
    public partial class FrmBuscarLocalidad : Form
    {
        public FrmBuscarLocalidad()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmBuscarLocalidad_Load(object sender, EventArgs e)
        {
            Helper.Helper.CargarComboProvincia(ref cboProvincias);
        }

        private ProvinciaListDto provinciaDto;
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (validardatos())
            {
                provinciaDto = cboProvincias.SelectedItem as ProvinciaListDto;
                DialogResult = DialogResult.OK;
            }
        }

        private bool validardatos()
        { 

            bool valido = true;
            errorProvider1.Clear();
            if (cboProvincias.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboProvincias, "Seleccione por cual provincia desea buscar");
            }
            return valido;
        }

        internal ProvinciaListDto GetProvincia()
        {
            return provinciaDto;
        }
    }
}
