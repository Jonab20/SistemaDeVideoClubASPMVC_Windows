using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeVideoClub.Entidades.Entidades
{
    public class Carrito
    {
        public List<ItemCarrito> listaPeliculaAlquiler { get; set; } = new List<ItemCarrito>();

        public void AgregarAlquiler(Pelicula pelicula, int cantidad)
        {
            var item = listaPeliculaAlquiler.SingleOrDefault(li => li.pelicula.PeliculaId == pelicula.PeliculaId);
            if (item == null)
            {
                listaPeliculaAlquiler.Add(new ItemCarrito
                {
                    pelicula = pelicula,
                    Cantidad = cantidad
                    //FechaAlquiler = DateTime.Now
                }) ;
            }
            else
            {
                item.Cantidad++;
                //peli.FechaAlquiler.AddDays(7);
            }
        }
        public void EliminarDelCarrito(Pelicula pelicula)
        {
            listaPeliculaAlquiler.RemoveAll(li => li.pelicula.PeliculaId == pelicula.PeliculaId );
        }

        public List<ItemCarrito> GetItems()
        {
            return listaPeliculaAlquiler;
        }

        public void VaciarCarrito()
        {
            listaPeliculaAlquiler.Clear();
        }
        //public decimal TotalCarrito()
        //{
        //    return listaPeliculaAlquiler.Sum(i => i.Cantidad * i.Producto.Precio);
        //}
    }
}
