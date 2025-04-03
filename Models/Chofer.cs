namespace WEBViajes.Models
{
    public class Chofer
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public List<Viaje> Viajes { get; set; } = new List<Viaje>();


    }
}
