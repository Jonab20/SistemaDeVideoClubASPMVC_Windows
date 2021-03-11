using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Localidad;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubASPMVC.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioLocalidades : IRepositorioLocalidad
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;

        public RepositorioLocalidades(SistemaDeVideoClubDbContext dbContext)
        {
            _DbContext = dbContext;
            _mapper = Mapeador.CrearMapper();
        }
        public List<LocalidadListDto> GetLista()
        {
            try
            {
                var listaDto = _DbContext.localidades.Include(l=>l.Provincia).Select(p=>new LocalidadListDto 
                {
                 LocalidadId=p.LocalidadId,
                 NombreLocalidad = p.NombreLocalidad,
                 Provincia = p.Provincia.NombreProvincia
                }).ToList();
                return listaDto;
            }
            catch (Exception)
            {

                throw new Exception("Error al cargar localidades");
            } 
        }
    }
}
