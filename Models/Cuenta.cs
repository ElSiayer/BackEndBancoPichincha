using System;
using System.Collections.Generic;

namespace BackEndBancoPichincha.Models
{
    public class Cuenta
    {

        public int NumeroCuenta { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }        

        public int TipoCuentaId { get; set; }
        public int ClienteId { get; set; }

        public TipoCuenta TipoCuenta { get; set; }
        public Cliente Cliente { get; set; }
    }
}