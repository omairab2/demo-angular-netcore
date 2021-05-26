using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConcentradorBackend.Models
{
    [Table("vw_detalle_deposito")]
    public partial class DetalleDeposito
    {
         [Key]

        public int ProductoFinancieroID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int TipoMonedaId { get; set; }
        public decimal PorcentajeTea { get; set; }
        public int? PlazoMinimoDia { get; set; }
        public int? PlazoMaximoDia { get; set; }
        public string observacion { get; set; }
        public string moneda { get; set; }
        public string producto { get; set; }
        public decimal? MontoMinimoDeposito { get; set; }
        public decimal? MontoMaximoDeposito { get; set; }
        public decimal? MontoMinimoPrestamo { get; set; }
    }
}
