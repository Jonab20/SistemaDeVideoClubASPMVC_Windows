using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Alquiler;
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
    public class ServicioAlquiler : IServicioAlquiler
    {
        private readonly IRepositorioAlquiler _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioAlquiler(IRepositorioAlquiler repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.CrearMapper();

        }
        public void Borrar(int alquilerEditDto)
        {
            try
            {
                _repositorio.Borrar(alquilerEditDto);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public AlquilerEditDto GetAlquilerPorId(int? id)
        {
            try
            {
                return _repositorio.GetAlquilerPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }

        public List<AlquilerListDto> GetLista(string listaDto)
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

        public void Guardar(AlquilerEditDto alquilerEditDto)
        {
            try
            {
                Alquiler alquiler = _mapper.Map<Alquiler>(alquilerEditDto);
                _repositorio.Guardar(alquiler);
                _unitOfWork.Save();
                alquilerEditDto.AlquilerId = alquiler.AlquilerId;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);

            }
        }
    }
}
