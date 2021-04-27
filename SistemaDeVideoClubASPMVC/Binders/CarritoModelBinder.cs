using SistemaDeVideoClub.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaDeVideoClubASPMVC.Binders
{
    public class CarritoModelBinder:IModelBinder
    {
        private const string sessionkey = "SolidSkane";

        public Object BindModel(ControllerContext ControllerContext, ModelBindingContext bindingContext)
        {
            Carrito carrito = null;
            if (ControllerContext.HttpContext.Session[sessionkey]!= null)
            {
                carrito = (Carrito)ControllerContext.HttpContext.Session[sessionkey];
            }
            if (carrito==null)
            {
                carrito = new Carrito();
                if (ControllerContext.HttpContext.Session[sessionkey] == null)
                {
                    ControllerContext.HttpContext.Session[sessionkey] = carrito;
                }
            }
            return carrito;
        }
    }
}