using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionPedidosAPI.Data.Configurations
{
    public class LineaPedidoConfiguration : IEntityTypeConfiguration<LineaPedido>
    {
        public void Configure(EntityTypeBuilder<LineaPedido> builder)
        {
            builder.HasKey(lp => lp.ID);

            builder
                .HasOne(lp => lp.Pedido)
                .WithMany(p => p.LineasPedido)
                .HasForeignKey(lp => lp.IDPedido)
                .IsRequired();

            builder
                .HasOne(lp => lp.Encargado)
                .WithMany(e => e.TrabajosAsignados)
                .HasForeignKey(lp => lp.IDEncargado)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(lp => lp.Articulo)
                .WithMany()
                .HasForeignKey(lp => lp.IDArticulo)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(lp => lp.CreadoPor)
                .WithMany()
                .HasForeignKey(lp => lp.CreadoPorID)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(lp => lp.ModificadoPor)
                .WithMany()
                .HasForeignKey(lp => lp.ModificadoPorID)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
