using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento;
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
    public class TipoDeDocumentoController : Controller
    {
        private readonly IServicioTipoDeDocumento _Servicio;
        private readonly IMapper _mapper;
        public TipoDeDocumentoController(IServicioTipoDeDocumento servicio)
        {
            _Servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: TipoDeDocumento
        public ActionResult Index()
        {
            var listaDto = _Servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoDeDocumentoListViewModel>>(listaDto);
            return View(listaVm);
        }
        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(TipoDeDocumentoEditViewModel tipoVm)
        {

            if (!ModelState.IsValid)
            {
                return View(tipoVm);
            }
            TipoDeDocumentoEditDto tipoDto = _mapper.Map<TipoDeDocumentoEditDto>(tipoVm);

            if (_Servicio.Existe(tipoDto))
            {
                ModelState.AddModelError(string.Empty, "Tipo Existente");
                return View(tipoVm);
            }
            try
            {
                _Servicio.Guardar(tipoDto);
                TempData["Msg"] = "Registro Agregado";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeDocumentoEditDto tipoDto = _Servicio.GetTipoPorId(id);
            TipoDeDocumentoEditViewModel tipoVm = _mapper.Map<TipoDeDocumentoEditViewModel>(tipoDto);

            if (tipoVm == null)
            {
                return HttpNotFound();
            }
            return View(tipoVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(TipoDeDocumentoEditViewModel TipoVm)
        {
            if (!ModelState.IsValid)
            {
                return View(TipoVm);
            }
            TipoDeDocumentoEditDto tipoDto = _mapper.Map<TipoDeDocumentoEditDto>(TipoVm);
            try
            {
                if (_Servicio.Existe(tipoDto))
                {
                    ModelState.AddModelError(string.Empty, "Tipo de Documento repetido.");
                    return View(TipoVm);
                }

                _Servicio.Guardar(tipoDto);
                TempData["Msg"] = "Tipo de Documento editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar un registro");
                return View(TipoVm);
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TipoDeDocumentoEditDto tipoEditDto = _Servicio.GetTipoPorId(id);
            if (tipoEditDto == null)
            {
                return HttpNotFound("Codigo de tipo inexistente.");
            }
            TipoDeDocumentoEditViewModel tipoEditVm = _mapper.Map<TipoDeDocumentoEditViewModel>(tipoEditDto);
            return View(tipoEditVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(TipoDeDocumentoEditViewModel tipoVm)
        {
            try
            {
                tipoVm = _mapper.Map<TipoDeDocumentoEditViewModel>(_Servicio.GetTipoPorId(tipoVm.TipoDeDocumentoId));
                _Servicio.Borrar(tipoVm.TipoDeDocumentoId);
                TempData["Msg"] = "Tipo eliminado.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar borrar tipo");
                return View(tipoVm);
            }
        }


    }
}