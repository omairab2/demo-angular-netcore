using Microsoft.EntityFrameworkCore;

namespace ConcentradorBackend.Models
{
    public partial class ConcentradorDBContext: DbContext
    {
        public ConcentradorDBContext()
        {
        }

        public ConcentradorDBContext(DbContextOptions<ConcentradorDBContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Opcion> Opcion { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<ConsultaEntidadProducto> ConsultaEntidadProducto { get; set; }
        public virtual DbSet<DetalleDeposito> DetalleDeposito { get; set; }

    }
}