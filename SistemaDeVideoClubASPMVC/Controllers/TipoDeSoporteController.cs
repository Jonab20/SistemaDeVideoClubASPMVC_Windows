using AutoMapper;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeSoporte;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class TipoDeSoporteController : Controller
    {
        private readonly IServicioTiposDeSoporte _Servicio;
        private readonly IMapper _mapper;
        public TipoDeSoporteController(IServicioTiposDeSoporte servicio)
        {
            _Servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: TipoDeSoporte
        public ActionResult Index()
        {
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeSoporteListViewModel>>(listaDto);
            return View(listaVm);
        }

        // GET: TipoDeSoporte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TipoDeSoporte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDeSoporte/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDeSoporte/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoDeSoporte/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDeSoporte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoDeSoporte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
