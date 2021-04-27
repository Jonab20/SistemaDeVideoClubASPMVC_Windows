using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.ViewModels.SocioListViewModel;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubASPMVC.Models;
using SistemaDeVideoClubASPMVC.ViewModels;
using SistemaDeVideoClubASPMVC.ViewModels.Localidad;
using SistemaDeVideoClubASPMVC.ViewModels.Provincia;
using SistemaDeVideoClubASPMVC.ViewModels.Socio;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class SociosController : Controller
    {
        private readonly IServiciosSocios _servicio;
        private readonly IServicioTipoDeDocumento _serviciosTipo;
        private readonly IServicioLocalidades _serviciosLocalidad;
        private readonly IServiciosProvincia _serviciosProvincia;
        private readonly IMapper _mapper;
        // GET: Socios
        //private string provincia;
        public SociosController(IServiciosSocios servicio, IServicioTipoDeDocumento serviciosTipo, IServicioLocalidades serviciosLocalidad, IServiciosProvincia serviciosProvincia)
        {
            _serviciosTipo = serviciosTipo;
            _serviciosLocalidad = serviciosLocalidad;
            _serviciosProvincia = serviciosProvincia;
            _servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        public ActionResult Index(int pagina = 1)
        {
            var listaDto = _servicio.GetLista(null);
            var listaVm = _mapper.Map<List<SocioListViewModel>>(listaDto);
            return View(listaVm);
        }

        // GET: Socios/Crear
        public ActionResult Create()
        {
            
            SocioEditViewModel socioVm = new SocioEditViewModel
            {            

                TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista()),
                Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null)),
                Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista())
            };
            return View(socioVm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(SocioEditViewModel socioVm)
        {
            if (!ModelState.IsValid)
            {

                socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
                socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(socioVm);
            }

            SocioEditDto socioDto = _mapper.Map<SocioEditDto>(socioVm);

            if (_servicio.Existe(socioDto))
            {
                ModelState.AddModelError(string.Empty, "Socio existente");

                socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
                socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

                return View(socioVm);
            }
            try
            {
                _servicio.Guardar(socioDto);
                TempData["Msg"] = "Socio guardado";

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);

                socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
                socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

                return View(socioVm);
            }
        }

        // GET: Socios/Detalles

        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SocioListDto socioEditDto =_mapper.Map<SocioListDto>(_servicio.GetSocioPorId(id));
            if (socioEditDto == null)
            {
                return HttpNotFound("Codigo de Socio no encontrado");
            }
            SocioListViewModel socioVm = _mapper.Map<SocioListViewModel>(socioEditDto);

            socioVm.DescripcionTipoDeDocumento = socioEditDto.TipoDeDocumento;
            socioVm.NombreProvincia = socioEditDto.Provincia;
            socioVm.NombreLocalidad = socioEditDto.Localidad;

            return View(socioVm);
        }

        // GET: Socios/Editar


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SocioEditDto socioEditDto = _servicio.GetSocioPorId(id);
            if (socioEditDto == null)
            {
                return HttpNotFound("Codigo de Socio no encontrado");
            }
            SocioEditViewModel socioVm = _mapper.Map<SocioEditViewModel>(socioEditDto);
            socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
            socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
            socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());

            return View(socioVm);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(SocioEditViewModel socioVm)
        {
            if (!ModelState.IsValid)
            {
                socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
                socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(socioVm);
            }

            SocioEditDto socioDto = _mapper.Map<SocioEditDto>(socioVm);
            if (_servicio.Existe(socioDto))
            {
                ModelState.AddModelError(string.Empty, "Socio existente");
                socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
                socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                return View(socioVm);

            }
            try
            {
                _servicio.Guardar(socioDto);
                TempData["Msg"] = "Socio editado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                socioVm.TipoDeDocumentos = _mapper.Map<List<TipoDeDocumentoListViewModel>>(_serviciosTipo.GetLista());
                socioVm.Localidades = _mapper.Map<List<LocalidadListViewModel>>(_serviciosLocalidad.GetLista(null));
                socioVm.Provincias = _mapper.Map<List<ProvinciaListViewModel>>(_serviciosProvincia.GetLista());
                ModelState.AddModelError(string.Empty, "Error inesperado al intentar editar el socio");
                return View(socioVm);
            }

        }

        // GET: Socios/Borrar


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SocioListDto socioDto = _mapper.Map<SocioListDto>(_servicio.GetSocioPorId(id));
            if (socioDto == null)
            {
                return HttpNotFound("Codigo de socio inexistente");
            }

            SocioListViewModel socioVm = _mapper.Map<SocioListViewModel>(socioDto);
            return View(socioVm);

        }

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(SocioListViewModel socioVm)
        {
            try
            {
                SocioListDto socioDto = _mapper.Map<SocioListDto>(_servicio.GetSocioPorId(socioVm.SocioId));

                socioVm = _mapper.Map<SocioListViewModel>(socioDto);
                _servicio.Borrar(socioVm.SocioId);
                TempData["Msg"] = "Socio eliminado";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error al intentar eliminar socio");
                return View(socioVm);
            }

        }


    }
}