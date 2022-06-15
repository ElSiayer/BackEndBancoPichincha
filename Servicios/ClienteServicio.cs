using BackEndBancoPichincha.DTO.Cliente;
using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEndBancoPichincha.Servicios
{
    public class ClienteService
    {
        public object obtenerClienteId(int id, ApiDbContext db)
        {
            
            Cliente cliente = db.Clientes.Find(id);
            if (cliente != null) {
                cliente.Persona = db.Personas.Find(cliente.Personaid);
                PersonaClienteResponse res = new PersonaClienteResponse(cliente.Personaid, cliente.Persona.Nombre, cliente.Persona.Identificacion, cliente.Persona.Edad, cliente.Persona.Direccion, cliente.Persona.Telefono, cliente.Estado);
                return res;
            }else {
                ClienteResponse res = new ClienteResponse();
                res.response.Add("Error", "Cliente no encontrado");
                return res;
            }
        }
        public PersonaClienteResponse obtenerCliente(Cliente cliente, ApiDbContext db)
        {

                cliente.Persona = db.Personas.Find(cliente.Personaid);
                PersonaClienteResponse res = new PersonaClienteResponse(cliente.Personaid, cliente.Persona.Nombre, cliente.Persona.Identificacion, cliente.Persona.Edad, cliente.Persona.Direccion, cliente.Persona.Telefono, cliente.Estado);
                return res;
        }
        public List<PersonaClienteResponse> obtenerClientes(ApiDbContext db) {
            List<PersonaClienteResponse> res = new List<PersonaClienteResponse>();
            foreach (Cliente item in db.Clientes.ToList())
            {
                res.Add(obtenerCliente(item,db));
            }
            return res;
        }
        public ClienteResponse nuevoCliente(PersonaClienteRequest nuevo, ApiDbContext db) {
            ClienteResponse res = new ClienteResponse();
            try
            {
                Cliente cliente = new Cliente();
                Persona persona = new Persona();
                cliente.Contra = nuevo.Cliente.Contra;
                cliente.Estado = nuevo.Cliente.Estado;

                persona.Nombre = nuevo.Persona.Nombre;
                persona.Genero = nuevo.Persona.Genero;
                persona.Edad = nuevo.Persona.Edad;
                persona.Identificacion = nuevo.Persona.Identificacion;
                persona.Direccion = nuevo.Persona.Direccion;
                persona.Telefono = nuevo.Persona.Telefono;

                db.Personas.Add(persona);
                db.SaveChanges();
                cliente.Personaid = (int)persona.Id;
                db.Clientes.Add(cliente);
                db.SaveChanges();

                res.response.Add("Estado","ok");
                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }
            
        }

        public ClienteResponse actualizaCliente(PersonaClienteRequest nuevo, ApiDbContext db)
        {
            ClienteResponse res = new ClienteResponse();
            try
            {
                Persona persona = new Persona();      

                persona.Id = nuevo.Persona.Id;
                persona.Nombre = nuevo.Persona.Nombre;
                persona.Genero = nuevo.Persona.Genero;
                persona.Edad = nuevo.Persona.Edad;
                persona.Identificacion = nuevo.Persona.Identificacion;
                persona.Direccion = nuevo.Persona.Direccion;
                persona.Telefono = nuevo.Persona.Telefono;


                Cliente original = db.Clientes.Find(nuevo.Cliente.Id);

                if (original != null)
                {
                    original.Persona = persona;
                    original.Contra = nuevo.Cliente.Contra;
                    original.Estado = nuevo.Cliente.Estado;
                    original.Personaid = (int)persona.Id;
                    db.SaveChanges();
                    res.response.Add("Estado", "ok");
                }
                else
                {

                    res.response.Add("Error", "Cliente no encontrado");
                }

                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }

        public ClienteResponse eliminarCliente(int id, ApiDbContext db)
        {
            ClienteResponse res = new ClienteResponse();
            try
            {
                
                Cliente original = db.Clientes.Find(id);

                if (original != null)
                {
                    int idPersona = original.Personaid;
                    if (eliminarCuentas((int)original.Id,db)) {
                        db.Clientes.Remove(original);
                        if (eliminarPersona(idPersona, db))
                        {
                            res.response.Add("Estado", "ok");
                        }
                        else
                        {
                            res.response.Add("Error", "Error al elminar cliente");
                        }
                    }
                   
                }
                else
                {

                    res.response.Add("Error", "Cliente no encontrado");
                }
                    
                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }
        public bool eliminarPersona(int id, ApiDbContext db)
        {
            try
            {

                Persona original = db.Personas.Find(id);

                if (original != null)
                {
                    db.Personas.Remove(original);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }

        }
        public bool eliminarCuentas(int id, ApiDbContext db)
        {
            try
            {
                List<Cuenta> cuentasEliminar = new List<Cuenta>();
                    foreach (var cuenta in db.Cuentas.Where(c => c.ClienteId == id).Select((c) => new { numero = c.NumeroCuenta }).ToList())
                    {
                        Cuenta aux = db.Cuentas.FirstOrDefault(x => x.NumeroCuenta == cuenta.numero);
                        if (aux != null)
                        {
                            aux.Cliente = db.Clientes.Find(id);
                        if (!eliminarMovimientos(aux.NumeroCuenta,db)) {
                            return false;
                        };
                        cuentasEliminar.Add(aux);
                        }
                    }
                    if (cuentasEliminar.Count>0) {
                    foreach (Cuenta cuenta in cuentasEliminar)
                    {
                        db.Cuentas.Remove(cuenta);

                    }               }
                return true;

            }
            catch
            {
                return false;
            }

        }
        public bool eliminarMovimientos(int id, ApiDbContext db)
        {
            try
            {
                foreach (var movimiento in db.Movimientos.Where(m => m.NumeroCuenta == id).Select((m) => new { id = m.Id }).ToList())
                {
                    Movimiento aux = db.Movimientos.FirstOrDefault(x => x.Id == movimiento.id);
                    if (aux != null)
                    {
                        db.Movimientos.Remove(aux);
                    }
                }
                return true;

            }
            catch
            {
                return false;
            }

        }
    }
}