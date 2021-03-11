using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.DTOs.Provincia;
using SistemaDeVideoClub.Entidades.Entidades;
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

        private void loadLocalidadesMapping()
        {
            CreateMap<LocalidadListDto, LocalidadListViewModel>();
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