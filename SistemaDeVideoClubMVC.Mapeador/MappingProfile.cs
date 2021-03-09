using AutoMapper;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubASPMVC.ViewModels.Genero;
using System;

namespace SistemaDeVideoClubASPMVC.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            loadGenerosMapping();
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

            //CreateMap<Provincia, ProvinciaEditViewModel>();
            //CreateMap<Provincia, ProvinciaListViewModel>();
            //CreateMap<ProvinciaEditViewModel, Provincia>();
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