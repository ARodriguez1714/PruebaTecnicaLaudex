using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Estado
    {
        public static Modelo.Result GetAllLINQ()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from estado in context.Estados
                                 select new
                                 {
                                     Idestado = estado.IdEstado,
                                     NombreEstado = estado.Nombre
                                 }).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Estado estado = new Modelo.Estado();
                            estado.IdEstado = item.Idestado;
                            estado.Nombre = item.NombreEstado;
                            result.Objects.Add(estado);
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
