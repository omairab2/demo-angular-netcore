namespace ConcentradorBackend.Dtos.Request
{
    public class ProspectoRequest
    {
        public int ProspectoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string NumeroCelular { get; set; }
        public int DepartamentoId { get; set; }
        public string FechaRegistro { get; set; }
        public bool Activo { get; set; }
    }
}