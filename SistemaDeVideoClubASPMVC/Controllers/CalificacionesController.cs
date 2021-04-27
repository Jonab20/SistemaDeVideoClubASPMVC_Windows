using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.ViewModels.Calificacion;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class CalificacionesController : Controller
    {
        private readonly IServicioCalificaciones _Servicio;
        private readonly IMapper _mapper;

        public CalificacionesController(IServicioCalificaciones servicio)
        {
            _Servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Calificaciones
        public ActionResult Index()
        {
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<CalificacionListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CalificacionEditViewModel calVm)
        {

            if (!ModelState.IsValid)
            {
                return View(calVm);
            }
            CalificacionEditDto calDto = _mapper.Map<CalificacionEditDto>(calVm);

            if (_Servicio.Existe(calDto))
            {
                ModelState.AddModelError(string.Empty, "Calificacion Existente");
                return View(calVm);
            }
            try
            {
                _Servicio.Guardar(calDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(calVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalificacionEditDto calDto = _Servicio.GetCalificacionPorId(id);
            CalificacionEditViewModel calVm = _mapper.Map<CalificacionEditViewModel>(calDto);

            if (calVm == null)
            {
                return HttpNotFound();
            }
            return View(calVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(CalificacionEditViewModel calVm)
        {
            if (!ModelState.IsValid)
            {
                return View(calVm);
            }
            CalificacionEditDto calDto = _mapper.Map<CalificacionEditDto>(calVm);
            try
            {
                if (_Servicio.Existe(calDto))
                {
                    ModelState.AddModelError(string.Empty, "Calificacion repetida.");
                    return View(calVm);
                }

                _Servicio.Guardar(calDto);
                TempData["Msg"] = "Calificacion editada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar un registro");
                return View(calVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CalificacionEditDto calEditDto = _Servicio.GetCalificacionPorId(id);
            if (calEditDto == null)
            {
                return HttpNotFound("Codigo de calificacion inexistente.");
            }
            CalificacionEditViewModel calEditVm = _mapper.Map<CalificacionEditViewModel>(calEditDto);
            return View(calEditVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(CalificacionEditViewModel calVm)
        {
            try
            {
                calVm = _mapper.Map<CalificacionEditViewModel>(_Servicio.GetCalificacionPorId(calVm.CalificacionId));
                _Servicio.Borrar(calVm.CalificacionId);
                TempData["Msg"] = "Calificacion eliminada.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar borrar calificacion");
                return View(calVm);
            }
        }


    }
}