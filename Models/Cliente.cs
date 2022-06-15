using System;
using System.Collections.Generic;

namespace BackEndBancoPichincha.Models
{
    public class Cliente
    {

        public int? Id { get; set; }
        public string Contra { get; set; }
        public bool Estado { get; set; }
        public int Personaid { get; set; }
        public Persona Persona { get; set; }
    }
}