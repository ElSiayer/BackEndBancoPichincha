
using BackEndBancoPichincha.DTO.Movimiento;
using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.Servicios
{
    public class MovimientoServicio
    {
        public List<ClienteMovimientoResponse> movimientos(ApiDbContext db)
        {
            List<ClienteMovimientoResponse> res = new List<ClienteMovimientoResponse>();
            foreach (Movimiento item in db.Movimientos.ToList())
            {
                res.Add(obtenerMovimiento(item, db));
            }
            return res;
        }
        public List<Movimiento> obtenerMovimientosCuenta(int id, ApiDbContext db)
        {
            List<Movimiento> res = new List<Movimiento>();
            try
            {                
                return db.Movimientos.Where(m => m.NumeroCuenta == id).ToList();
            }
            catch (Exception)
            {
                return res;
            }

        }
        public List<MovimientoFiltradoResponse> obtenerMovimientosClientePorFechas(int id,DateTime inicio, DateTime fin , ApiDbContext db)
        {
            List<MovimientoFiltradoResponse> res = new List<MovimientoFiltradoResponse>();
            try
            {
                var query = from m in db.Movimientos
                            join tm in db.TiposMovimientos on m.TipoMovimientoId equals tm.Id
                            join c in db.Cuentas on m.NumeroCuenta equals c.NumeroCuenta
                            join tc in db.TiposCuentas on c.TipoCuentaId equals tc.Id
                            join cl in db.Clientes on c.ClienteId equals cl.Id
                            join p in db.Personas on cl.Personaid equals p.Id
                            where cl.Id == id
                            where inicio <= m.Fecha
                            where m.Fecha <= fin
                            select new MovimientoFiltradoResponse(
                    m.Fecha,p.Nombre,c.NumeroCuenta,tc.Tipo,c.SaldoInicial,c.Estado,tm.Tipo == "Debito"? -1 * (m.Valor) : m.Valor,m.Saldo

                    );
    return query.ToList();
            }
            catch (Exception)
            {
                return res;
            }

        }
        public ClienteMovimientoResponse obtenerMovimientoId(int id, ApiDbContext db)
        {
            Movimiento movimiento = db.Movimientos.Find(id);
            Cuenta cuenta = db.Cuentas.Find(movimiento.NumeroCuenta);
            ClienteMovimientoResponse res = new ClienteMovimientoResponse(movimiento.NumeroCuenta, db.TiposCuentas.Find(cuenta.TipoCuentaId).Tipo, movimiento.Saldo, cuenta.Estado, movimiento.Valor, movimiento.Saldo);
            return res;
        }
        public ClienteMovimientoResponse obtenerMovimiento(Movimiento movimiento, ApiDbContext db)
        {
            Cuenta cuenta = db.Cuentas.Find(movimiento.NumeroCuenta);
            ClienteMovimientoResponse res = new ClienteMovimientoResponse(movimiento.NumeroCuenta, db.TiposCuentas.Find(cuenta.TipoCuentaId).Tipo, movimiento.Saldo, cuenta.Estado, movimiento.Valor, movimiento.Saldo);
            return res;
        }

        public double obtenerMontoMovimientosDiario(int numeroCuenta, int idTipo, ApiDbContext db)
        {
            double res = 0;
            try
            {
                foreach (var valor in db.Movimientos.Where(m => m.NumeroCuenta == numeroCuenta).Where(m => m.TipoMovimientoId == idTipo).Where(m => m.Fecha == DateTime.Now).Select((c) => new { numero = c.Valor }).ToList())
                {
                    if (valor != null)
                    {
                        res = res + valor.numero;
                    }
                }
                return res;
            }
            catch (Exception)
            {
                return res;
            }

        }

        public MovimientoResponse nuevoMovimiento(MovimientoRequest nuevo, ApiDbContext db)
        {
            MovimientoResponse res = new MovimientoResponse();
            double saldo = 0;
            try
            {
                TipoMovimiento tipo = db.TiposMovimientos.Find(nuevo.TipoMovimientoId);
                Cuenta cuenta = db.Cuentas.Find(nuevo.NumeroCuenta);


                Movimiento ultimo = db.Movimientos.OrderByDescending(p => p.Id).Where(p=>p.NumeroCuenta == nuevo.NumeroCuenta).First();
                if (ultimo == null)
                {
                    saldo = cuenta.SaldoInicial;
                }
                else
                {
                    saldo = ultimo.Saldo;
                }
                
                if (tipo.Tipo.Equals("Debito")) {                    
                    if (nuevo.Valor>saldo || saldo == 0) {
                        res.response.Add("Error", "Saldo no disponible");
                        return res;
                    }
                    double saldoUsado = obtenerMontoMovimientosDiario(nuevo.NumeroCuenta, nuevo.TipoMovimientoId, db);
                    ParametroServicio parametros = new ParametroServicio();
                    double limiteDiario = double.Parse(parametros.obtenerLimiteDiario(db).Valor);

                    if ((saldoUsado + nuevo.Valor) > limiteDiario)
                    {
                        res.response.Add("Error", "Cupo diario Excedido");
                        return res;                        
                    }
                }
                Movimiento movimientoAux = new Movimiento();
                movimientoAux.NumeroCuenta = cuenta.NumeroCuenta;
                movimientoAux.Saldo = tipo.Tipo.Equals("Debito") ? saldo - nuevo.Valor : saldo + nuevo.Valor;
               movimientoAux.TipoMovimientoId = tipo.Id;
                movimientoAux.Valor = nuevo.Valor;
                movimientoAux.Fecha = nuevo.Fecha;
                db.Movimientos.Add(movimientoAux);
                db.SaveChanges();
                res.response.Add("Estado", "Movimiento realizado exitosamente.");
                return res;
            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }

        public MovimientoResponse editarMovimientoe(Movimiento movimiento, ApiDbContext db)
        {
            MovimientoResponse res = new MovimientoResponse();
            try
            {
                Persona persona = new Persona();


                Movimiento movimientoAux = db.Movimientos.Find(movimiento.Id);

                if (movimientoAux != null)
                {
                    movimientoAux.NumeroCuenta = movimiento.NumeroCuenta;
                    movimientoAux.Saldo = movimiento.Saldo;
                    movimientoAux.TipoMovimientoId = movimiento.TipoMovimientoId;
                    movimientoAux.Valor = movimiento.Valor;
                    movimientoAux.Fecha = movimiento.Fecha;
                    db.SaveChanges();
                    res.response.Add("Estado", "Movimiento actualizado exitosamente.");
                }
                else
                {
                    res.response.Add("Error", "Movimiento no encontrado");
                }

                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }

        public MovimientoResponse eliminarMovimiento(int id, ApiDbContext db)
        {
            MovimientoResponse res = new MovimientoResponse();
            try
            {

                Movimiento original = db.Movimientos.Find(id);

                if (original != null)
                {
                    db.Movimientos.Remove(original);
                    db.SaveChanges();
                    res.response.Add("Estado", "Movimiento eliminada exitosamente.");
                }
                else
                {

                    res.response.Add("Error", "Movimiento no encontrado");
                }

                return res;

            }
            catch (Exception e)
            {
                res.response.Add("Error", e.Message);
                return res;
            }

        }
    }
}
