using SistemaDeVideoClub.Windows.Ninject;
using System;
using System.Windows.Forms;

namespace SistemaDeVideoClub.Windows
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btngeneros_Click(object sender, EventArgs e)
        {
            FrmGeneros frm = DI.Create<FrmGeneros>();
            frm.ShowDialog(this);
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void btnProvincias_Click_1(object sender, EventArgs e)
        {
            FrmProvincias frm = DI.Create<FrmProvincias>();
            frm.ShowDialog(this);
        }

        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            FrmLocalidades frm = DI.Create<FrmLocalidades>();
            frm.ShowDialog(this);
        }
    }
}
