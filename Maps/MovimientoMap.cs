using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class MovimientoMap
    {
        public MovimientoMap(EntityTypeBuilder<Movimiento> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("movimientos");
            entityBuilder.Property(x => x.Id).HasColumnName("movimientoid");
            entityBuilder.Property(x => x.Fecha).HasColumnName("fecha");
            entityBuilder.Property(x => x.Valor).HasColumnName("valor");
            entityBuilder.Property(x => x.Saldo).HasColumnName("saldo");            
            entityBuilder.Property(x => x.NumeroCuenta).HasColumnName("numerocuenta");
            entityBuilder.Property(x => x.TipoMovimientoId).HasColumnName("tipomovimientoid");
        }
    }
}