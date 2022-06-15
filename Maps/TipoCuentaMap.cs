using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class ParametrosMap
    {
        public ParametrosMap(EntityTypeBuilder<Parametros> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("parametros");
            entityBuilder.Property(x => x.Id).HasColumnName("parametroid");
            entityBuilder.Property(x => x.Descripcion).HasColumnName("descripcion");
            entityBuilder.Property(x => x.Valor).HasColumnName("valor");
        }
    }
}