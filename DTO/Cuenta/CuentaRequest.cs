using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Cuenta
{
    public class CuentaRequest
    {
        public int NumeroCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public int ClienteId { get; set; }
    }
}