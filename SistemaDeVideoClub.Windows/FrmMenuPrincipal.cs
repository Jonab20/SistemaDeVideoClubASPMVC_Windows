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

        private void btnPeliculas_Click(object sender, EventArgs e)
        {
            FrmPeliculas frm = DI.Create<FrmPeliculas>();
            frm.ShowDialog(this);
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            FrmSocios frm = DI.Create<FrmSocios>();
            frm.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSoportes frm = DI.Create<FrmSoportes>();
            frm.ShowDialog(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmCalificaciones frm = DI.Create<FrmCalificaciones>();
            frm.ShowDialog(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmEstados frm = DI.Create<FrmEstados>();
            frm.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTiposDeDocumento frm = DI.Create<FrmTiposDeDocumento>();
            frm.ShowDialog(this);
        }
    }
}
