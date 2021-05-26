using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConcentradorBackend.Dtos.Response
{
    public class DetalleDeposito
    {
        public dynamic Producto { get; set; }
        public dynamic Nombre { get; set; }
        public dynamic Descripcion { get; set; }
        public dynamic TipoMonedaId { get; set; }
        public dynamic PorcentajeTea { get; set; }
        public dynamic PlazoMinimoDia { get; set; }
        public dynamic PlazoMaximoDia { get; set; }
        public dynamic observacion { get; set; }
        public dynamic MontoMinimoDeposito { get; set; }
        public dynamic MontoMaximoDeposito { get; set; }
        public dynamic MontoMinimoPrestamo { get; set; }
    }
}
