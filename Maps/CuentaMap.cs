using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class CuentaMap
    {
        public CuentaMap(EntityTypeBuilder<Cuenta> entityBuilder) {
            entityBuilder.HasKey(x=>x.NumeroCuenta);
            entityBuilder.ToTable("cuenta");
            entityBuilder.Property(x => x.NumeroCuenta).HasColumnName("numerocuenta");
            entityBuilder.Property(x => x.SaldoInicial).HasColumnName("saldoinicial");
            entityBuilder.Property(x => x.Estado).HasColumnName("estado");
            entityBuilder.Property(x => x.TipoCuentaId).HasColumnName("tipocuentaid");
            entityBuilder.Property(x => x.ClienteId).HasColumnName("clienteid");
            entityBuilder.HasOne(x => x.Cliente).WithMany().HasForeignKey(p=>p.ClienteId);
            entityBuilder.HasOne(x => x.TipoCuenta).WithOne().HasForeignKey<TipoCuenta>(x => x.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}