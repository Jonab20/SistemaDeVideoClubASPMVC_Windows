using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.DTOs.Soporte;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Entidades.ViewModels.Calificacion;
using SistemaDeVideoClub.Entidades.ViewModels.Estado;
using SistemaDeVideoClub.Entidades.ViewModels.SocioListViewModel;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.ViewModels.Soporte;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using SistemaDeVideoClubASPMVC.ViewModels.Localidad;
using SistemaDeVideoClubASPMVC.ViewModels.Provincia;
using SistemaDeVideoClubASPMVC.ViewModels.Socio;
using System;
using SistemaDeVideoClub.Entidades.DTOs.Pelicula;
using SistemaDeVideoClub.Entidades.ViewModels.Pelicula;
using SistemaDeVideoClub.Entidades.ViewModels.Carrito;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.ItemAlquiler;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
using SistemaDeVideoClub.Entidades.ViewModels.Alquiler;

namespace SistemaDeVideoClubASPMVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            loadGenerosMapping();

            loadProvinciasMapping();

            loadLocalidadesMapping();

            loadEstadosMapping();

            loadCalificacionesMapping();

            loadTipoDeDocumentoMapping();

            loadSoporteMapping();

            loadSocioMapping();

            loadPeliculaMapping();

            loadCarritoMapping();

            LoadItemAlquilerMapping();

            LoadAlquilerMapping();


        }

        private void LoadAlquilerMapping()
        {
            CreateMap<Alquiler, AlquilerListDto>();

            //CreateMap<Venta, VentaListDto>().ForMember(dest=>dest.ItemsVentas, act=>act.MapFrom(src=>src.ItemsVentas))
            //    .ReverseMap();
            CreateMap<Alquiler, AlquilerEditDto>()
                .ReverseMap();
            //CreateMap<AlquilerListDto, AlquilerDetailsViewModel>();

            //CreateMap<AlquilerListDto, AlquilerDetailsViewModel>()
                //.ForMember(dest => dest.Detalles, act => act.MapFrom(src => src.ItemsVentas));
            //CreateMap<VentaListDto, VentaListViewModel>();
            CreateMap<AlquilerEditDto, AlquilerListDto>().ReverseMap();
            CreateMap<AlquilerListViewModel, AlquilerListDto>().ReverseMap();
        }

        private void LoadItemAlquilerMapping()
        {
            CreateMap<ItemAlquiler, ItemAlquilerListDto>()
     .ForMember(dest => dest.Pelicula, act => act.MapFrom(src => src.Pelicula.Titulo));


            CreateMap<ItemAlquiler, ItemAlquilerEditDto>()
                .ForMember(dest => dest.Pelicula, act => act.MapFrom(src => src.Pelicula.Titulo)).ReverseMap();
            //CreateMap<ItemAlquilerListDto, ItemAlquilerListViewModel>();
            CreateMap<ItemAlquilerEditDto, ItemAlquilerListDto>().ForMember(dest => dest.Pelicula,
                act => act.MapFrom(src => src.Pelicula.Titulo));

        }

        private void loadCarritoMapping()
        {
            CreateMap<ItemCarrito, ItemCarritoListViewModel>().ForMember(dest => dest.PeliculaListViewModel, act => act.MapFrom(src => src.pelicula));


            CreateMap<Pelicula, PeliculaListViewModel>()
                .ForMember(dest => dest.Genero, act => act.MapFrom(src => src.Genero.Descripcion))
                .ForMember(dest => dest.Calificacion, act => act.MapFrom(src => src.Calificacion.Descripcion))
                .ForMember(dest => dest.Estado, act => act.MapFrom(src => src.Estado.Descripcion));


            CreateMap<Carrito, CarritoListViewModel>().ForMember(dest => dest.items, act => act.MapFrom(src => src.listaPeliculaAlquiler));

        }

        private void loadPeliculaMapping()
        {
            CreateMap<PeliculaListViewModel, PeliculaListDto>().ReverseMap();
            CreateMap<PeliculaEditDto, PeliculaListDto>();
            CreateMap<Pelicula, PeliculaListDto>().ReverseMap();
            CreateMap<PeliculaEditDto, Pelicula>().ReverseMap();
            CreateMap<PeliculaListDto, PeliculaListViewModel>().ReverseMap();
            CreateMap<PeliculaEditViewModel, PeliculaEditDto>().ReverseMap();
        }

        private void loadSocioMapping()
        {
            CreateMap<SocioEditDto, SocioListDto>().ReverseMap();
            CreateMap<SocioEditDto, Socio>().ReverseMap();
            CreateMap<SocioListDto, SocioListViewModel>().ReverseMap();
            CreateMap<SocioEditViewModel, SocioEditDto>().ReverseMap();
        }

        private void loadSoporteMapping()
        {
            CreateMap<Soporte, SoporteListDto>();
            CreateMap<Soporte, SoporteEditDto>().ReverseMap();
            CreateMap<SoporteListDto, SoporteListViewModel>().ReverseMap();
            CreateMap<SoporteEditDto, SoporteEditViewModel>().ReverseMap();
            CreateMap<SoporteEditDto, SoporteListDto>().ReverseMap();
        }

        private void loadTipoDeDocumentoMapping()
        {
            CreateMap<Calificacion, CalificacionListDto>();
            CreateMap<Calificacion, CalificacionEditDto>().ReverseMap();
            CreateMap<CalificacionListDto, CalificacionListViewModel>().ReverseMap();
            CreateMap<CalificacionEditDto, CalificacionEditViewModel>().ReverseMap();
            CreateMap<CalificacionEditDto, CalificacionListDto>().ReverseMap();
        }

        private void loadCalificacionesMapping()
        {
            CreateMap<TipoDeDocumento, TipoDeDocumentoListDto>();
            CreateMap<TipoDeDocumento, TipoDeDocumentoEditDto>().ReverseMap();
            CreateMap<TipoDeDocumentoListDto, TipoDeDocumentoListViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoEditViewModel>().ReverseMap();
            CreateMap<TipoDeDocumentoEditDto, TipoDeDocumentoListDto>().ReverseMap();
        }

        private void loadEstadosMapping()
        {
            CreateMap<Estado, EstadoListDto>();
            CreateMap<Estado, EstadoEditDto>().ReverseMap();
            CreateMap<EstadoListDto, EstadoListViewModel>().ReverseMap();
            CreateMap<EstadoEditDto, EstadoEditViewModel>().ReverseMap();
            CreateMap<EstadoEditDto, EstadoListDto>().ReverseMap();
        }

        private void loadLocalidadesMapping()
        {
            CreateMap<LocalidadEditDto, LocalidadListDto>();
            CreateMap<LocalidadEditDto, Localidad>().ReverseMap();
            CreateMap<LocalidadListDto, LocalidadListViewModel>().ReverseMap();
            CreateMap<LocalidadEditViewModel, LocalidadEditDto>().ReverseMap();
        }

        private void loadProvinciasMapping()
        {
            CreateMap<Provincia, ProvinciaListDto>();
            CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaListDto, ProvinciaListViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaEditViewModel>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaEditDto>().ReverseMap();
            CreateMap<ProvinciaEditDto, ProvinciaListDto>().ReverseMap();
        }

        private void loadGenerosMapping()
        {
            CreateMap<Genero, GeneroListDto>();
            CreateMap<Genero, GeneroEditDto>().ReverseMap();
            CreateMap<GeneroListDto, GeneroListViewModel>().ReverseMap();
            CreateMap<GeneroEditDto, GeneroEditViewModel>().ReverseMap();
            CreateMap<GeneroEditDto, GeneroListDto>().ReverseMap();
        }
    }
}