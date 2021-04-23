namespace SistemaDeVideoClub.Entidades.DTOs.Estado
{
    public class EstadoListDto: System.ICloneable
    {
        public int EstadoId { get; set; }
        public string Descripcion { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
