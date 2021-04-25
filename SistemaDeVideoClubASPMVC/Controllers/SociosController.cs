using AutoMapper;
using SistemaDeVideoClub.Entidades.ViewModels.SocioListViewModel;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Socio;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class SociosController : Controller
    {
        private readonly IServiciosSocios _servicio;
        private readonly IServicioTipoDeDocumento _serviciosTipo;
        private readonly IServicioLocalidades _serviciosLocalidad;
        private readonly IServiciosProvincia _serviciosProvincia;

        private readonly IMapper _mapper;
        // GET: Socios

        public SociosController(IServiciosSocios servicio, IServicioTipoDeDocumento serviciosTipo, IServicioLocalidades serviciosLocalidad, IServiciosProvincia serviciosProvincia)
        {
            _serviciosTipo = serviciosTipo;
            _serviciosLocalidad = serviciosLocalidad;
            _serviciosProvincia = serviciosProvincia;
            _servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        public ActionResult Index(int pagina = 1)
        {
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<SocioListViewModel>>(listaDto);
            return View(listaVm);
        }

        //// GET: Socios/Crear
        //public ActionResult Create()
        //{
        //    var socioVm = new SocioEditViewModel
        //    {
        //        Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList(),
        //        Localidades = _DbContext.Localidades.OrderBy(l=> l.NombreLocalidad).ToList(),
        //        TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t=>t.Descripcion).ToList()
        //    };
        //    return View(socioVm);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Create(SocioEditViewModel socioVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
        //        socioVm.Localidades = _DbContext.Localidades.OrderBy(p => p.NombreLocalidad).ToList();
        //        socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(p => p.TipoDeDocumentoId).ToList();

        //        return View(socioVm);
        //    }

        //    var socio = Mapper.Map<SocioEditViewModel, Socio>(socioVm);

        //    if (!_DbContext.Socios.Any(l =>/* l.Nombre == socioVm.Nombre && */l.NroDocumento == socioVm.NroDocumento ))
        //    {
        //        _DbContext.Socios.Add(socio);
        //        _DbContext.SaveChanges();
        //        TempData["Msg"] = "Socio guardado";

        //        return RedirectToAction("Index");

        //    }

        //    socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
        //    socioVm.Localidades = _DbContext.Localidades.OrderBy(p => p.NombreLocalidad).ToList();
        //    socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(p => p.Descripcion).ToList();

        //    ModelState.AddModelError(string.Empty, "Socio repetido");
        //    return View(socioVm);
        //}

        //// GET: Socios/Detalles

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Socio socio = _DbContext.Socios
        //     .Include(s => s.Localidad)
        //     .Include(s => s.Provincia)
        //     .Include(s => s.TipoDeDocumento)
        //     .SingleOrDefault(s => s.SocioId == id);
        //    if (socio == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    SocioDetailViewMode socioVm = Mapper.Map<Socio, SocioDetailViewMode>(socio);

        //    return View(socioVm);
        //}

        //// GET: Socios/Editar


        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var socio = _DbContext.Socios.SingleOrDefault(s => s.SocioId == id);
        //    if (socio == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    SocioEditViewModel socioVm = Mapper.Map<Socio, SocioEditViewModel>(socio);
        //    socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
        //    socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();
        //    socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
        //    return View(socioVm);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Edit(SocioEditViewModel socioVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
        //        socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();
        //        socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();

        //        return View(socioVm);
        //    }

        //    var socio = Mapper.Map<SocioEditViewModel, Socio>(socioVm);
        //    try
        //    {
        //        if (_DbContext.Socios.Any(s => s.Nombre == socioVm.Nombre && s.ProvinciaId != socioVm.ProvinciaId))
        //        {
        //            socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
        //            socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
        //            socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();

        //            ModelState.AddModelError(string.Empty, "Socio repetido");
        //            return View(socioVm);
        //        }

        //        _DbContext.Entry(socio).State = EntityState.Modified;
        //        _DbContext.SaveChanges();
        //        TempData["Msg"] = "Socio editado";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
        //        socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
        //        socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();

        //        ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar socio");
        //        return View(socioVm);
        //    }
        //}

        //// GET: Socios/Borrar


        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var socio = _DbContext.Socios.SingleOrDefault(s => s.SocioId == id);
        //    if (socio == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var SocioVm = Mapper.Map<Socio, SocioListViewModel>(socio);
        //    return View(SocioVm);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    var socio = _DbContext.Socios.SingleOrDefault(s => s.SocioId == id);
        //    try
        //    {
        //        _DbContext.Socios.Remove(socio);
        //        _DbContext.SaveChanges();
        //        TempData["Msg"] = "Socio eliminado con exito";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        var SocioVm = Mapper.Map<Socio, SocioListViewModel>(socio);

        //        ModelState.AddModelError(string.Empty, "Error al intentar eliminar socio");
        //        return View(SocioVm);
        //    }
        //}


    }
}