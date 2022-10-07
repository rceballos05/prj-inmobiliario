namespace PjInmobiliaria.Application.Dto_s.Request
{
    public class ClienteDtoRequest
    {
        public string NombreCliente { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? Region { get; set; }
        public int? CodigoP { get; set; }
        public int? Fono { get; set; }
        public string? Rut { get; set; }
        public int Estado { get; set; }
    }
}
