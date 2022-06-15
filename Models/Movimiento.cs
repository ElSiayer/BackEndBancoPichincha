using System;

namespace BackEndBancoPichincha.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public double Saldo { get; set; }
        
        public int TipoMovimientoId { get; set; }
        public int NumeroCuenta { get; set; }


    }
}