using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels.Provincia;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly IServiciosProvincia _Servicio;
        private readonly IMapper _mapper;
        // GET: Provincias

        public ProvinciasController(IServiciosProvincia servicio)
        {
            _Servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        public ActionResult Index(int pagina=1)
        {
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<ProvinciaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinciaEditDto provinciaDto = _Servicio.GetProvinciaPorId(id);
            ProvinciaEditViewModel provinciaVm = _mapper.Map<ProvinciaEditViewModel>(provinciaDto);

            if (provinciaVm == null)
            {
                return HttpNotFound();
            }
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
            ProvinciaEditDto gemeroDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);
            try
            {
                if (_Servicio.Existe(gemeroDto))
                {
                    ModelState.AddModelError(string.Empty, "Provincia repetida.");
                    return View(provinciaVm);
                }

                _Servicio.Guardar(gemeroDto);
                TempData["Msg"] = "Provincia editada";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar la provincia");
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
            ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);

            if (_Servicio.Existe(provinciaDto))
            {
                ModelState.AddModelError(string.Empty, "Provincia Existente");
                return View(provinciaVm);
            }
            try
            {
                _Servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Provincia Agregada";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);

            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProvinciaEditDto provinciaEditDto = _Servicio.GetProvinciaPorId(id);
            if (provinciaEditDto == null)
            {
                return HttpNotFound("Codigo del genero inexistente.");
            }
            ProvinciaEditViewModel provinciaEditVm = _mapper.Map<ProvinciaEditViewModel>(provinciaEditDto);
            return View(provinciaEditVm);

        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(ProvinciaEditViewModel provinciaVm)
        {
            try
            {
                provinciaVm = _mapper.Map<ProvinciaEditViewModel>(_Servicio.GetProvinciaPorId(provinciaVm.ProvinciaId));
                _Servicio.Borrar(provinciaVm.ProvinciaId);
                TempData["Msg"] = "Provincia eliminada.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar borrar la provincia");
                return View(provinciaVm);
            }

        }


        //// GET: Paises/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Provincia provincia = _DbContext.Provincias.Find(id);
        //    if (provincia == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(provincia);
        //}
    }



}
