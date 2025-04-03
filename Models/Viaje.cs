namespace WEBViajes.Models
{
    public class Viaje
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ClienteId { get; set; } 
        public Cliente Cliente { get; set; } 
        public int ChoferId { get; set; } 
        public Chofer Chofer { get; set; } 
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public string Pasajero { get; set; } = string.Empty;
        public int KM { get; set; }
        public decimal Total { get; set; }
        public bool Pagado { get; set; }
        public string? LinkPago { get; set; }
        public string NumeroFactura { get; set; } = string.Empty;
    }
}