using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class ClienteMap
    {
        public ClienteMap(EntityTypeBuilder<Cliente> entityBuilder) {
            entityBuilder.HasKey(x=>x.Id);
            entityBuilder.ToTable("cliente");
            entityBuilder.Property(x => x.Id).HasColumnName("clienteid");
            entityBuilder.Property(x => x.Contra).HasColumnName("contra");
            entityBuilder.Property(x => x.Estado).HasColumnName("estado");
            entityBuilder.Property(x => x.Personaid).HasColumnName("personaid");
            entityBuilder.HasOne(x => x.Persona).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}