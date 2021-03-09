using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Datos.Repositorios;
using SistemaDeVideoClub.Entidades.DTOs.Genero;
using AutoMapper;
using SistemaDeVideoClubMVC.Mapeador;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServiciosGenero : IServiciosGenero
    {
        private readonly IrepositorioGeneros _repositorio;
        private readonly IMapper _mapper;
        public ServiciosGenero()
        {
            _repositorio = new RepositorioGeneros();
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
            }
            catch (Exception e)
            {

                throw new Exception (e.Message);
            }
        }

        public bool Existe(GeneroEditDto generoDto)
        {
            try
            {
                Genero genero = _mapper.Map<Genero>(generoDto);
                return _repositorio.Existe(genero);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public GeneroEditDto GetGeneroPorId(int? id)
        {
            try
            {
                return _repositorio.GetGeneroPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<GeneroListDto> GetLista()
        {
            try
            {

                return _repositorio.GetLista();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(GeneroEditDto generoDto)
        {
            try
            {
                Genero genero = _mapper.Map<Genero>(generoDto);
                _repositorio.Guardar(genero);
            }
            catch (Exception e)
            {

                throw new Exception (e.Message);
            }
        }
    }
}
