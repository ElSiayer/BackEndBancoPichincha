using BackEndBancoPichincha.DTO.Cliente;
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
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private ApiDbContext _context;
        public ClienteController(ApiDbContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public List<PersonaClienteResponse> obtenerTodos()
        {
            ClienteService servicio = new ClienteService();
            return servicio.obtenerClientes(_context);
        }

        [HttpGet]
        public object obtenerCliente(int id)
        {
            ClienteService servicio = new ClienteService();
            return servicio.obtenerClienteId(id, _context);
        }
        

        [HttpPost]
        public ClienteResponse nuevoCliente([FromBody] PersonaClienteRequest nuevo)
        {
            ClienteService servicio = new ClienteService();   

            return servicio.nuevoCliente(nuevo, _context);
        }

        [HttpPut]
        public ClienteResponse actualizaCliente([FromBody] PersonaClienteRequest nuevo)
        {
            ClienteService servicio = new ClienteService();

            return servicio.actualizaCliente(nuevo, _context);
        }

        [HttpDelete]
        [Route("{id}")]
        public ClienteResponse eliminarCliente(int id)
        {
            ClienteService servicio = new ClienteService();
            return servicio.eliminarCliente(id, _context);
        }

    }
}
