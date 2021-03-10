using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.App_Start;
using SistemaDeVideoClubASPMVC.Context;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IServiciosGenero _Servicio;
        private readonly IMapper _mapper;
        // GET: Generos
        public GenerosController()
        {
            _Servicio = new ServiciosGenero();
            _mapper = Mapeador.CrearMapper();
        }
        public ActionResult Index(int pagina=1)
        {
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
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeneroEditDto generoDto = _Servicio.GetGeneroPorId(id);
            GeneroEditViewModel generoVm = _mapper.Map<GeneroEditViewModel>(generoDto);

            if (generoVm == null)
            {
                return HttpNotFound();
            }
            return View(generoVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(GeneroEditViewModel generoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(generoVm);
            }
            GeneroEditDto gemeroDto = _mapper.Map<GeneroEditDto>(generoVm);
            try
            {
                if (_Servicio.Existe(gemeroDto))
                {
                    ModelState.AddModelError(string.Empty, "Genero repetido.");
                    return View(generoVm);
                }

                _Servicio.Guardar(gemeroDto);
                TempData["Msg"] = "Genero editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar un registro");
                return View(generoVm);
            }
        }

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


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            GeneroEditDto generoEditDto = _Servicio.GetGeneroPorId(id);
            if (generoEditDto == null)
            {
                return HttpNotFound("Codigo del genero inexistente.");
            }
            GeneroEditViewModel generoEditVm = _mapper.Map<GeneroEditViewModel>(generoEditDto);
            return View(generoEditVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(GeneroEditViewModel generoVm)
        {
            try
            {
                generoVm = _mapper.Map<GeneroEditViewModel>(_Servicio.GetGeneroPorId(generoVm.GeneroId));
                _Servicio.Borrar(generoVm.GeneroId);                  
                TempData["Msg"] = "Genero eliminado.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar borrar el genero");
                return View(generoVm);
            }
        }

    }
}