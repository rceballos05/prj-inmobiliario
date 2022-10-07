namespace PjInmobiliaria.Application.Dto_s.Response
{
    public class ClienteDtoResponse
    {
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Region { get; set; }
        public int? Fono { get; set; }
        public string? Rut { get; set; }
        public int Estado { get; set; }
        public string? EstadoCliente { get; set; }
    }
}
