using BackEndBancoPichincha.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEndBancoPichincha.Maps
{
    public class PersonaMap
    {
        public PersonaMap(EntityTypeBuilder<Persona> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("persona");
            entityBuilder.Property(x => x.Id).HasColumnName("personaid");
            entityBuilder.Property(x => x.Nombre).HasColumnName("nombre");
            entityBuilder.Property(x => x.Genero).HasColumnName("genero");
            entityBuilder.Property(x => x.Edad).HasColumnName("edad");
            entityBuilder.Property(x => x.Identificacion).HasColumnName("identificacion");
            entityBuilder.Property(x => x.Direccion).HasColumnName("direccion");
            entityBuilder.Property(x => x.Telefono).HasColumnName("telefono");
        }
    }
}