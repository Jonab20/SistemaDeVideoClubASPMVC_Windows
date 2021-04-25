using AutoMapper;
using SistemaDeVideoClub.Entidades.ViewModels.Calificacion;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}