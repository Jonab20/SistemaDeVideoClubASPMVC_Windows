using AutoMapper;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubASPMVC.App_Start;
using SistemaDeVideoClubASPMVC.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SistemaDeVideoClubASPMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Mapper.Initialize(cfg => { cfg.AddProfile<MappingProfile>(); });
            AreaRegistration.RegisterAllAreas();
            ModelBinders.Binders.Add(typeof(Carrito), new CarritoModelBinder());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
