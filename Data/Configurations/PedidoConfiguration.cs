using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionPedidos.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.ID);

            builder
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.IdCliente)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(p => p.LineasPedido)
                .WithOne(lp => lp.Pedido)
                .HasForeignKey(lp => lp.IDPedido)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(p => p.CreadoPor)
                .WithMany()
                .HasForeignKey(p => p.CreadoPorID)
                .IsRequired();
            
            builder
                .HasOne(p => p.ModificadoPor)
                .WithMany()
                .HasForeignKey(p => p.ModificadoPorID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
