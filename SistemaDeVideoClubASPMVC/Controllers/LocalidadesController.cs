using AutoMapper;
using SistemaDeVideoClubASPMVC.Context;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Localidad;
using SistemaDeVideoClubASPMVC.ViewModels.Provincia;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly VideoClubDbContext _DbContext;
        private readonly int _registrosPorPagina = 10;
        private Listador<LocalidadListViewModel> _listador;

        // GET: Localidades
        public LocalidadesController()
        {
            _DbContext = new VideoClubDbContext();
        }
        public ActionResult Index(int pagina = 1)
        {
            int totalRegistros = _DbContext.Localidades.Count();

            var localidades = _DbContext.Localidades
                .Include(l => l.Provincia)
                .OrderBy(l => l.NombreLocalidad)                
                .ThenBy(l => l.NombreLocalidad)
                .Skip((pagina - 1) * _registrosPorPagina)
                .Take(_registrosPorPagina)
                .ToList();

            var LocalidadVm = Mapper.Map<List<Localidad>, List<LocalidadListViewModel>>(localidades);

            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / _registrosPorPagina);
            _listador = new Listador<LocalidadListViewModel>()
            {
                RegistrosPorPagina = _registrosPorPagina,
                TotalPaginas = totalPaginas,
                TotalRegistros = totalRegistros,
                PaginaActual = pagina,
                Registros = LocalidadVm
            };
            return View(_listador);

        }

        // GET: Localidades/Create
        public ActionResult Create()
        {
            var localidadVm = new LocalidadEditViewModel
            {
                Provincias = _DbContext.Provincias
                    .OrderBy(p => p.NombreProvincia).ToList()
            };
            return View(localidadVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();

                return View(localidadVm);
            }

            var localidad = Mapper.Map<LocalidadEditViewModel, Localidad>(localidadVm);

            if (!_DbContext.Localidades.Any(l => l.NombreLocalidad == localidadVm.NombreLocalidad
                            /*&& l.ProvinciaId != localidadVm.ProvinciaId*/))
            {
                _DbContext.Localidades.Add(localidad);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Localidad guardada";

                return RedirectToAction("Index");

            }

            localidadVm.Provincias = _DbContext.Provincias
                    .OrderBy(p => p.NombreProvincia).ToList();

            ModelState.AddModelError(string.Empty, "Localidad repetida");
            return View(localidadVm);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var localidad = _DbContext.Localidades.SingleOrDefault(t => t.LocalidadId == id);
            if (localidad == null)
            {
                return HttpNotFound();
            }

            var LocalidadVm = Mapper.Map<Localidad, LocalidadListViewModel>(localidad);
            return View(LocalidadVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var localidad = _DbContext.Localidades.SingleOrDefault(t => t.LocalidadId == id);
            try
            {
                _DbContext.Localidades.Remove(localidad);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Localidad eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                var localidadVm = Mapper.Map<Localidad, LocalidadListViewModel>(localidad);

                ModelState.AddModelError(string.Empty, "Error al intentar eliminar la localidad");
                return View(localidadVm);
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Localidad localidad = _DbContext.Localidades
                .Include(p => p.Provincia)
                .SingleOrDefault(p => p.LocalidadId == id); 
            if (localidad == null)
            {
                return HttpNotFound();
            }
            LocalidadDetailViewModel localidadVm = Mapper.Map<Localidad, LocalidadDetailViewModel>(localidad);
            return View(localidadVm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var localidad = _DbContext.Localidades.SingleOrDefault(l => l.LocalidadId == id);
            if (localidad == null)
            {
                return HttpNotFound();
            }

            LocalidadEditViewModel localidadVm = Mapper.Map<Localidad, LocalidadEditViewModel>(localidad);
            localidadVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();
            return View(localidadVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincias = _DbContext.Provincias.OrderBy(p => p.NombreProvincia).ToList();

                return View(localidadVm);
            }

            var localidad = Mapper.Map<LocalidadEditViewModel, Localidad>(localidadVm);
            try
            {
                if (_DbContext.Localidades.Any(l => l.NombreLocalidad == localidadVm.NombreLocalidad
                                                  && l.ProvinciaId != localidadVm.ProvinciaId))
                {
                    localidadVm.Provincias = _DbContext.Provincias
                        .OrderBy(p => p.NombreProvincia).ToList();

                    ModelState.AddModelError(string.Empty, "Localidad repetida");
                    return View(localidadVm);
                }

                _DbContext.Entry(localidad).State = EntityState.Modified;
                _DbContext.SaveChanges();
                TempData["Msg"] = "Localidad editada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                localidadVm.Provincias = _DbContext.Provincias
                    .OrderBy(p => p.NombreProvincia).ToList();

                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar la localidad");
                return View(localidadVm);
            }
        }
    }
}