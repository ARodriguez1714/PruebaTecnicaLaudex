using Datos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Tarea
    {
        public static Modelo.Result GetAllLINQ()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from tarea in context.Tareas
                                 join estado in context.Estados
                                 on tarea.IdEstado equals estado.IdEstado
                                 join prioridad in context.Prioridads
                                 on tarea.IdPrioridad equals prioridad.IdPrioridad
                                 join categoria in context.Categoria
                                 on tarea.IdCategoria equals categoria.IdCategoria
                                 select new
                                 {
                                     IdTarea = tarea.IdTarea,
                                     Titulo = tarea.Titulo,
                                     Descripcion = tarea.Descripcion,
                                     FechaVencimiento = tarea.FechaVencimiento,
                                     IdEstado = tarea.IdEstado,
                                     NombreEstado = estado.Nombre,
                                     IdCategoria = tarea.IdCategoria,
                                     NombreCategoria = categoria.Nombre,
                                     IdPrioridad = tarea.IdPrioridad,
                                     NombrePrioridad = prioridad.Nombre
                                 }).OrderByDescending(t => t.FechaVencimiento).ThenByDescending(t => t.IdPrioridad).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Tarea tarea = new Modelo.Tarea();
                            tarea.IdTarea = item.IdTarea;
                            tarea.Titulo = item.Titulo;
                            tarea.Descripcion = item.Descripcion;
                            tarea.FechaVencimiento = item.FechaVencimiento.ToString();
                            tarea.Estado = new Modelo.Estado();
                            tarea.Estado.IdEstado = item.IdEstado.Value;
                            tarea.Estado.Nombre = item.NombreEstado;
                            tarea.Categoria = new Modelo.Categoria();
                            tarea.Categoria.IdCategoria = item.IdCategoria.Value;
                            tarea.Categoria.Nombre = item.NombreCategoria;
                            tarea.Prioridad = new Modelo.Prioridad();
                            tarea.Prioridad.IdPrioridad = item.IdPrioridad.Value;
                            tarea.Prioridad.Nombre = item.NombrePrioridad;
                            result.Objects.Add(tarea);
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
        public static Modelo.Result AddLINQ(Modelo.Tarea tarea)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query =
                        context.Database.ExecuteSqlRaw($"AddTarea '{tarea.Titulo}', '{tarea.Descripcion}', '{tarea.FechaVencimiento}', '{1}', '{tarea.Categoria.IdCategoria}', '{tarea.Prioridad.IdPrioridad}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "La tarea se agrego correctamente";
                    }
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
        public static Modelo.Result UpdateLINQ(Modelo.Tarea tarea)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query =
                        context.Database.ExecuteSqlRaw($"UpdateTarea '{tarea.IdTarea}', '{tarea.Titulo}', '{tarea.Descripcion}', '{tarea.FechaVencimiento}', '{tarea.Estado.IdEstado}', '{tarea.Categoria.IdCategoria}', '{tarea.Prioridad.IdPrioridad}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "La tarea se actualizó correctamente";
                    }
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
        public static Modelo.Result DeleteLINQ(byte idTarea)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query =
                        context.Database.ExecuteSqlRaw($"DeleteTarea '{idTarea}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "La tarea se eliminó correctamente";
                    }
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
        public static Modelo.Result GetByIdLINQ(byte idTarea)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from tarea in context.Tareas
                                 join estado in context.Estados
                                 on tarea.IdEstado equals estado.IdEstado
                                 join prioridad in context.Prioridads
                                 on tarea.IdPrioridad equals prioridad.IdPrioridad
                                 join categoria in context.Categoria
                                 on tarea.IdCategoria equals categoria.IdCategoria
                                 where tarea.IdTarea == idTarea
                                 select new
                                 {
                                     IdTarea = tarea.IdTarea,
                                     Titulo = tarea.Titulo,
                                     Descripcion = tarea.Descripcion,
                                     FechaVencimiento = tarea.FechaVencimiento,
                                     IdEstado = tarea.IdEstado,
                                     NombreEstado = estado.Nombre,
                                     IdCategoria = tarea.IdCategoria,
                                     NombreCategoria = categoria.Nombre,
                                     IdPrioridad = tarea.IdPrioridad,
                                     NombrePrioridad = prioridad.Nombre
                                 }).FirstOrDefault();

                    if (query != null)
                    {
                        Modelo.Tarea tarea = new Modelo.Tarea();
                        var item = query;

                        tarea.IdTarea = item.IdTarea;
                        tarea.Titulo = item.Titulo;
                        tarea.Descripcion = item.Descripcion;
                        tarea.FechaVencimiento = item.FechaVencimiento.ToString();
                        tarea.Estado = new Modelo.Estado();
                        tarea.Estado.IdEstado = item.IdEstado.Value;
                        tarea.Estado.Nombre = item.NombreEstado;
                        tarea.Categoria = new Modelo.Categoria();
                        tarea.Categoria.IdCategoria = item.IdCategoria.Value;
                        tarea.Categoria.Nombre = item.NombreCategoria;
                        tarea.Prioridad = new Modelo.Prioridad();
                        tarea.Prioridad.IdPrioridad = item.IdPrioridad.Value;
                        tarea.Prioridad.Nombre = item.NombrePrioridad;

                        result.Object = tarea;

                        result.Correct = true;
                    }
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
        public static Modelo.Result GetAllPersonal()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from tarea in context.Tareas
                                 join estado in context.Estados
                                 on tarea.IdEstado equals estado.IdEstado
                                 join prioridad in context.Prioridads
                                 on tarea.IdPrioridad equals prioridad.IdPrioridad
                                 join categoria in context.Categoria
                                 on tarea.IdCategoria equals categoria.IdCategoria
                                 where tarea.IdCategoria == 1
                                 select new
                                 {
                                     IdTarea = tarea.IdTarea,
                                     Titulo = tarea.Titulo,
                                     Descripcion = tarea.Descripcion,
                                     FechaVencimiento = tarea.FechaVencimiento,
                                     IdEstado = tarea.IdEstado,
                                     NombreEstado = estado.Nombre,
                                     IdCategoria = tarea.IdCategoria,
                                     NombreCategoria = categoria.Nombre,
                                     IdPrioridad = tarea.IdPrioridad,
                                     NombrePrioridad = prioridad.Nombre
                                 }).OrderByDescending(t => t.FechaVencimiento).ThenByDescending(t => t.IdPrioridad).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Tarea tarea = new Modelo.Tarea();
                            tarea.IdTarea = item.IdTarea;
                            tarea.Titulo = item.Titulo;
                            tarea.Descripcion = item.Descripcion;
                            tarea.FechaVencimiento = item.FechaVencimiento.ToString();
                            tarea.Estado = new Modelo.Estado();
                            tarea.Estado.IdEstado = item.IdEstado.Value;
                            tarea.Estado.Nombre = item.NombreEstado;
                            tarea.Categoria = new Modelo.Categoria();
                            tarea.Categoria.IdCategoria = item.IdCategoria.Value;
                            tarea.Categoria.Nombre = item.NombreCategoria;
                            tarea.Prioridad = new Modelo.Prioridad();
                            tarea.Prioridad.IdPrioridad = item.IdPrioridad.Value;
                            tarea.Prioridad.Nombre = item.NombrePrioridad;
                            result.Objects.Add(tarea);
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
        public static Modelo.Result GetAllProfesional()
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = (from tarea in context.Tareas
                                 join estado in context.Estados
                                 on tarea.IdEstado equals estado.IdEstado
                                 join prioridad in context.Prioridads
                                 on tarea.IdPrioridad equals prioridad.IdPrioridad
                                 join categoria in context.Categoria
                                 on tarea.IdCategoria equals categoria.IdCategoria
                                 where tarea.IdCategoria == 2
                                 select new
                                 {
                                     IdTarea = tarea.IdTarea,
                                     Titulo = tarea.Titulo,
                                     Descripcion = tarea.Descripcion,
                                     FechaVencimiento = tarea.FechaVencimiento,
                                     IdEstado = tarea.IdEstado,
                                     NombreEstado = estado.Nombre,
                                     IdCategoria = tarea.IdCategoria,
                                     NombreCategoria = categoria.Nombre,
                                     IdPrioridad = tarea.IdPrioridad,
                                     NombrePrioridad = prioridad.Nombre
                                 }).OrderByDescending(t => t.FechaVencimiento).ThenByDescending(t => t.IdPrioridad).ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Tarea tarea = new Modelo.Tarea();
                            tarea.IdTarea = item.IdTarea;
                            tarea.Titulo = item.Titulo;
                            tarea.Descripcion = item.Descripcion;
                            tarea.FechaVencimiento = item.FechaVencimiento.ToString();
                            tarea.Estado = new Modelo.Estado();
                            tarea.Estado.IdEstado = item.IdEstado.Value;
                            tarea.Estado.Nombre = item.NombreEstado;
                            tarea.Categoria = new Modelo.Categoria();
                            tarea.Categoria.IdCategoria = item.IdCategoria.Value;
                            tarea.Categoria.Nombre = item.NombreCategoria;
                            tarea.Prioridad = new Modelo.Prioridad();
                            tarea.Prioridad.IdPrioridad = item.IdPrioridad.Value;
                            tarea.Prioridad.Nombre = item.NombrePrioridad;
                            result.Objects.Add(tarea);
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
        public static Modelo.Result BusquedaAbierta(string palabra)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    var query = context.Tareas.FromSqlRaw($"BusquedaAbierta '{palabra}'").ToList();

                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            Modelo.Tarea tarea = new Modelo.Tarea();
                            tarea.IdTarea = item.IdTarea;
                            tarea.Titulo = item.Titulo;
                            tarea.Descripcion = item.Descripcion;
                            tarea.FechaVencimiento = item.FechaVencimiento.ToString();
                            tarea.Estado = new Modelo.Estado();
                            tarea.Estado.IdEstado = item.IdEstado.Value;
                            tarea.Estado.Nombre = item.NombreEstado;
                            tarea.Categoria = new Modelo.Categoria();
                            tarea.Categoria.IdCategoria = item.IdCategoria.Value;
                            tarea.Categoria.Nombre = item.NombreCategoria;
                            tarea.Prioridad = new Modelo.Prioridad();
                            tarea.Prioridad.IdPrioridad = item.IdPrioridad.Value;
                            tarea.Prioridad.Nombre = item.NombrePrioridad;
                            result.Objects.Add(tarea);
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
        public static Modelo.Result UpdateEstado(byte idEstado, byte idTarea)
        {
            Modelo.Result result = new Modelo.Result();

            try
            {
                using (Datos.PruebaTecnicaLaudexContext context = new PruebaTecnicaLaudexContext())
                {
                    if (idEstado == 1)
                    {
                        idEstado = 2;
                    }
                    else if (idEstado == 2)
                    {
                        idEstado = 1;
                    }
                    var query = context.Database.ExecuteSqlRaw($"EstatusUpdate '{idEstado}', '{idTarea}'");

                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "El estatus se actualizó correctamente";
                    }
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
