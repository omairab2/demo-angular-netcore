using System.Collections.Generic;
using System.Threading.Tasks;
using ConcentradorBackend.Dtos.Request;
using ConcentradorBackend.Models;

namespace ConcentradorBackend.Interfaces
{
    public interface IConsultaProductoService
    {
        List<ConsultaEntidadProducto> consulta(ConsultaProductoFinancieroRequest request, int pagina);
        List<DetalleDeposito> detalleDeposito(int id);
        Dtos.Response.ResponseGeneric create(Prospecto request);
    }
}