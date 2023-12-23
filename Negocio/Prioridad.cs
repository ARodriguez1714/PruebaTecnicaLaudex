using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Prioridad
    {
        public static Modelo.Result GetAllLINQ()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from prioridad in context.Prioridads
                                 select new
                                 {
                                     IdPrioridad = prioridad.IdPrioridad,
                                     NombrePrioridad = prioridad.Nombre
                                 }).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Prioridad prioridad = new Modelo.Prioridad();
                            prioridad.IdPrioridad = item.IdPrioridad;
                            prioridad.Nombre = item.NombrePrioridad;
                            result.Objects.Add(prioridad);
                        }
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al realizar la consulta. " + result.Ex;
                throw;
            }

            return result;
        }
    }
}
