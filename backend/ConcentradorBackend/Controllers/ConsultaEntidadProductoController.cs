using System.Collections.Generic;
using ConcentradorBackend.Dtos.Request;
using ConcentradorBackend.Interfaces;
using ConcentradorBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;



namespace ConcentradorBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConsultaController : Controller
    {
        
        private readonly IConsultaProductoService _consultaProductoService;

        public ConsultaController(IConsultaProductoService consultaProductoService)
        {
            _consultaProductoService = consultaProductoService;
        }
        
        [HttpPost]
        [Route("producto-financiero/pagina/{page}")]
        public List<ConsultaEntidadProducto> Post([FromBody] ConsultaProductoFinancieroRequest request, int page)
        {
            return _consultaProductoService.consulta(request, page);
        }

        [HttpGet]
        [Route("detalleDeposito/{id}")]
        public List<DetalleDeposito> Get(int id)
        {
            return _consultaProductoService.detalleDeposito(id);
        }
        [HttpPost]
        [Route("prospecto")]
        public Dtos.Response.ResponseGeneric Post([FromBody] Prospecto request)
        {
           
            return _consultaProductoService.create(request);
        }


    }
}