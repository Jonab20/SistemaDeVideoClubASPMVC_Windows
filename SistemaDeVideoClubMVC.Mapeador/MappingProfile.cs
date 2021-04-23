using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Calificacion;
using SistemaDeVideoClub.Entidades.DTOs.Estado;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeSoporte;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Entidades.ViewModels.Calificacion;
using SistemaDeVideoClub.Entidades.ViewModels.Estado;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.ViewModels.TipoDeSoporte;
using SistemaDeVideoClubASPMVC.Entidades;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using SistemaDeVideoClubASPMVC.ViewModels.Localidad;
using SistemaDeVideoClubASPMVC.ViewModels.Provincia;
using System;

namespace SistemaDeVideoClubASPMVC.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            loadGenerosMapping();

            loadProvinciasMapping();

            loadLocalidadesMapping();

            loadEstadosMapping();

            loadCalificacionesMapping();

            loadTipoDeDocumentoMapping();

            loadTipoDeSoporteMapping();
            //CreateMap<Pelicula, PeliculaEditViewModel>();
            //CreateMap<Pelicula, PeliculaListViewModel>()
            //    .ForMember(dest => dest.Genero, (g => g.MapFrom(ge => ge.Genero.Descripcion)))
            //    .ForMember(dest => dest.Estado, (e => e.MapFrom(es => es.Estado.Descripcion)))
            //    .ForMember(dest => dest.Calificacion, (c => c.MapFrom(ca => ca.Calificacion.Descripcion)));
            //CreateMap<PeliculaEditViewModel, Pelicula>();

            //CreateMap<Pelicula, PeliculasDetailsViewModel>()
            //    .ForMember(dest => dest.Genero, (g => g.MapFrom(ge => ge.Genero.Descripcion)))
            //    .ForMember(dest => dest.Estado, (e => e.MapFrom(es => es.Estado.Descripcion)))
            //    .ForMember(dest => dest.Calificacion, (c => c.MapFrom(ca => ca.Calificacion.Descripcion)));



            //CreateMap<Socio, SocioEditViewModel>();
            //CreateMap<Socio, SocioListViewModel>()
            //    .ForMember(dest => dest.NombreLocalidad, (l => l.MapFrom(lo => lo.Localidad.NombreLocalidad)))
            //    .ForMember(dest => dest.NombreProvincia, (p => p.MapFrom(pr => pr.Provincia.NombreProvincia)))
            //    .ForMember(dest => dest.DescripcionTipoDeDocumento, (t => t.MapFrom(td => td.TipoDeDocumento.Descripcion)));
            //CreateMap<Socio, SocioDetailViewMode>()
            //    .ForMember(dest => dest.NombreLocalidad, (l => l.MapFrom(lo => lo.Localidad.NombreLocalidad)))
            //    .ForMember(dest => dest.NombreProvincia, (p => p.MapFrom(pr => pr.Provincia.NombreProvincia)))
            //    .ForMember(dest => dest.DescripcionTipoDeDocumento, (t => t.MapFrom(td => td.TipoDeDocumento.Descripcion)));
            //CreateMap<SocioEditViewModel, Socio>();

            //CreateMap<Localidad, LocalidadEditViewModel>();
            //CreateMap<Localidad, LocalidadListViewModel>()
            //    .ForMember(dest => dest.NombreProvincia, (p => p.MapFrom(pr => pr.Provincia.NombreProvincia)));
            //CreateMap<Localidad, LocalidadDetailViewModel>()
            //    .ForMember(dest => dest.NombreProvincia, (p => p.MapFrom(pr => pr.Provincia.NombreProvincia)));
            //CreateMap<LocalidadEditViewModel, Localidad>();
        }

        private void loadTipoDeSoporteMapping()
        {
            CreateMap<TipoDeSoporte, TipoDeSoporteListDto>();
            CreateMap<TipoDeSoporte, TipoDeSoporteEditDto>().ReverseMap();
            CreateMap<TipoDeSoporteListDto, TipoDeSoporteListViewModel>().ReverseMap();
            CreateMap<TipoDeSoporteEditDto, TipoDeSoporteEditViewModel>().ReverseMap();
            CreateMap<TipoDeSoporteEditDto, TipoDeSoporteListDto>().ReverseMap();
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
            CreateMap<TiposDeDocumentos, TipoDeDocumentoListDto>();
            CreateMap<TiposDeDocumentos, TipoDeDocumentoEditDto>().ReverseMap();
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