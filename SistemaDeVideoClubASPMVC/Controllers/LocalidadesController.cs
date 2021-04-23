using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Localidad;
using SistemaDeVideoClubASPMVC.ViewModels.Provincia;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly IServicioLocalidades _servicio;
        private readonly IServiciosProvincia _serviciosProvincia;
        private readonly IMapper _mapper;
        //private readonly int _registrosPorPagina = 10;
        //private Listador<LocalidadListViewModel> _listador;

        // GET: Localidades
        public LocalidadesController(IServicioLocalidades servicio, IServiciosProvincia serviciosProvincia)
        {
            _serviciosProvincia = serviciosProvincia;
            _servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        public ActionResult Index(int pagina = 1)
        {
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<LocalidadListViewModel>>(listaDto);
            return View(listaVm);
        }

        //GET: Localidades/Create
        [HttpGet]
        public ActionResult Create()
        {
            LocalidadEditViewModel localidadVm = new LocalidadEditViewModel
            {
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista())
            };
            return View(localidadVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

                return View(localidadVm);
            }

            LocalidadEditDto  localidadDto = Mapper.Map<LocalidadEditDto>(localidadVm);

            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, "Localidad existente");

                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

                return View(localidadVm);
            }
            try
            {
                _servicio.Guardar(localidadDto);
                TempData["Msg"] = "Localidad guardada";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);

                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

                return View(localidadVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadListDto localidadDto =_mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(id));
            if (localidadDto == null)
            {
                return HttpNotFound("Codigo inexistente");
            }

            LocalidadListViewModel LocalidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);
            return View(LocalidadVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(LocalidadListViewModel localidadvm)
        {
            try
            {
                LocalidadListDto localidadDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(localidadvm.LocalidadId));

                localidadvm = _mapper.Map<LocalidadListViewModel>(localidadDto);
                _servicio.Borrar(localidadvm.LocalidadId);
                TempData["Msg"] = "Localidad eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar eliminar la localidad");
                return View(localidadvm);
            }
        }

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Localidad localidad = _DbContext.Localidades
        //        .Include(p => p.Provincia)
        //        .SingleOrDefault(p => p.LocalidadId == id); 
        //    if (localidad == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    LocalidadDetailViewModel localidadVm = Mapper.Map<Localidad, LocalidadDetailViewModel>(localidad);
        //    return View(localidadVm);
        //}

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadEditDto localidadEditDto = _servicio.GetLocalidadPorId(id);
            if (localidadEditDto== null)
            {
                return HttpNotFound("Codigo de loacalidad no encontrado");
            }
            LocalidadEditViewModel localidadVm = _mapper.Map<LocalidadEditViewModel>(localidadEditDto);
            localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

            return View(localidadVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>> (_serviciosProvincia.GetLista()); 
                return View(localidadVm);
            }

            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, "Localidad existente");
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(localidadVm);

            }
            try
            {
                _servicio.Guardar(localidadDto);  
                TempData["Msg"] = "Localidad editada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                localidadVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar la localidad");
                return View(localidadVm);
            }
        }
    }
}