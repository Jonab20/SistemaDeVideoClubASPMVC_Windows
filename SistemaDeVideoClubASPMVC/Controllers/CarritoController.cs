using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Entidades.ViewModels.Carrito;
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
        private IMapper _mapper;
        public CarritoController(IServicioPelicula servicioPeliculas)
        {
            _servicioPeliculas = servicioPeliculas;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Carrito
        public ViewResult Index(Carrito carrito, string returnUrl)
        {
            List<ItemCarritoListViewModel> listaItems = _mapper.Map<List<ItemCarritoListViewModel>>(carrito.GetItems());
            return View(new CarritoListViewModel
            {
                items = listaItems,
                ReturnUrl = returnUrl
            });

        }

        public ActionResult AgregarAlCarro(Carrito carrito, int peliculaId, string returnUrl)
        {
            PeliculaEditDto peliculaDto = _servicioPeliculas.GetPeliculaPorId(peliculaId);
            if (peliculaDto != null)
            {
                Pelicula pelicula = _mapper.Map<Pelicula>(peliculaDto);
                carrito.AgregarAlquiler(pelicula, 1);
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

        public ActionResult CheckOut(Carrito carrito)
        {
            if (carrito.GetItems().Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No tiene compras efectuadas!!!");
            }

            var carritoVm = _mapper.Map<CarritoListViewModel>(carrito);

            return View(carritoVm);
        }

        public ActionResult CancelarPedido(Carrito carrito)
        {
            carrito.VaciarCarrito();
            return RedirectToAction("Index", "Productos");
        }

        //    public ActionResult ConfirmarPedido(Carrito carrito)
        //    {
        //        try
        //        {
        //            List<ItemVentaEditDto> listaItems = new List<ItemVentaEditDto>();
        //            foreach (var item in carrito.listaItems)
        //            {
        //                ItemVentaEditDto itemDto = new ItemVentaEditDto
        //                {
        //                    Producto = _mapper.Map<ProductoListDto>(item.Producto),
        //                    Cantidad = item.Cantidad,
        //                    PrecioUnitario = item.Producto.Precio

        //                };
        //                listaItems.Add(itemDto);
        //            }
        //            VentaEditDto ventaEditDto = new VentaEditDto
        //            {
        //                FechaVenta = DateTime.Now,
        //                ModalidadVenta = ModalidadVenta.TakeAway,
        //                EstadoVenta = EstadoVenta.Finalizada,
        //                ItemsVentas = listaItems

        //            };
        //            _servicio.Guardar(ventaEditDto);
        //            ViewBag.VentaId = ventaEditDto.VentaId;
        //            carrito.VaciarCarrito();
        //            return View("VentaGuardada");

        //        }
        //        catch (Exception e)
        //        {
        //            ModelState.AddModelError(string.Empty, e.Message);
        //        }

        //        return View("ErrorAlProcesarPedido");
        //    }
        //    public ActionResult GeneratePdf(int id)
        //    {
        //        return new Rotativa.ActionAsPdf("GeneratePdfPreview", new { ventaId = id });
        //    }

        //    public ActionResult GeneratePdfPreview(int ventaId)
        //    {
        //        var ventaDto = _servicio.GetVentaPorId(ventaId);
        //        var ventaVm = _mapper.Map<VentaDetailsViewModel>(ventaDto);
        //        return View(ventaVm);
        //    }

        //}

    }
}
