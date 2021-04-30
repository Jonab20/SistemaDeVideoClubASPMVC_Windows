using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Entidades.ViewModels.Carrito;
using SistemaDeVideoClub.Entidades.ViewModels.Socio;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IServicioPelicula _servicioPeliculas;
        private readonly IServiciosSocios _servicioSocio;
        private readonly IServicioAlquiler _servicio;
        private IMapper _mapper;
        public CarritoController(IServicioPelicula servicioPeliculas, IServiciosSocios servicioSocio, IServicioAlquiler servicio)
        {
            _servicioSocio = servicioSocio;
            _servicio = servicio;
            _servicioPeliculas = servicioPeliculas;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Carrito
        public ActionResult Index(Carrito carrito,Socio socio, string returnUrl)
        {
            List<ItemCarritoListViewModel> listaItems = _mapper.Map<List<ItemCarritoListViewModel>>(carrito.GetItems());
            return View(new CarritoListViewModel
            {
                items = listaItems,
                ReturnUrl = returnUrl
            });

        }
        //public ActionResult SeleccionarSocio(Carrito carrito, int SocioId/*,decimal PrecioAlquiler*/, string returnUrl)
        //{
        //    SocioEditDto socioDto = _servicioSocio.GetSocioPorId(SocioId);
        //    if (socioDto != null)
        //    {
        //        Socio socio = _mapper.Map<Socio>(socioDto);

        //    }
        //    return RedirectToAction("Index", new { returnUrl });
        //}

        public ActionResult AgregarAlCarro(Carrito carrito, int peliculaId, string returnUrl)
        {
            PeliculaEditDto peliculaDto = _servicioPeliculas.GetPeliculaPorId(peliculaId);
            if (peliculaDto != null)
            {
                
                Pelicula pelicula = _mapper.Map<Pelicula>(peliculaDto);
                carrito.AgregarAlquiler(pelicula, 100);

            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public ActionResult RemoveFromCart(Carrito carrito, int peliculaId, string returnUrl)
        {
            Pelicula pelicula = _mapper.Map<Pelicula>(_servicioPeliculas.GetPeliculaPorId(peliculaId));
            if (pelicula != null)
            {
                carrito.EliminarDelCarrito(pelicula);
            }

            return RedirectToAction("Index", new { returnUrl });

        }
        public PartialViewResult Summary(Carrito carrito)
        {
            return PartialView(carrito);
        }
        [HttpGet]
        public ActionResult CheckOut(Carrito carrito)
        {
            if (carrito.GetItems().Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No tiene compras efectuadas!!!");
            }

            var carritoVm = _mapper.Map<CarritoListViewModel>(carrito);

            carritoVm.socios = _mapper.Map<List<SocioListViewModel>>(_servicioSocio.GetLista(null));

            return View(carritoVm);
        }

        public ActionResult CancelarPedido(Carrito carrito)
        {
            carrito.VaciarCarrito();
            return RedirectToAction("Index", "Peliculas");
        }

        public ActionResult ConfirmarPedido(Carrito carrito)
        {
            ItemAlquiler ItemAlquiler;
            Socio socio;
            try
            {
                List<ItemAlquilerEditDto> listaItems = new List<ItemAlquilerEditDto>();
                foreach (var item in carrito.listaPeliculaAlquiler)
                {

                    ItemAlquilerEditDto itemDto = new ItemAlquilerEditDto
                    {
                        Pelicula = _mapper.Map<PeliculaListDto>(item.pelicula),
                        PrecioAlquiler = item.PrecioAlquiler
                        
                        //PrecioUnitario = item.Producto.Precio

                    };
                    listaItems.Add(itemDto);
                    //ItemAlquiler = itemDto;
                }

                AlquilerEditDto alquilerEditDto = new AlquilerEditDto
                {
                    FechaAlquiler = DateTime.Now,
                    //SocioId = _mapper.Map<SocioListDto>(alquilerEditDto.SocioId)/*carrito.socio.SocioId,*/
                    //PeliculaId = itemAlquiler
                    //SocioId = 

                    ItemsAlquiler = listaItems

                };
                _servicio.Guardar(alquilerEditDto);
                ViewBag.AlquilerId = alquilerEditDto.AlquilerId;
                carrito.VaciarCarrito();
                return View("AlquilerGuardado");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            return View("ErrorAlProcesarPedido");
        }

        //public ActionResult GeneratePdf(int id)
        //{
        //    return new Rotativa.ActionAsPdf("GeneratePdfPreview", new { ventaId = id });
        //}
    }
}
