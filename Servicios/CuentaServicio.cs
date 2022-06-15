using BackEndBancoPichincha.DTO.Cuenta;
using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.Servicios
{
    public class CuentaServicio
    {
        public List<CuentaClienteResponse> obtenerCuentas(ApiDbContext db)
        {
            List<CuentaClienteResponse> res = new List<CuentaClienteResponse>();
            foreach (Cuenta item in db.Cuentas.ToList())
            {
                res.Add(obtenerCuenta(item, db));
            }
            return res;
        }

        public object obtenerCuentaId(int id, ApiDbContext db)
        {
            Cuenta cuenta = db.Cuentas.Find(id);
            Console.WriteLine(id);
            if (cuenta != null)            {
                Cliente cl = db.Clientes.Find(cuenta.ClienteId);
                Console.WriteLine(cl.Id);
                CuentaClienteResponse res = new CuentaClienteResponse(cuenta.NumeroCuenta, db.TiposCuentas.Find(cuenta.TipoCuentaId).Tipo, cuenta.SaldoInicial, cuenta.Estado, db.Personas.Find(cl.Personaid).Nombre);
                return res;
            }
            else
            {
                CuentaResponse res = new CuentaResponse();
                res.response.Add("Error", "Cuenta no encontrada");
                return res;
            }
        }
        public CuentaClienteResponse obtenerCuenta(Cuenta cuenta, ApiDbContext db)
        {
            Cliente cl = db.Clientes.Find(cuenta.ClienteId);
            CuentaClienteResponse res = new CuentaClienteResponse(cuenta.NumeroCuenta, db.TiposCuentas.Find(cuenta.TipoCuentaId).Tipo, cuenta.SaldoInicial, cuenta.Estado, db.Personas.Find(cl.Personaid).Nombre);
            return res;
        }

        public List<CuentaClienteResponse> obtenerCuentasCliente(int id, ApiDbContext db)
        {
            List<CuentaClienteResponse> res = new List<CuentaClienteResponse>();
            try
            {
                 foreach (var cuenta in db.Cuentas.Where(c => c.ClienteId == id).Select((c) => new { numero = c.NumeroCuenta }).ToList())
            {
                    Cuenta aux = db.Cuentas.First(x => x.NumeroCuenta == cuenta.numero);
                    if (aux != null)
                    {
                        res.Add(obtenerCuenta(aux,db));
                    }
            }
                return res;
            }
            catch (Exception)
            {
                return res;
            }
            
        }
        public CuentaResponse  nuevaCuenta(CuentaRequest nuevaCuenta, ApiDbContext db)
        {
            CuentaResponse res = new CuentaResponse();
            try
            {
                Cuenta cuentaAux = new Cuenta();
                cuentaAux.NumeroCuenta = nuevaCuenta.NumeroCuenta;
                cuentaAux.SaldoInicial = nuevaCuenta.SaldoInicial;
                cuentaAux.Estado = nuevaCuenta.Estado;
                cuentaAux.ClienteId = nuevaCuenta.ClienteId;
                cuentaAux.TipoCuentaId = nuevaCuenta.TipoCuenta.Id;
                cuentaAux.Cliente = db.Clientes.Find(cuentaAux.ClienteId);
                cuentaAux.TipoCuenta = nuevaCuenta.TipoCuenta;
                db.Cuentas.Add(cuentaAux);
                db.SaveChanges();
                res.response.Add("Estado", "Cuenta creada exitosamente.");
                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }

        public CuentaResponse editarCuenta(CuentaRequest nuevaCuenta, ApiDbContext db)
        {
            CuentaResponse res = new CuentaResponse();
            try
            {
                Cuenta cuentaAux = db.Cuentas.Find(nuevaCuenta.NumeroCuenta);
                if (cuentaAux != null)
                {
                    cuentaAux.NumeroCuenta = nuevaCuenta.NumeroCuenta;
                    cuentaAux.SaldoInicial = nuevaCuenta.SaldoInicial;
                    cuentaAux.Estado = nuevaCuenta.Estado;
                    cuentaAux.ClienteId = nuevaCuenta.ClienteId;
                    cuentaAux.TipoCuentaId = nuevaCuenta.TipoCuenta.Id;
                    db.SaveChanges();
                    res.response.Add("Estado", "Cuenta editada exitosamente.");
                }
                else
                {

                    res.response.Add("Error", "Cuenta no encontrado");
                }

                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }

        public CuentaResponse eliminarCuenta(int id, ApiDbContext db)
        {
            CuentaResponse res = new CuentaResponse();
            try
            {

                Cuenta cuentaAux = db.Cuentas.Find(id);

                if (cuentaAux != null)
                {
                    
                    if (eliminarMovimientos(cuentaAux.NumeroCuenta,db)) {
                        db.Cuentas.Remove(cuentaAux);
                        db.SaveChanges();
                        res.response.Add("Estado", "Cuenta eliminada exitosamente.");
                    }
                    else { res.response.Add("Error", "Error al elminar Cuenta"); }
                    
                }
                else
                {

                    res.response.Add("Error", "Cuenta no encontrado");
                }

                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
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
