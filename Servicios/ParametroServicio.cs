using BackEndBancoPichincha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndBancoPichincha.Servicios
{
    public class ParametroServicio
    {
        public Parametros obtenerLimiteDiario(ApiDbContext db)
        {
            return db.Parametros.Find(1);
        }

        public string ingresarLimiteDiario(string limite,ApiDbContext db)
        {
            try
            {
                Parametros aux = db.Parametros.Find(1);
                aux.Valor = limite; 
                db.SaveChanges();
                return "Valor limite diario cambiado a: " + limite;

            }
            catch
            {
                return "No se pudo cambiar el valor de limite diario";
            }
            
        }
    }
}
