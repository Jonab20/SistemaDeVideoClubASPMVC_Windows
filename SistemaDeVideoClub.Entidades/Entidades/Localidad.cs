using SistemaDeVideoClub.Entidades.Entidades;

namespace SistemaDeVideoClubASPMVC.Entidades
{
    public class Localidad
    {
        public int LocalidadId { get; set; }
        public string NombreLocalidad { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
    }
}