using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Cuenta
{
    public class CuentaClienteResponse
    {
        public CuentaClienteResponse(int numeroCuenta, string tipo, double saldoInicial, bool estado,string cliente)
        {
            this.NumeroCuenta = numeroCuenta;
            this.Tipo = tipo;
            this.SaldoInicial = saldoInicial;
            this.Cliente = cliente;
            this.Estado = estado;
        }


    public int NumeroCuenta { get; set; }
    public string Tipo { get; set; }
    public double SaldoInicial { get; set; }
    public bool Estado { get; set; }
    public string Cliente { get; set; }
}
}
