using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.App_Start;
using SistemaDeVideoClubASPMVC.Context;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IServiciosGenero _Servicio;

        private readonly IMapper _mapper;
        //private readonly VideoClubDbContext _DbContext;
        //private readonly int _registrosPorPagina = 10;
        //private Listador<GeneroListViewModel> _listador;
        // GET: Generos
        public GenerosController()
        {
            _Servicio = new ServiciosGenero();
            _mapper = AutoMapperConfig.Mapper;
            //_DbContext = new VideoClubDbContext();

        }
        public ActionResult Index(int pagina=1)
        {
            //int totalRegistros = _DbContext.Generos.Count();

            //var genero = _DbContext.Generos
            //    .OrderBy(p => p.Descripcion)
            //    .Skip((pagina - 1) * _registrosPorPagina)
            //    .Take(_registrosPorPagina)
            //    .ToList();
            //var GeneroVm = Mapper.Map<List<Genero>, List<GeneroListViewModel>>(genero);
            //var totalPaginas = (int)Math.Ceiling((double)totalRegistros / _registrosPorPagina);
            //_listador = new Listador<GeneroListViewModel>()
            //{
            //    RegistrosPorPagina = _registrosPorPagina,
            //    TotalPaginas = totalPaginas,
            //    TotalRegistros = totalRegistros,
            //    PaginaActual = pagina,
            //    Registros = GeneroVm
            //};
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<GeneroListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(GeneroEditViewModel GeneroVm)
        {

            if (!ModelState.IsValid)
            {
                return View(GeneroVm);
            }
            GeneroEditDto generoDto = _mapper.Map<GeneroEditDto>(GeneroVm);

            if (_Servicio.Existe(generoDto))
            {
                ModelState.AddModelError(string.Empty, "Genero Existente");
                return View(GeneroVm);
            }
            try
            {
                _Servicio.Guardar(generoDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty,e.Message);
                return View(GeneroVm);

            }

            return View(GeneroVm);
        }

        //[HttpGet]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var genero = _DbContext.Generos.SingleOrDefault(g => g.GeneroId == id);
        //    if (genero == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    GeneroEditViewModel generoVm = Mapper.Map<Genero, GeneroEditViewModel>(genero);
        //    return View(generoVm);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Edit(GeneroEditViewModel generoVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(generoVm);
        //    }

        //    var genero = Mapper.Map<GeneroEditViewModel, Genero>(generoVm);
        //    try
        //    {
        //        if (_DbContext.Generos.Any(g => g.Descripcion == genero.Descripcion && g.GeneroId != genero.GeneroId))
        //        {
        //            ModelState.AddModelError(string.Empty, "Genero repetido");
        //            return View(generoVm);
        //        }

        //        _DbContext.Entry(genero).State = EntityState.Modified;
        //        _DbContext.SaveChanges();
        //        TempData["Msg"] = "Genero editado";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar un registro");
        //        return View(generoVm);
        //    }
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Genero genero = _DbContext.Generos.Find(id);
        //    if (genero == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(genero);
        //}


        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var genero = _DbContext.Generos.SingleOrDefault(g => g.GeneroId == id);
        //    if (genero == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var generoVm = Mapper.Map<Genero, GeneroListViewModel>(genero);
        //    return View(generoVm);
        //}

        //[ValidateAntiForgeryToken]
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirm(int id)
        //{
        //    var genero = _DbContext.Generos.SingleOrDefault(g => g.GeneroId == id);
        //    try
        //    {
        //        _DbContext.Generos.Remove(genero);
        //        _DbContext.SaveChanges();
        //        TempData["Msg"] = "Genero eliminado con exito";
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        var generoVm = Mapper.Map<Genero, GeneroListViewModel>(genero);

        //        ModelState.AddModelError(string.Empty, "Error al intentar borrar el genero");
        //        return View(generoVm);
        //    }
        //}

    }
}