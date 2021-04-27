using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.ViewModels.Calificacion;
using SistemaDeVideoClub.Entidades.ViewModels.Estado;
using SistemaDeVideoClub.Entidades.ViewModels.Pelicula;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.Classes;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class PeliculasController : Controller
    {

        private readonly IServicioPelicula _servicio;
        private readonly IServiciosGenero _serviciosGenero;
        private readonly IServicioEstados _serviciosEstado;
        private readonly IServicioCalificaciones _servicioCalificaciones;
        private readonly IMapper _mapper;
        private readonly string folder = "~/Content/Imagenes/Peliculas/";
        public PeliculasController(IServicioPelicula servicio, IServiciosGenero serviciosGenero, IServicioEstados serviciosEstado, IServicioCalificaciones servicioCalificaciones)
        {
            _servicio = servicio;
            _serviciosGenero = serviciosGenero;
            _serviciosEstado = serviciosEstado;
            _servicioCalificaciones = servicioCalificaciones;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Peliculas

        public ActionResult Index(int pagina = 1)
        {
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<PeliculaListViewModel>>(listaDto);
            return View(listaVm);

        }

        // GET: Peliculas/Create
        [HttpGet]
        public ActionResult Create()
        {
            PeliculaEditViewModel peliculaVm = new PeliculaEditViewModel
            {
                Imagen = $"{folder}SinImagen.jpg",
                Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista()),
                Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista()),
                Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista())
            };
            return View(peliculaVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(PeliculaEditViewModel peliculaVm)
        {
            if (!ModelState.IsValid)
            {
                peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
                peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
                peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());

                return View(peliculaVm);
            }

            PeliculaEditDto peliculaDto = _mapper.Map<PeliculaEditDto>(peliculaVm);

            if (_servicio.Existe(peliculaDto))
            {
                ModelState.AddModelError(string.Empty, "Pelicula existente");

                peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
                peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
                peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());
                return View(peliculaVm);
            }
            try
            {
                _servicio.Guardar(peliculaDto);
                TempData["Msg"] = "Pelicula guardada";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);

                peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
                peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
                peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());

                return View(peliculaVm);
            }

        }

        // GET: Pelicula/Details/
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PeliculaListDto peliculaEditDto = _mapper.Map<PeliculaListDto>(_servicio.GetPeliculaPorId(id));
            if (peliculaEditDto == null)
            {
                return HttpNotFound("Codigo de Pelicula no encontrado");
            }
            PeliculaListViewModel PeliculaVm = _mapper.Map<PeliculaListViewModel>(peliculaEditDto);

            PeliculaVm.Genero = peliculaEditDto.Genero;
            PeliculaVm.Estado = peliculaEditDto.Estado;
            PeliculaVm.Calificacion = peliculaEditDto.Calificacion;

            return View(PeliculaVm);

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PeliculaListDto peliculaDto = _mapper.Map<PeliculaListDto>(_servicio.GetPeliculaPorId(id));
            if (peliculaDto == null)
            {
                return HttpNotFound("Codigo de pelicula inexistente");
            }

            PeliculaListViewModel peliculaVm = _mapper.Map<PeliculaListViewModel>(peliculaDto);
            return View(peliculaVm);

        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(PeliculaListViewModel peliculavm)
        {
            try
            {
                PeliculaListDto peliculaDto = _mapper.Map<PeliculaListDto>(_servicio.GetPeliculaPorId(peliculavm.PeliculaId));

                peliculavm = _mapper.Map<PeliculaListViewModel>(peliculaDto);
                _servicio.Borrar(peliculavm.PeliculaId);
                TempData["Msg"] = "Pelicula eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar eliminar la pelicula");
                return View(peliculavm);
            }

        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PeliculaEditDto peliculaEditDto = _servicio.GetPeliculaPorId(id);
            if (peliculaEditDto == null)
            {
                return HttpNotFound("Codigo de Pelicula no encontrado");
            }
            PeliculaEditViewModel peliculaVm = _mapper.Map<PeliculaEditViewModel>(peliculaEditDto);

            peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
            peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
            peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());


            return View(peliculaVm);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(PeliculaEditViewModel peliculaVm)
        {
            if (!ModelState.IsValid)
            {
                peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
                peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
                peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());

                return View(peliculaVm);
            }

            PeliculaEditDto peliculaDto = _mapper.Map<PeliculaEditDto>(peliculaVm);
            if (_servicio.Existe(peliculaDto))
            {
                ModelState.AddModelError(string.Empty, "Pelicula existente");
                peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
                peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
                peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());

                return View(peliculaVm);
            }
            try
            {
                _servicio.Guardar(peliculaDto);
                TempData["Msg"] = "Pelicula editada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                peliculaVm.Generos = _mapper.Map<List<GeneroListViewModel>>(_serviciosGenero.GetLista());
                peliculaVm.Estados = _mapper.Map<List<EstadoListViewModel>>(_serviciosEstado.GetLista());
                peliculaVm.Calificaciones = _mapper.Map<List<CalificacionListViewModel>>(_servicioCalificaciones.GetLista());
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar la pelicula");
                return View(peliculaVm);
            }

        }

    }
}