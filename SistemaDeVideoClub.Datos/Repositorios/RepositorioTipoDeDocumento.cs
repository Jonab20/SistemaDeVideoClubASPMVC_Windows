using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.TipoDeDocumento;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioTipoDeDocumento : IRepositorioTipoDeDocumento
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;
        public RepositorioTipoDeDocumento(SistemaDeVideoClubDbContext dbContext)
        {
            _DbContext = dbContext;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int? id)
        {
            try
            {
                var tipoInDb = _DbContext.tiposDeDocumento.SingleOrDefault(td => td.TipoDeDocumentoId == id);
                _DbContext.Entry(tipoInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar el tipo");
            }
        }

        public bool Existe(TiposDeDocumentos tipo)
        {
            if (tipo.TipoDeDocumentoId == 0)
            {
                return _DbContext.tiposDeDocumento.Any(td => td.Descripcion == tipo.Descripcion);
            }
            return _DbContext.tiposDeDocumento.Any(td => td.Descripcion == tipo.Descripcion && td.TipoDeDocumentoId != tipo.TipoDeDocumentoId);
        }

        public List<TipoDeDocumentoListDto> GetLista()
        {
            try
            {
                var lista = _DbContext.tiposDeDocumento.ToList();
                return _mapper.Map<List<TipoDeDocumentoListDto>>(lista);
            }
            catch (Exception)
            {
                throw new Exception("Error al leer los tipos");
            }
        }

        public TipoDeDocumentoEditDto GetTipoPorId(int? id)
        {
            try
            {
                return _mapper.Map<TipoDeDocumentoEditDto>(_DbContext.tiposDeDocumento.SingleOrDefault(td => td.TipoDeDocumentoId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar obtener el tipo");
            }
        }

        public void Guardar(TiposDeDocumentos tipo)
        {
            try
            {
                if (tipo.TipoDeDocumentoId == 0)
                {
                    _DbContext.tiposDeDocumento.Add(tipo);
                }
                else
                {
                    var tipoInDb = _DbContext.tiposDeDocumento.SingleOrDefault(td => td.TipoDeDocumentoId == tipo.TipoDeDocumentoId);
                    tipoInDb.Descripcion = tipo.Descripcion;
                    _DbContext.Entry(tipoInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error inesperado al realizar la operacion de guardar");
            }
        }
    }
}
