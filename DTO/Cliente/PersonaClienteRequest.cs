using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.DTO.Cliente
{
    public class PersonaClienteResponse
    {
        public PersonaClienteResponse(int id,string nombre, string identificacion, int edad, string direccion, string telefono, bool estado)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Identificacion = identificacion;
            this.Edad = edad;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Estado = estado;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }        
        public bool Estado { get; set; }
        
    }
}