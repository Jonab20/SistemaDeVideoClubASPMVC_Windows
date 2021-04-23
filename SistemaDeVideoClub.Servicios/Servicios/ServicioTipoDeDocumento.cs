using AutoMapper;
using SistemaDeVideoClub.Datos;
using SistemaDeVideoClub.Datos.Repositorios;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
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
    public class ServicioTipoDeDocumento : IServicioTipoDeDocumento
    {
        private readonly IRepositorioTipoDeDocumento _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServicioTipoDeDocumento(IUnitOfWork unitOfWork, IRepositorioTipoDeDocumento repositorio)
        {
            _unitOfWork = unitOfWork;
            _repositorio = repositorio;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoDeDocumentoEditDto tipoDto)
        {
            try
            {
                TiposDeDocumentos tipo = _mapper.Map<TiposDeDocumentos>(tipoDto);
                return _repositorio.Existe(tipo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoDeDocumentoListDto> GetLista()
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

        public TipoDeDocumentoEditDto GetTipoPorId(int? id)
        {
            try
            {
                return _repositorio.GetTipoPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoDeDocumentoEditDto TipoDto)
        {
            try
            {
                TiposDeDocumentos tipo = _mapper.Map<TiposDeDocumentos>(TipoDto);
                _repositorio.Guardar(tipo);
                _unitOfWork.Save();
                TipoDto.TipoDeDocumentoId = tipo.TipoDeDocumentoId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
