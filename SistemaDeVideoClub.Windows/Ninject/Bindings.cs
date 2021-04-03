using Ninject.Modules;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Windows.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<SistemaDeVideoClubDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositorioGeneros>().To<RepositorioGeneros>();
            Bind<IServiciosGenero>().To<ServiciosGenero>();

            Bind<IRepositorioProvincia>().To<RepositorioProvincias>();
            Bind<IServiciosProvincia>().To<ServicioProvincia>();

            Bind<IRepositorioLocalidad>().To<RepositorioLocalidades>();
            Bind<IServicioLocalidades>().To<ServicioLocalidades>();
        }
    }
}
