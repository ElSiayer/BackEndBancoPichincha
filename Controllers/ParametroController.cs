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
    [Route("api/parametros")]
    public class ParametroController : ControllerBase
    {
        private ApiDbContext _context;
        public ParametroController(ApiDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public string cambiarLimiteDiario(double limite)
        {
            ParametroServicio servicio = new ParametroServicio();
            return servicio.ingresarLimiteDiario(limite.ToString(), _context);
        }
    }
}
