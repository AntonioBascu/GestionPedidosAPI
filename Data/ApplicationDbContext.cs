using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GestionPedidosAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas las configuraciones encontradas en el ensamblado actual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Alternativamente, puedes registrar configuraciones específicas
            // modelBuilder.ApplyConfiguration(new ProductoConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<LineaPedido> LineasPedido { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
    }
}
