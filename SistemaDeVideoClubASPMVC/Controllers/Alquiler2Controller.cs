using AutoMapper;
using SistemaDeVideoClub.Entidades.ViewModels.Alquiler;
using SistemaDeVideoClub.Entidades.ViewModels.Pelicula;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class Alquiler2Controller : Controller
    {
        private readonly IServicioAlquiler _servicio;

        private readonly IMapper _mapper;

        public Alquiler2Controller(IServicioAlquiler servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Alquiler
        public ActionResult Index()
        {
            var alquilerDto = _servicio.GetLista();
            var alquilerVm = _mapper.Map<List<AlquilerListViewModel>>(alquilerDto);
            return View(alquilerVm);
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    AlquilerEditViewModel localidadVm = new AlquilerEditViewModel
        //    {
        //        Peliculas = _mapper.Map<List<PeliculaListViewModel>>(_serviciosProvincia.GetLista())
        //        Socio = _mapper.Map<List<SocioaListViewModel>>(_serviciosProvincia.GetLista())
        //    };
        //    return View(localidadVm);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Create(LocalidadEditViewModel localidadVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

        //        return View(localidadVm);
        //    }

        //    LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);

        //    if (_servicio.Existe(localidadDto))
        //    {
        //        ModelState.AddModelError(string.Empty, "Localidad existente");

        //        localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

        //        return View(localidadVm);
        //    }
        //    try
        //    {
        //        _servicio.Guardar(localidadDto);
        //        TempData["Msg"] = "Localidad guardada";

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {

        //        ModelState.AddModelError(string.Empty, e.Message);

        //        localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

        //        return View(localidadVm);
        //    }
        //}

    }
}