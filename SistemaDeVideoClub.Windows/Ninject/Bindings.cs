using Ninject.Modules;
using System.Threading.Tasks;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Servicios.Servicios;
using SistemaDeVideoClub.Servicios.Servicios.Facades;

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

            Bind<IRepositorioProvincias>().To<RepositorioProvincias>();
            Bind<IServiciosProvincia>().To<ServicioProvincia>();

            Bind<IRepositorioLocalidades>().To<RepositorioLocalidades>();
            Bind<IServicioLocalidades>().To<ServicioLocalidades>();

            //Bind<IRepositorioEstados>().To<RepositorioEstados>();
            //Bind<IServicioEstados>().To<ServicioEstado>();

            //Bind<IRepositorioCalificaciones>().To<RepositorioCalificaciones>();
            //Bind<IServicioCalificaciones>().To<ServicioCalificacion>();

            //Bind<IRepositorioTiposDeSoporte>().To<RepositorioTiposDeSoporte>();
            //Bind<IServicioTiposDeSoporte>().To<ServicioTipoDeSoporte>();

            //Bind<IRepositorioTiposDeDocumentos>().To<RepositorioTiposDeDocumentos>();
            //Bind<IServicioTipoDeDocumento>().To<ServicioTipoDeDocumento>();
        }
    }
}
