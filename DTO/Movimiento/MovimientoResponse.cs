using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Movimiento
{
    public class MovimientoResponse
    {
        public MovimientoResponse()
        {
            this.response = new Dictionary<string, string>();
        }
        public Dictionary<string, string> response { get; set; }
    }
}
