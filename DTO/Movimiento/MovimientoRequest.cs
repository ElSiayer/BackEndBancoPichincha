using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Movimiento
{
    public class MovimientoRequest
    {
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public int NumeroCuenta { get; set; }

        public int TipoMovimientoId { get; set; }
        
    }
}