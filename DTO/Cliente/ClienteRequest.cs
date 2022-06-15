using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Cliente
{
    public class ClienteRequest
    {
        public int? Id { get; set; }
        public string Contra { get; set; }
        public bool Estado { get; set; }
    }
}