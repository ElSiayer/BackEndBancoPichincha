using BackEndBancoPichincha.DTO.Cliente;
using BackEndBancoPichincha.DTO.Movimiento;
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
    [Route("api/movimientos")]
    public class MovimientoController : ControllerBase
    {
            private ApiDbContext _context;
            public MovimientoController(ApiDbContext context)
            {
                _context = context;
            }
            [HttpGet]
            [Route("all")]
            public List<ClienteMovimientoResponse> obtenerMovimientos()
            {
                MovimientoServicio servicio = new MovimientoServicio();
                return servicio.movimientos(_context);
            }
            
            [HttpGet]
            [Route("uno")]
            public ClienteMovimientoResponse obtenerMovimiento(int id)
            {
                MovimientoServicio servicio = new MovimientoServicio();
                return servicio.obtenerMovimientoId(id, _context);
            }
            [HttpPost]
            [Route("/reportes")]
            public List<MovimientoFiltradoResponse> obtenerEstadoCuenta([FromBody] ReporteRequest reporte)
            {
                MovimientoServicio servicio = new MovimientoServicio();
                return servicio.obtenerMovimientosClientePorFechas(reporte.IdCliente,reporte.Inicio,reporte.Fin, _context);
            }
            

            [HttpPost]
            public MovimientoResponse nuevoMovimiento([FromBody] MovimientoRequest nuevo)
            {
                MovimientoServicio servicio = new MovimientoServicio();

                return servicio.nuevoMovimiento(nuevo, _context);
            }

            [HttpPut]
            public MovimientoResponse editarMovimientoe([FromBody] Movimiento nuevo)
            {
                MovimientoServicio servicio = new MovimientoServicio();

                return servicio.editarMovimientoe(nuevo, _context);
            }

            [HttpDelete]
            public MovimientoResponse eliminarMovimiento(int id)
            {
                MovimientoServicio servicio = new MovimientoServicio();
                return servicio.eliminarMovimiento(id, _context);
            }
    }
}
