using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Soporte;
using SistemaDeVideoClub.Entidades.ViewModels.Soporte;
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
    public class SoporteController : Controller
    {
        private readonly IServicioSoporte _Servicio;
        private readonly IMapper _mapper;
        public SoporteController(IServicioSoporte servicio)
        {
            _Servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Soporte
        public ActionResult Index()
        {
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<SoporteListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(SoporteEditViewModel SoporteVm)
        {

            if (!ModelState.IsValid)
            {
                return View(SoporteVm);
            }
            SoporteEditDto soporteDto = _mapper.Map<SoporteEditDto>(SoporteVm);

            if (_Servicio.Existe(soporteDto))
            {
                ModelState.AddModelError(string.Empty, "Soporte Existente");
                return View(SoporteVm);
            }
            try
            {
                _Servicio.Guardar(soporteDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(SoporteVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoporteEditDto soporteDto = _Servicio.GetSoportePorId(id);
            SoporteEditViewModel soporteVm = _mapper.Map<SoporteEditViewModel>(soporteDto);

            if (soporteVm == null)
            {
                return HttpNotFound();
            }
            return View(soporteVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(SoporteEditViewModel soporteVm)
        {
            if (!ModelState.IsValid)
            {
                return View(soporteVm);
            }
            SoporteEditDto soporteDto = _mapper.Map<SoporteEditDto>(soporteVm);
            try
            {
                if (_Servicio.Existe(soporteDto))
                {
                    ModelState.AddModelError(string.Empty, "Soporte repetido.");
                    return View(soporteVm);
                }

                _Servicio.Guardar(soporteDto);
                TempData["Msg"] = "Soporte editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar un registro");
                return View(soporteVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SoporteEditDto soporteEditDto = _Servicio.GetSoportePorId(id);
            if (soporteEditDto == null)
            {
                return HttpNotFound("Codigo de soporte inexistente.");
            }
            SoporteEditViewModel soporteEditVm = _mapper.Map<SoporteEditViewModel>(soporteEditDto);
            return View(soporteEditVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(SoporteEditViewModel soporteVm)
        {
            try
            {
                soporteVm = _mapper.Map<SoporteEditViewModel>(_Servicio.GetSoportePorId(soporteVm.SoporteId));
                _Servicio.Borrar(soporteVm.SoporteId);
                TempData["Msg"] = "Soporte eliminado.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar borrar el soporte");
                return View(soporteVm);
            }
        }

    }
}