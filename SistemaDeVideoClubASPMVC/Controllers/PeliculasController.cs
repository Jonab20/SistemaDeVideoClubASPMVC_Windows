using AutoMapper;
using SistemaDeVideoClubASPMVC.Classes;
using SistemaDeVideoClubASPMVC.Context;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Pelicula;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly VideoClubDbContext _DbContext;
        private readonly int _registrosPorPagina = 10;
        private Listador<PeliculaListViewModel> _listador;

        // GET: Peliculas
        public PeliculasController()
        {
            _DbContext = new VideoClubDbContext();
        }
        public ActionResult Index(int pagina = 1)
        {
            int totalRegistros = _DbContext.Peliculas.Count();

            var peliculas = _DbContext.Peliculas
                .Include(g => g.Genero)
                .Include(g => g.Estado)
                .Include(p => p.Calificacion)
                .OrderBy(p => p.Titulo)                      
                .Skip((pagina - 1) * _registrosPorPagina)
                .Take(_registrosPorPagina)
                .ToList();

            var peliculasVm = Mapper.Map<List<Pelicula>, List<PeliculaListViewModel>>(peliculas);

            var totalPaginas = (int)Math.Ceiling((double)totalRegistros / _registrosPorPagina);
            _listador = new Listador<PeliculaListViewModel>()
            {
                RegistrosPorPagina = _registrosPorPagina,
                TotalPaginas = totalPaginas,
                TotalRegistros = totalRegistros,
                PaginaActual = pagina,
                Registros = peliculasVm
            };

            return View(_listador);
        }

        // GET: Peliculas/Create
        public ActionResult Create()
        {
            var peliculaVm = new PeliculaEditViewModel
            {
                Calificaciones = CombosHelper.GetCalificaciones(),
                Estados = CombosHelper.GetEstados(),
                Generos = CombosHelper.GetGeneros(),
            };
            return View(peliculaVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(PeliculaEditViewModel peliculaVm)
        {
            if (!ModelState.IsValid)
            {
                peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
                peliculaVm.Estados = CombosHelper.GetEstados();
                peliculaVm.Generos = CombosHelper.GetGeneros();
                
                return View(peliculaVm);
            }

            var pelicula = Mapper.Map<PeliculaEditViewModel, Pelicula>(peliculaVm);

            if (!_DbContext.Peliculas.Any(p => p.Titulo == pelicula.Titulo /*&& p.CalificacionId == pelicula.CalificacionId*/))
            {
                    try
                    {
                        _DbContext.Peliculas.Add(pelicula);
                        _DbContext.SaveChanges();
                        TempData["Msg"] = "Pelicula Agregada con exito";
                        return RedirectToAction("Index");
                    }
                    catch (Exception e)
                    {
                        peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
                        peliculaVm.Estados = CombosHelper.GetEstados();
                        peliculaVm.Generos = CombosHelper.GetGeneros();
                        ModelState.AddModelError(string.Empty, e.Message);

                        return View(peliculaVm);
                    }
            }
            peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
            peliculaVm.Estados = CombosHelper.GetEstados();
            peliculaVm.Generos = CombosHelper.GetGeneros();

            ModelState.AddModelError(string.Empty, "Pelicula Repetida");
            return View(peliculaVm);
        }

        // GET: Pelicula/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pelicula pelicula = _DbContext.Peliculas.Find(id);

            Pelicula pelicula = _DbContext.Peliculas
                .Include(p => p.Calificacion)
                .Include(p => p.Genero)
                .Include(p => p.Estado)
                .SingleOrDefault(p => p.PeliculaId == id);

            if (pelicula == null)
            {
                return HttpNotFound();
            }

            PeliculasDetailsViewModel peliculaVm = Mapper.Map<Pelicula, PeliculasDetailsViewModel>(pelicula);
            return View(peliculaVm);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pelicula = _DbContext.Peliculas
                .Include(p => p.Estado)
                .Include(p => p.Calificacion)
                .Include(p => p.Genero)
                .SingleOrDefault(pe => pe.PeliculaId == id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }

            var peliculaVm = Mapper.Map<Pelicula, PeliculaListViewModel>(pelicula);
            return View(peliculaVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var pelicula = _DbContext.Peliculas
                .SingleOrDefault(pe => pe.PeliculaId == id);
            try
            {
                _DbContext.Peliculas.Remove(pelicula);
                _DbContext.SaveChanges();
                TempData["Msg"] = "Pelicula elimindad con exito";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                pelicula = _DbContext.Peliculas
                .Include(p => p.Estado)
                .Include(p => p.Calificacion)
                .Include(p => p.Genero)
                    .SingleOrDefault(pe => pe.PeliculaId == id);

                var peliculaVm = Mapper.Map<Pelicula, PeliculaListViewModel>(pelicula);

                ModelState.AddModelError(string.Empty, "Error al intentar borrar la pelicula");
                return View(peliculaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pelicula = _DbContext.Peliculas.SingleOrDefault(pe => pe.PeliculaId == id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }

            PeliculaEditViewModel peliculaVm = Mapper.Map<Pelicula, PeliculaEditViewModel>(pelicula);
            peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
            peliculaVm.Estados = CombosHelper.GetEstados();
            peliculaVm.Generos = CombosHelper.GetGeneros();

            return View(peliculaVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(PeliculaEditViewModel peliculaVm)
        {
            if (!ModelState.IsValid)
            {
                return View(peliculaVm);
            }

            var pelicula = Mapper.Map<PeliculaEditViewModel, Pelicula>(peliculaVm);
            peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
            peliculaVm.Estados = CombosHelper.GetEstados();
            peliculaVm.Generos = CombosHelper.GetGeneros();

            try
            {
                if (_DbContext.Peliculas.Any(pe => pe.Titulo == pelicula.Titulo && pe.PeliculaId != pelicula.PeliculaId))
                {
                    peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
                    peliculaVm.Estados = CombosHelper.GetEstados();
                    peliculaVm.Generos = CombosHelper.GetGeneros();

                    ModelState.AddModelError(string.Empty, "Pelicula repetida");
                    return View(peliculaVm);
                }
                _DbContext.Entry(pelicula).State = EntityState.Modified;
                _DbContext.SaveChanges();
                TempData["Msg"] = "Pelicula editada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                peliculaVm.Calificaciones = CombosHelper.GetCalificaciones();
                peliculaVm.Estados = CombosHelper.GetEstados();
                peliculaVm.Generos = CombosHelper.GetGeneros();

                ModelState.AddModelError(string.Empty, "Error al intentar editar la pelicula");
                return View(peliculaVm);
            }
        }

    }
}