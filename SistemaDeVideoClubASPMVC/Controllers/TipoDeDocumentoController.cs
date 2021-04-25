using AutoMapper;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}