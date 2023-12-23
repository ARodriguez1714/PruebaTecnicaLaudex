using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Categoria
    {
        public static Modelo.Result GetAllLINQ()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from categoria in context.Categoria
                                 select new
                                 {
                                     IdCategoria = categoria.IdCategoria,
                                     NombreCategoria = categoria.Nombre
                                 }).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Categoria categoria = new Modelo.Categoria();
                            categoria.IdCategoria = item.IdCategoria;
                            categoria.Nombre = item.NombreCategoria;
                            result.Objects.Add(categoria);
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
