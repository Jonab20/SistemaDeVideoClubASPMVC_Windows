using SistemaDeVideoClub.Entidades.DTOs;
using SistemaDeVideoClub.Entidades.DTOs.Socio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class Carrito
    {
        public List<ItemCarrito> listaPeliculaAlquiler { get; set; } = new List<ItemCarrito>();
        public List<ItemCarrito> listaSocio { get; set; } = new List<ItemCarrito>();

        public SocioListDto socio;
        public List<ItemCarrito> GetItems()
        {
            return listaPeliculaAlquiler;
        }
        public void AgregarAlquiler(Pelicula pelicula,decimal PrecioAlquiler)
        {
            var item = listaPeliculaAlquiler.SingleOrDefault(li => li.pelicula.PeliculaId == pelicula.PeliculaId);
            if (item == null)
            {
                listaPeliculaAlquiler.Add(new ItemCarrito
                {
                    pelicula = pelicula,
                    PrecioAlquiler = PrecioAlquiler,
                    //Socio =socio
                    //FechaAlquiler = DateTime.Now
                }) ;
            }
            else
            {
                item.PrecioAlquiler++;
                //peli.FechaAlquiler.AddDays(7);
            }
        }
        public void EliminarDelCarrito(Pelicula pelicula)
        {
            listaPeliculaAlquiler.RemoveAll(li => li.pelicula.PeliculaId == pelicula.PeliculaId );
        }

        //public void SetSocio(SocioEditDto sociodto)
        //{
        //    socio = sociodto;
        //}

        public void VaciarCarrito()
        {
            listaPeliculaAlquiler.Clear();
        }
        public decimal TotalCarrito()
        {
            return listaPeliculaAlquiler.Count();
        }
    }
}
