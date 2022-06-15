using BackEndBancoPichincha.DTO.Cuenta;
using BackEndBancoPichincha.Models;
using BackEndBancoPichincha.Servicios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentaController : ControllerBase
    {
            private ApiDbContext _context;
            public CuentaController(ApiDbContext context)
            {
                _context = context;
            }
            [HttpGet]
            [Route("all")]
            public List<CuentaClienteResponse> obtenerCuentas()
            {
                CuentaServicio servicio = new CuentaServicio();
                return servicio.obtenerCuentas( _context);
            }


            [HttpGet]
        [Route("{numeroCuenta}")]
        public object obtenerCuenta(int numeroCuenta)
            {
                CuentaServicio servicio = new CuentaServicio();
                return servicio.obtenerCuentaId(numeroCuenta, _context);
            }

            [HttpGet]
            [Route("cliente")]
            public List<CuentaClienteResponse> obtenerCuentasCliente(int idCliente)
            {
                CuentaServicio servicio = new CuentaServicio();
                return servicio.obtenerCuentasCliente(idCliente, _context);
            }            

            [HttpPost]
            public CuentaResponse nuevaCuenta([FromBody] CuentaRequest nuevaCuenta)
            {
                CuentaServicio servicio = new CuentaServicio();
                return servicio.nuevaCuenta(nuevaCuenta, _context);
            }

            [HttpPut]
            public CuentaResponse editarCliente([FromBody] CuentaRequest cuenta)
            {
                CuentaServicio servicio = new CuentaServicio();
                return servicio.editarCuenta(cuenta, _context);
            }

            [HttpDelete]
        [Route("{numeroCuenta}")]
        public CuentaResponse eliminarCliente(int numeroCuenta)
            {
                CuentaServicio servicio = new CuentaServicio();
                return servicio.eliminarCuenta(numeroCuenta, _context);
            }

        
    }
}
