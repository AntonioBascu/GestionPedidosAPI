using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GestionPedidosAPI.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .HasMany(u => u.TrabajosAsignados)
                .WithOne(ta => ta.Encargado)
                .HasForeignKey(ta => ta.IDEncargado)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
