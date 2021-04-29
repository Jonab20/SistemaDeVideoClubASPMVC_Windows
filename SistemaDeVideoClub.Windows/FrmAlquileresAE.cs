using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Windows.Ninject;
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
    public partial class FrmAlquileresAE : Form
    {

        private AlquilerEditDto alquilerEdit;

        private Pelicula peliculaE;
        private Carrito carrito = new Carrito();
        private IMapper _mapper;
        public PeliculaListDto peliculaDto { get; set; }
        public SocioListDto socioDto { get; set; }
        private ItemAlquiler ItemAlquiler;

        public FrmAlquileresAE()
        {
            InitializeComponent();
        }
        private void FrmAlquileresAE_Load(object sender, EventArgs e)
        {
            _mapper = SistemaDeVideoClubMVC.Mapeador.Mapeador.CrearMapper();

        }

        internal AlquilerEditDto GetAlquiler()
        {
            return alquilerEdit;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarSocio frm = DI.Create<FrmBuscarSocio>();

            frm.Text = "Buscando cliente...";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                SocioListDto sociolistDto = frm.GetSocio();

                if (sociolistDto != null)
                {
                    txtSocio.Text = sociolistDto.Nombre;
                    txtTipoDoc.Text = sociolistDto.TipoDeDocumento;
                    txtDoc.Text = sociolistDto.NroDocumento;
                    txtLocalidad.Text = sociolistDto.Localidad;
                    txtProvincia.Text = sociolistDto.Provincia;
                }
                socioDto = sociolistDto;
            }

        }

        private void btnBuscarPelicula_Click(object sender, EventArgs e)
        {
            FrmBuscarPelicula frm = DI.Create<FrmBuscarPelicula>();

            frm.Text = "Buscando Pelicula...";
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                PeliculaListDto peliculalistDto = frm.GetPelicula();

                if (peliculalistDto != null)
                {
                    txtTitulo.Text = peliculalistDto.Titulo;
                    txtCodigo.Text = peliculalistDto.CodigoPelicula;
                    txtEstado.Text = peliculalistDto.Estado;
                    chkbxActivo.Checked = peliculalistDto.Activa;
                }
                peliculaDto = peliculalistDto;
            }

        }

        private void btnAceptarProducto_Click(object sender, EventArgs e)
        {
            if (ValidarDatosPedido())
            {
                //Crear el item a la venta

                Pelicula pelicula = new Pelicula
                {
                    PeliculaId = peliculaDto.PeliculaId,
                    CodigoPelicula = peliculaDto.CodigoPelicula,
                    Titulo = peliculaDto.Titulo,
                    //Genero = peliculaE.Genero,
                    //FechaIncorporacion = peliculaDto.FechaIncorporacion,
                    //Estado = peliculaE.Estado,
                    //DuracionEnMinutos = peliculaDto.DuracionEnMinutos,
                    //Calificacion = peliculaE.Calificacion,
                    //Alquilado = peliculaDto.Alquilado,
                    Activa = peliculaDto.Activa,
                    Alquilado = peliculaDto.Alquilado
                    //Observaciones = peliculaDto.Observaciones
                    //Imagen = peliculaDto.Imagen
                };
                Socio socio = new Socio
                {
                    SocioId = socioDto.SocioId,
                    Nombre = socioDto.Nombre,
                    Apellido = socioDto.Apellido,
                    NroDocumento = socioDto.NroDocumento,
                    Direccion = socioDto.Direccion,
                    TelefonoFijo = socioDto.TelefonoFijo,
                    TelefonoMovil = socioDto.TelefonoMovil,
                    CorreoElectronico = socioDto.CorreoElectronico,
                    //Localidad = socioDto.Localidad,
                    //Provincia = socioDto.Provincia,
                    //TipoDeDocumento = socioDto.TipoDeDocumento,
                    FechaDeNacimiento = socioDto.FechaDeNacimiento,
                    Activo = socioDto.Activo,
                    Sancionado = socioDto.Sancionado

                };
                var itemCarrito = new ItemCarrito
                {
                    pelicula = pelicula,
                    PrecioAlquiler = nudPrecioAlquiler.Value
                    //Cantidad = (int)CantidadNumericUpDown.Value
                };
                carrito.AgregarAlquiler(pelicula/*,socio*/, nudPrecioAlquiler.Value);//TODO: VER
                MostrarDatosEnGrilla();
                //CalcularTotal();
                InicializarControles();
            }
        }

        private void InicializarControles()
        {
            txtCodigo.Clear();
            txtEstado.Clear();
            txtTitulo.Clear();
        }

        private void MostrarDatosEnGrilla()
        {
            dgPedido.Rows.Clear();
            foreach (var itemCarrito in carrito.listaPeliculaAlquiler)
            {
                var r = ConstruirFila();
                SetearFila(r, itemCarrito);
                AgregarFila(r);

            }
        }
        private void AgregarFila(DataGridViewRow r)
        {
            dgPedido.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, ItemCarrito itemCarrito)
        {
            r.Cells[cmnPelicula.Index].Value = itemCarrito.pelicula.Titulo;
            r.Cells[cmnCodigo.Index].Value = itemCarrito.pelicula.CodigoPelicula;
            r.Cells[cmnEstado.Index].Value = itemCarrito.pelicula.Estado;
            r.Cells[cmnTotal.Index].Value = itemCarrito.PrecioAlquiler;

            r.Tag = itemCarrito;
        }

        private DataGridViewRow ConstruirFila()
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgPedido);
            return r;
        }


        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (dgPedido.Rows.Count == 0)
            {
                valido = false;
                errorProvider1.SetError(txtTitulo, "Debe seleccionar una pelicula");

            }
            return valido;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {

                List<ItemAlquilerEditDto> listaItems = new List<ItemAlquilerEditDto>();
                foreach (var item in carrito.listaPeliculaAlquiler)
                {
                    ItemAlquilerEditDto itemDto = new ItemAlquilerEditDto
                    {
                        Pelicula = _mapper.Map<PeliculaListDto>(item.pelicula),
                        PrecioAlquiler = item.PrecioAlquiler
                        //Cantidad = item.Cantidad,
                        //PrecioUnitario = item.Producto.Precio

                    };
                    listaItems.Add(itemDto);
                }
                alquilerEdit = new AlquilerEditDto
                {
                    //PeliculaId = peliculaDto.PeliculaId,
                    SocioId = socioDto.SocioId,
                    FechaAlquiler = DateTime.Now,
                    ItemsAlquiler = listaItems,
                    
                };

                carrito.VaciarCarrito();
                DialogResult = DialogResult.OK;



            }

        }

        private bool ValidarDatosPedido()
        {
            bool valido = true;
            errorProvider1.Clear();
            //if (peliculaDto.Alquilado == true || peliculaDto.Activa == true)
            //{
            //    valido = false;
            //    errorProvider1.SetError(chkbxActivo, "Pelicula no habilitada");

            //}
            if (string.IsNullOrEmpty(txtSocio.Text))
            {
                valido = false;
                errorProvider1.SetError(txtSocio, "Debe seleccionar Socio");
            }
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTitulo, "Debe seleccionar una pelicula");
            }
            return valido;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtPrecioTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            InicializarControles();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
           decimal precioAlquiler = nudPrecioAlquiler.Value;
           var cantidad = carrito.TotalCarrito();
           var TotalPedido = cantidad* precioAlquiler;
           txtPrecioTotal.Text = TotalPedido.ToString();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (chkbxModificar.CheckState == CheckState.Checked)
            {
                nudPrecioAlquiler.Enabled = true;
            }
            else 
            {
                nudPrecioAlquiler.Enabled = false;
            }
        }
    }
}
