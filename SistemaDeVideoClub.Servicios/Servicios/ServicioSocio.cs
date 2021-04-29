using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClub.Servicios.Servicios.Facades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Servicios.Servicios
{
    public class ServicioSocio:IServiciosSocios
    {
        private readonly IRepositorioSocios _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioSocio(IRepositorioSocios repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int socioEditDto)
        {
            try
            {
                _repositorio.Borrar(socioEditDto);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(SocioEditDto socioEditDto)
        {
            try
            {
                Socio socio = _mapper.Map<Socio>(socioEditDto);
                return _repositorio.Existe(socio);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<SocioListDto> GetLista(string listaDto)
        {
            try
            {
                return _repositorio.GetLista(listaDto);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public SocioEditDto GetSocioPorId(int? id)
        {
            try
            {
                return _repositorio.GetSocioPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }

        }

        public void Guardar(SocioEditDto socioEditDto)
        {
            try
            {
                Socio socio = _mapper.Map<Socio>(socioEditDto);
                _repositorio.Guardar(socio);
                _unitOfWork.Save();
                socioEditDto.SocioId = socio.SocioId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }

        }
    }
}
