namespace WEBViajes.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public List<Viaje> Viajes { get; set; } = new List<Viaje>();
    }
}
