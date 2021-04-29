using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
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
    public partial class FrmBuscarSocio : Form
    {
        private IServiciosSocios _Servicio;
        private IMapper _mapper;
        public FrmBuscarSocio(IServiciosSocios servicio)
        {
            _Servicio = servicio;
            InitializeComponent();
        }

        private SocioListDto socio;
        public SocioListDto GetSocio()
        {
            return socio;
        }

        private List<SocioListDto> lista;

        private void FrmBuscarSocio_Load(object sender, EventArgs e)
        {
            lista = _Servicio.GetLista(null);
            MostrarDatosEnGrilla();
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var cliente in lista)
            {
                DataGridViewRow r = ConstruirFila(cliente);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private DataGridViewRow ConstruirFila(SocioListDto socio)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            SetearFila(r, socio);

            return r;
        }

        private void SetearFila(DataGridViewRow r, SocioListDto socio)
        {
            r.Cells[cmnApellido.Index].Value = socio.Apellido;
            r.Cells[cmnNombres.Index].Value = socio.Nombre;
            r.Cells[cmnProvincia.Index].Value = socio.Provincia;
            r.Cells[cmnLocalidad.Index].Value = socio.Localidad;
            r.Cells[cmnDni.Index].Value = socio.NroDocumento;
            r.Tag = socio;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            //if (txtCliente.Text.Length > 0)
            //{
            //    lista = ServicioCliente.GetInstancia().GetLista(txtCliente.Text);

            //}
            //else
            //{
            //    lista = ServicioCliente.GetInstancia().GetLista();
            //}
            //MostrarDatosEnGrilla();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatos.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dgvDatos.SelectedRows[0];
                socio = (SocioListDto)r.Tag;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
