using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Movimiento
{
    public class MovimientoFiltradoResponse
    {
        public MovimientoFiltradoResponse(DateTime fecha,string cliente,int cuenta, string tipo, double saldoI, bool estado, double movimiento, double saldoD) {
            this.Fecha = fecha.ToString("dd/MM/yyyy");
            this.Cliente = cliente;
            this.NumeroCuenta = cuenta;
            this.Tipo = tipo;
            this.SaldoInicial = saldoI;
            this.Estado = estado;
            this.Movimiento = movimiento;
            this.SaldoDisponible = saldoD;
        }
        public string Fecha { get; set; }
        public string Cliente { get; set; }
        public int NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public double Movimiento { get; set; }
        public double SaldoDisponible { get; set; }
    }
}
