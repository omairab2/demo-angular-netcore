using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ConcentradorBackend.Dtos.Request;
using ConcentradorBackend.Interfaces;
using ConcentradorBackend.Models;
using ConcentradorBackend.Util;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace ConcentradorBackend.DataAccess
{
    public class ConsultaProductoDataAccessLayer : IConsultaProductoService
    {
        private readonly ConcentradorDBContext _dbContext;
     

        public ConsultaProductoDataAccessLayer(ConcentradorDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public static IConfiguration Configuration { get; set; }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration.GetConnectionString("DefaultConnection");

        }

        

        public List<ConsultaEntidadProducto> consulta(ConsultaProductoFinancieroRequest request, int pagina)
        {
            try
            {


                var consulta = from cep in _dbContext.ConsultaEntidadProducto
                               select cep;

                if (!String.IsNullOrEmpty(request.CodigoProductoFinanciero.ToString()))
                {
                    consulta = consulta.Where(s => s.TipoProductoId == request.CodigoProductoFinanciero);
                }

                if (!String.IsNullOrEmpty(request.TipoMonedaId.ToString()))
                {
                    consulta = consulta.Where(s => s.MonedaId == request.TipoMonedaId);
                }

                if (!String.IsNullOrEmpty(request.MontoMaximoAceptable.ToString()))
                {
                    consulta = consulta.Where(s => s.MontoMaximoPrestamo >= request.MontoMaximoAceptable);
                }
                if (!String.IsNullOrEmpty(request.PlazoMaximoMes.ToString()))
                {
                    consulta = consulta.Where(s => s.PlazoMaximoMes >= request.PlazoMaximoMes);
                }
                if (!String.IsNullOrEmpty(request.IngresoPermitido.ToString()))
                {
                    consulta = consulta.Where(s => s.IngresoPermitido >= request.IngresoPermitido);
                }
                if (!String.IsNullOrEmpty(request.DepartamentoId.ToString()))
                {
                    consulta = consulta.Where(s => s.DepartamentoId == request.DepartamentoId);
                }
                if (!String.IsNullOrEmpty(request.TipoInstitucionId.ToString()))
                {
                    consulta = consulta.Where(s => s.TipoInstitucionId == request.TipoInstitucionId);
                }
                if (!String.IsNullOrEmpty(request.MontoMaximoDeposito.ToString()))
                {
                    consulta = consulta.Where(s => s.MontoMaximoDeposito >= request.MontoMaximoDeposito);
                }
                if (!String.IsNullOrEmpty(request.PlazoMaximoDia.ToString()))
                {
                    consulta = consulta.Where(s => s.PlazoMaximoDia >= request.PlazoMaximoDia);
                }

                return (List<ConsultaEntidadProducto>)consulta.AsNoTracking()
                    .OrderBy(x => x.ConsultaEntidadProductoId)
                    .GetPaged(pagina, 20).Results;
            }
            catch
            {
                throw;
            }
        }
        public List<DetalleDeposito> detalleDeposito(int id)
        {
            try
            {

                var consulta = from cep in _dbContext.DetalleDeposito
                               select cep;

                if (!String.IsNullOrEmpty(id.ToString()))
                {
                    consulta = consulta.Where(s => s.ProductoFinancieroID == id);
                }



                return (List<DetalleDeposito>)consulta.AsNoTracking().ToList();

            }
            catch
            {
                throw;
            }
        }
        public Dtos.Response.ResponseGeneric create(Prospecto request)
        {
            var res = new Dtos.Response.ResponseGeneric();
            var conecction = GetConnectionString();
            try
            {
                string connectionString = conecction;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into Prospecto(Nombres, Apellidos, TipoDocumentoId, NumeroDocumento, Email, NumeroCelular,DepartamentoId,FechaRegistro,Activo) Values('{request.Nombres}', '{request.Apellidos}', '{request.TipoDocumentoId}', '{request.NumeroDocumento}', '{request.Email}', '{request.NumeroCelular}','{request.DepartamentoId}','{request.FechaRegistro}', '{request.Activo}')";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }

                    res.codError = 0;
                    res.messagge = "Registro Exitoso"; 
                }

            }
            catch
            {

                res.codError = -1;
                res.messagge = "Ha ocurrido un error";
                throw;

            }
            return res;
        }
    }
    
}