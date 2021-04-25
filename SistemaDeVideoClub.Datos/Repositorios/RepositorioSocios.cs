using AutoMapper;
using SistemaDeVideoClub.Datos.Repositorios.Facades;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using SistemaDeVideoClub.Entidades.Entidades;
using SistemaDeVideoClubMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeVideoClub.Datos.Repositorios
{
    public class RepositorioSocios : IRepositorioSocios
    {
        private readonly SistemaDeVideoClubDbContext _DbContext;
        private readonly IMapper _mapper;
        public RepositorioSocios(SistemaDeVideoClubDbContext dbContext)
        {
            _DbContext = dbContext;
            _mapper = Mapeador.CrearMapper();
        }
        public void Borrar(int SociovmId)
        {
            try
            {
                var SocioInDb = _DbContext.Socios.SingleOrDefault(s => s.SocioId == SociovmId);
                if (SocioInDb == null)
                {
                    throw new Exception("Socio inexistente");

                }
                _DbContext.Entry(SocioInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {

                throw new Exception("Error al Borrar Socio");

            }
        }

        public bool Existe(Socio socio)
        {
            try
            {
                if (socio.SocioId == 0)
                {
                    return _DbContext.Socios.Any(s => s.NroDocumento == socio.NroDocumento);
                }
                return _DbContext.Socios.Any(s => s.NroDocumento == socio.NroDocumento && s.SocioId != socio.SocioId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SocioListDto> GetLista(string ListaDto)
        {
            try
            {
                if (ListaDto == null/*genero == null || estado == null || calificacion == null*/)
                {
                    var listaDto = _DbContext.Socios
                        .Include(d => d.TipoDeDocumento)
                        .Include(l => l.Localidad)
                        .Include(p => p.Provincia)
                        .Select(s => new SocioListDto
                        {
                            SocioId = s.SocioId,
                            Nombre = s.Nombre,
                            Apellido = s.Apellido,
                            TipoDeDocumento = s.TipoDeDocumento.Descripcion,
                            NroDocumento = s.NroDocumento,
                            Direccion = s.Direccion,
                            Localidad = s.Localidad.NombreLocalidad,
                            Provincia = s.Provincia.NombreProvincia,
                            TelefonoFijo = s.TelefonoFijo,
                            TelefonoMovil = s.TelefonoMovil,
                            CorreoElectronico = s.CorreoElectronico,
                            FechaDeNacimiento = s.FechaDeNacimiento,
                            Sancionado = s.Sancionado,
                            Activo = s.Activo

                        }).ToList();
                    return listaDto;

                }
                else
                {
                    var listaDto = _DbContext.Socios
                        .Include(d => d.TipoDeDocumento).Where(d => d.TipoDeDocumento.Descripcion == ListaDto)
                        .Include(l => l.Localidad).Where(l => l.Localidad.NombreLocalidad == ListaDto)
                        .Include(p => p.Provincia).Where(p => p.Provincia.NombreProvincia == ListaDto)
                        .Select(s => new SocioListDto
                        {
                            SocioId = s.SocioId,
                            Nombre = s.Nombre,
                            Apellido = s.Apellido,
                            TipoDeDocumento = s.TipoDeDocumento.Descripcion,
                            NroDocumento = s.NroDocumento,
                            Direccion = s.Direccion,
                            Localidad = s.Localidad.NombreLocalidad,
                            Provincia = s.Provincia.NombreProvincia,
                            TelefonoFijo = s.TelefonoFijo,
                            TelefonoMovil = s.TelefonoMovil,
                            CorreoElectronico = s.CorreoElectronico,
                            FechaDeNacimiento = s.FechaDeNacimiento,
                            Sancionado = s.Sancionado,
                            Activo = s.Activo

                        }).ToList();
                    return listaDto;
                }

            }
            catch (Exception)
            {
                throw new Exception("Error al cargar Socios");


            }

        }

        public SocioEditDto GetSocioPorId(int? id)
        {
            try
            {
                return _mapper.Map<SocioEditDto>(_DbContext.Socios.SingleOrDefault(s => s.SocioId == id));

            }
            catch (Exception)
            {
                throw new Exception("Error al cargar socios");
            }
        }

        public void Guardar(Socio socio)
        {
            try
            {
                if (socio.SocioId == 0)
                {
                    _DbContext.Socios.Add(socio);
                }
                else
                {
                    var socioInDb = _DbContext.Socios.SingleOrDefault(s => s.SocioId == socio.SocioId);
                    socioInDb.SocioId = socio.SocioId;
                    socioInDb.Nombre = socio.Nombre;
                    socioInDb.Apellido = socio.Apellido;
                    socioInDb.TipoDeDocumentoId = socio.TipoDeDocumentoId;
                    socioInDb.NroDocumento = socio.NroDocumento;
                    socioInDb.Direccion = socio.Direccion;
                    socioInDb.LocalidadId = socio.LocalidadId;
                    socioInDb.ProvinciaId = socio.ProvinciaId;
                    socioInDb.TelefonoFijo = socio.TelefonoFijo;
                    socioInDb.TelefonoMovil = socio.TelefonoMovil;
                    socioInDb.CorreoElectronico = socio.CorreoElectronico;
                    socioInDb.FechaDeNacimiento = socio.FechaDeNacimiento;
                    socioInDb.Sancionado = socio.Sancionado;
                    socioInDb.Activo = socio.Activo;

                    _DbContext.Entry(socioInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {

                throw new Exception("Error inesperado al guardar socio");
            }
        }
    }
}
