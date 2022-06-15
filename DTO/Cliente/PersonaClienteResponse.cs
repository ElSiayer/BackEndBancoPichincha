using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Cliente
{
    public class PersonaClienteRequest
    {
        public Persona Persona { get; set; }
        public ClienteRequest Cliente { get; set; }
        
    }
}