using AutoMapper;
using SistemaDeVideoClubASPMVC.Context;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
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
    public class ProvinciasController : Controller
    {
        private readonly VideoClubDbContext _DbContext;
        private readonly int _registrosPorPagina = 10;
        private Listador<ProvinciaListViewModel> _listador;
        // GET: Provincias

        public ProvinciasController()
        {
            _DbContext = new VideoClubDbContext();
        }
        public ActionResult Index(int pagina=1)
        {
            int totalRegistros = _DbContext.Provincias.Count();

            var provincia = _DbContext.Provincias
                .OrderBy(p => p.NombreProvincia)
                .Skip((pagina - 1) * _registrosPorPagina)
                .Take(_registrosPorPagina)
                .ToList();
            var ProviciaVm = Mapper.Map<List<Provincia>, List<ProvinciaListViewModel>>(provincia);
            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / _registrosPorPagina);
            _listador = new Listador<ProvinciaListViewModel>()
            {
                RegistrosPorPagina = _registrosPorPagina,
                TotalPaginas = totalPaginas,
                TotalRegistros = totalRegistros,
                PaginaActual = pagina,
                Registros = ProviciaVm
            };

            return View(_listador);
        }









        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var provincia = _DbContext.Provincias.SingleOrDefault(p => p.ProvinciaId == id);
            if (provincia == null)
            {
                return HttpNotFound();
            }

            ProvinciaEditViewModel provinciaVm = Mapper.Map<Provincia, ProvinciaEditViewModel>(provincia);
            return View(provinciaVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(ProvinciaEditViewModel provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }

            var provincia = Mapper.Map<ProvinciaEditViewModel, Provincia>(provinciaVm);
            try
            {
                if (_DbContext.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia
                                               && p.ProvinciaId != provincia.ProvinciaId))
                {
                    ModelState.AddModelError(string.Empty, "Provincia repetida");
                    return View(provinciaVm);
                }

                _DbContext.Entry(provincia).State = EntityState.Modified;
                _DbContext.SaveChanges();
                TempData["Msg"] = "Provincia editada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar la Provincia");
                return View(provinciaVm);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(ProvinciaEditViewModel provinciaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }

            var provincia = Mapper.Map<ProvinciaEditViewModel, Provincia>(provinciaVm);

            if (!_DbContext.Provincias.Any(p => p.NombreProvincia == provinciaVm.NombreProvincia))
            {
                _DbContext.Provincias.Add(provincia);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Provincia agregada!";

                return RedirectToAction("Index");

            }

            ModelState.AddModelError(string.Empty, "Provincia repetida...");
            return View(provinciaVm);

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var provincia = _DbContext.Provincias.SingleOrDefault(p => p.ProvinciaId == id);
            if (provincia == null)
            {
                return HttpNotFound();
            }

            var provinciaVm = Mapper.Map<Provincia, ProvinciaListViewModel>(provincia);
            return View(provinciaVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var provincia = _DbContext.Provincias.SingleOrDefault(t => t.ProvinciaId == id);
            try
            {
                _DbContext.Provincias.Remove(provincia);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Provincia eliminada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                var paisVm = Mapper.Map<Provincia, ProvinciaListViewModel>(provincia);

                ModelState.AddModelError(string.Empty, "Error al intentar borrar la provincia");
                return View(paisVm);
            }
        }


        // GET: Paises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = _DbContext.Provincias.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }
    }



}
