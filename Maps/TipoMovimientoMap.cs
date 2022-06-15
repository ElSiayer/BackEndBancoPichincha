using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class TipoMovimientoMap
    {
        public TipoMovimientoMap(EntityTypeBuilder<TipoMovimiento> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.HasIndex(u => u.Id).IsUnique();
            entityBuilder.ToTable("tipomovimiento");
            entityBuilder.Property(x => x.Id).HasColumnName("tipomovimientoid");
            entityBuilder.Property(x => x.Tipo).HasColumnName("tipo");
        }
    }
}