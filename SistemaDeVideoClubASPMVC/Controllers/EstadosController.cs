using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.ViewModels.Estado;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System.Collections.Generic;
using System;
using System.Web.Mvc;
using System.Net;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class EstadosController : Controller
    {
        private readonly IServicioEstados _Servicio;
        private readonly IMapper _mapper;
        public EstadosController(IServicioEstados servicio)
        {
            _Servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }

        // GET: Estados
        public ActionResult Index()
        {
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<EstadoListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(EstadoEditViewModel EstadoVm)
        {

            if (!ModelState.IsValid)
            {
                return View(EstadoVm);
            }
            EstadoEditDto estadoDto = _mapper.Map<EstadoEditDto>(EstadoVm);

            if (_Servicio.Existe(estadoDto))
            {
                ModelState.AddModelError(string.Empty, "Estado Existente");
                return View(EstadoVm);
            }
            try
            {
                _Servicio.Guardar(estadoDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(EstadoVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoEditDto estadoDto = _Servicio.GetEstadoPorId(id);
            EstadoEditViewModel estadoVm = _mapper.Map<EstadoEditViewModel>(estadoDto);

            if (estadoVm == null)
            {
                return HttpNotFound();
            }
            return View(estadoVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(EstadoEditViewModel estadoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(estadoVm);
            }
            EstadoEditDto estadoDto = _mapper.Map<EstadoEditDto>(estadoVm);
            try
            {
                if (_Servicio.Existe(estadoDto))
                {
                    ModelState.AddModelError(string.Empty, "Estado repetido.");
                    return View(estadoVm);
                }

                _Servicio.Guardar(estadoDto);
                TempData["Msg"] = "Estado editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar un registro");
                return View(estadoVm);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EstadoEditDto estadoEditDto = _Servicio.GetEstadoPorId(id);
            if (estadoEditDto == null)
            {
                return HttpNotFound("Codigo de estado inexistente.");
            }
            EstadoEditViewModel estadoEditVm = _mapper.Map<EstadoEditViewModel>(estadoEditDto);
            return View(estadoEditVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(EstadoEditViewModel estadoVm)
        {
            try
            {
                estadoVm = _mapper.Map<EstadoEditViewModel>(_Servicio.GetEstadoPorId(estadoVm.EstadoId));
                _Servicio.Borrar(estadoVm.EstadoId);
                TempData["Msg"] = "Estado eliminado.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar borrar estado");
                return View(estadoVm);
            }
        }

    }
}