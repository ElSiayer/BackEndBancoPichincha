using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class TipoCuentaMap
    {
        public TipoCuentaMap(EntityTypeBuilder<TipoCuenta> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("tipocuenta");
            entityBuilder.Property(x => x.Id).HasColumnName("tipocuentaid");
            entityBuilder.Property(x => x.Tipo).HasColumnName("tipo");
        }
    }
}