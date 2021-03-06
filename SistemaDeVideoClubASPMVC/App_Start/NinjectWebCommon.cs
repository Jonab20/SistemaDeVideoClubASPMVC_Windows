[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SistemaDeVideoClubASPMVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SistemaDeVideoClubASPMVC.App_Start.NinjectWebCommon), "Stop")]

namespace SistemaDeVideoClubASPMVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using SistemaDeVideoClub.Datos;
    using SistemaDeVideoClub.Datos.Repositorios;
    using SistemaDeVideoClub.Datos.Repositorios.Facades;
    using SistemaDeVideoClub.Servicios.Servicios;
    using SistemaDeVideoClub.Servicios.Servicios.Facades;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServiciosGenero>().To<ServiciosGenero>().InRequestScope();
            kernel.Bind<IRepositorioGeneros>().To<RepositorioGeneros>().InRequestScope();

            kernel.Bind<IServiciosProvincia>().To<ServicioProvincia>().InRequestScope();
            kernel.Bind<IRepositorioProvincias>().To<RepositorioProvincias>().InRequestScope();

            kernel.Bind<IServicioLocalidades>().To<ServicioLocalidades>().InRequestScope();
            kernel.Bind<IRepositorioLocalidades>().To<RepositorioLocalidades>().InRequestScope();

            kernel.Bind<IServicioEstados>().To<ServicioEstado>().InRequestScope();
            kernel.Bind<IRepositorioEstados>().To<RepositorioEstados>().InRequestScope();

            kernel.Bind<IServicioCalificaciones>().To<ServicioCalificacion>().InRequestScope();
            kernel.Bind<IRepositorioCalificaciones>().To<RepositorioCalificaciones>().InRequestScope();

            kernel.Bind<IServicioTipoDeDocumento>().To<ServicioTipoDeDocumento>().InRequestScope();
            kernel.Bind<IRepositorioTiposDeDocumentos>().To<RepositorioTiposDeDocumentos>().InRequestScope();

            kernel.Bind<IServiciosSocios>().To<ServicioSocio>().InRequestScope();
            kernel.Bind<IRepositorioSocios>().To<RepositorioSocios>().InRequestScope();

            kernel.Bind<IServicioPelicula>().To<ServicioPeliculas>().InRequestScope();
            kernel.Bind<IRepositorioPeliculas>().To<RepositorioPeliculas>().InRequestScope();

            kernel.Bind<IServicioSoporte>().To<ServicioSoporte>().InRequestScope();
            kernel.Bind<IRepositorioSoporte>().To<RepositorioSoporte>().InRequestScope();

            kernel.Bind<IServicioAlquiler>().To<ServicioAlquiler>().InRequestScope();
            kernel.Bind<IRepositorioAlquileres>().To<RepositorioAlquileres>().InRequestScope();
            kernel.Bind<IRepositorioItemAlquiler>().To<RepositorioItemAlquileres>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(SistemaDeVideoClubDbContext)).ToSelf().InSingletonScope();


        }
    }
}