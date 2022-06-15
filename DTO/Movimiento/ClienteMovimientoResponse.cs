using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Movimiento
{
    public class ClienteMovimientoResponse
    {
        public ClienteMovimientoResponse(int cuenta, string tipo, double saldoI, bool estado, double movimiento, double saldoD)
        {
            this.NumeroCuenta = cuenta;
            this.Tipo = tipo;
            this.SaldoInicial = saldoI;
            this.Estado = estado;
            this.Movimiento = movimiento;
            this.SaldoDisponible = saldoD;
        }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public double Movimiento { get; set; }
        public double SaldoDisponible { get; set; }
    }
}

