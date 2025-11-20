using Microsoft.AspNetCore.SignalR.Protocol;

namespace Parcial2DDA.Models
{
    public class Registros
    {
        public int Id { get; set; }
        public string? Huella { get; set; }
        public decimal Peso { get; set; }
        public string? Tipo { get; set; }
        public DateTime Duracion { get; set; } = DateTime.Now;
    }
}
