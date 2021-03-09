using AutoMapper;
using SistemaDeVideoClubASPMVC.Classes;
using SistemaDeVideoClubASPMVC.Context;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Socio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class SociosController : Controller
    {
        private readonly VideoClubDbContext _DbContext;
        private readonly int _registrosPorPagina = 10;
        private Listador<SocioListViewModel> _listador;
        // GET: Socios

        public SociosController()
        {
            _DbContext = new VideoClubDbContext();
        }
        public ActionResult Index(int pagina = 1)
        {
            int totalRegistros = _DbContext.Socios.Count();

            var socio = _DbContext.Socios
                .Include(s => s.TipoDeDocumento)
                .Include(s => s.Localidad)
                .Include(s => s.Provincia)
                .OrderBy(s => s.Nombre)
                .Skip((pagina - 1) * _registrosPorPagina)
                .Take(_registrosPorPagina)
                .ToList();

            var socioVm = Mapper.Map<List<Socio>, List<SocioListViewModel>>(socio);
            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / _registrosPorPagina);
            _listador = new Listador<SocioListViewModel>()
            {
                RegistrosPorPagina = _registrosPorPagina,
                TotalPaginas = totalPaginas,
                TotalRegistros = totalRegistros,
                PaginaActual = pagina,
                Registros = socioVm
            };

            return View(_listador);
        }

        // GET: Socios/Crear
        public ActionResult Create()
        {
            var socioVm = new SocioEditViewModel
            {
                Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList(),
                Localidades = _DbContext.Localidades.OrderBy(l=> l.NombreLocalidad).ToList(),
                TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t=>t.Descripcion).ToList()
            };
            return View(socioVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(SocioEditViewModel socioVm)
        {
            if (!ModelState.IsValid)
            {
                socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
                socioVm.Localidades = _DbContext.Localidades.OrderBy(p => p.NombreLocalidad).ToList();
                socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(p => p.TipoDeDocumentoId).ToList();

                return View(socioVm);
            }

            var socio = Mapper.Map<SocioEditViewModel, Socio>(socioVm);

            if (!_DbContext.Socios.Any(l =>/* l.Nombre == socioVm.Nombre && */l.NroDocumento == socioVm.NroDocumento ))
            {
                _DbContext.Socios.Add(socio);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Socio guardado";

                return RedirectToAction("Index");

            }

            socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
            socioVm.Localidades = _DbContext.Localidades.OrderBy(p => p.NombreLocalidad).ToList();
            socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(p => p.Descripcion).ToList();

            ModelState.AddModelError(string.Empty, "Socio repetido");
            return View(socioVm);
        }

        // GET: Socios/Detalles

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = _DbContext.Socios
             .Include(s => s.Localidad)
             .Include(s => s.Provincia)
             .Include(s => s.TipoDeDocumento)
             .SingleOrDefault(s => s.SocioId == id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            SocioDetailViewMode socioVm = Mapper.Map<Socio, SocioDetailViewMode>(socio);

            return View(socioVm);
        }

        // GET: Socios/Editar


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var socio = _DbContext.Socios.SingleOrDefault(s => s.SocioId == id);
            if (socio == null)
            {
                return HttpNotFound();
            }

            SocioEditViewModel socioVm = Mapper.Map<Socio, SocioEditViewModel>(socio);
            socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
            socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();
            socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
            return View(socioVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(SocioEditViewModel socioVm)
        {
            if (!ModelState.IsValid)
            {
                socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
                socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();
                socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();

                return View(socioVm);
            }

            var socio = Mapper.Map<SocioEditViewModel, Socio>(socioVm);
            try
            {
                if (_DbContext.Socios.Any(s => s.Nombre == socioVm.Nombre && s.ProvinciaId != socioVm.ProvinciaId))
                {
                    socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
                    socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
                    socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();

                    ModelState.AddModelError(string.Empty, "Socio repetido");
                    return View(socioVm);
                }

                _DbContext.Entry(socio).State = EntityState.Modified;
                _DbContext.SaveChanges();
                TempData["Msg"] = "Socio editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                socioVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
                socioVm.TipoDeDocumentos = _DbContext.TiposDeDocumento.OrderBy(t => t.Descripcion).ToList();
                socioVm.Localidades = _DbContext.Localidades.OrderBy(l => l.NombreLocalidad).ToList();

                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar socio");
                return View(socioVm);
            }
        }

        // GET: Socios/Borrar


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var socio = _DbContext.Socios.SingleOrDefault(s => s.SocioId == id);
            if (socio == null)
            {
                return HttpNotFound();
            }

            var SocioVm = Mapper.Map<Socio, SocioListViewModel>(socio);
            return View(SocioVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var socio = _DbContext.Socios.SingleOrDefault(s => s.SocioId == id);
            try
            {
                _DbContext.Socios.Remove(socio);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Socio eliminado con exito";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                var SocioVm = Mapper.Map<Socio, SocioListViewModel>(socio);

                ModelState.AddModelError(string.Empty, "Error al intentar eliminar socio");
                return View(SocioVm);
            }
        }


    }
}