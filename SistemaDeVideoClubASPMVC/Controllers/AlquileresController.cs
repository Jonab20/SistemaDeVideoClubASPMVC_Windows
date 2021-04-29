using AutoMapper;
using SistemaDeVideoClub.Entidades.ViewModels.Alquiler;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Controllers
{
    public class AlquileresController : Controller
    {
        private readonly IServicioAlquiler _servicio;

        private readonly IMapper _mapper;

        public AlquileresController(IServicioAlquiler servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.CrearMapper();
        }
        // GET: Alquiler
        public ActionResult Index()
        {
            var alquilerDto = _servicio.GetLista();
            var alquilerVm = _mapper.Map<List<AlquilerListViewModel>>(alquilerDto);
            return View(alquilerVm);
        }

    }
}