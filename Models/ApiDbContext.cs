using BackEndBancoPichincha.Maps;
using Microsoft.EntityFrameworkCore;
using System;

namespace BackEndBancoPichincha.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoMovimiento> TiposMovimientos { get; set; }
        public DbSet<TipoCuenta> TiposCuentas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }

        public DbSet<Parametros> Parametros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            new PersonaMap(modelBuilder.Entity<Persona>());
            new ClienteMap(modelBuilder.Entity<Cliente>());
            new TipoMovimientoMap(modelBuilder.Entity<TipoMovimiento>());
            new TipoCuentaMap(modelBuilder.Entity<TipoCuenta>());
            new CuentaMap(modelBuilder.Entity<Cuenta>());
            new MovimientoMap(modelBuilder.Entity<Movimiento>());
            new ParametrosMap(modelBuilder.Entity<Parametros>());
        }

    }
    }