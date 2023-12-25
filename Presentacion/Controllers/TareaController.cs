using Microsoft.AspNetCore.Mvc;
using Modelo;

namespace Presentacion.Controllers
{
    public class TareaController : Controller
    {
        public IActionResult GetAll()
        {
            Modelo.Tarea tarea = new Modelo.Tarea();
            Modelo.Result result = Negocio.Tarea.GetAllLINQ();

            tarea.Estado = new Modelo.Estado();
            Modelo.Result resultEstados = Negocio.Estado.GetAllLINQ();
            tarea.Estado.Estados = resultEstados.Objects;

            tarea.Prioridad = new Modelo.Prioridad();
            Modelo.Result resultPrioridad = Negocio.Prioridad.GetAllLINQ();
            tarea.Prioridad.Prioridades = resultPrioridad.Objects;

            tarea.Categoria = new Modelo.Categoria();
            Modelo.Result resultCategoria = Negocio.Categoria.GetAllLINQ();
            tarea.Categoria.Categorias = resultCategoria.Objects;


            if (result.Correct)
            {
                tarea.Tareas = result.Objects;
                return View(tarea);
            }
            else
            {
                return View(tarea);
            }
        }
        [HttpPost]
        public IActionResult GetAll(string palabra)
        {
            Modelo.Tarea tarea = new Modelo.Tarea();
            palabra = (palabra == null) ? "" : palabra;

            Modelo.Result result = Negocio.Tarea.BusquedaAbierta(palabra);


            if (result.Correct)
            {
                tarea.Estado = new Modelo.Estado();
                Modelo.Result resultEstados = Negocio.Estado.GetAllLINQ();
                tarea.Estado.Estados = resultEstados.Objects;

                tarea.Prioridad = new Modelo.Prioridad();
                Modelo.Result resultPrioridad = Negocio.Prioridad.GetAllLINQ();
                tarea.Prioridad.Prioridades = resultPrioridad.Objects;

                tarea.Categoria = new Modelo.Categoria();
                Modelo.Result resultCategoria = Negocio.Categoria.GetAllLINQ();
                tarea.Categoria.Categorias = resultCategoria.Objects;

                tarea.Tareas = result.Objects;
                return View(tarea);
            }
            else
            {
                return View(tarea);
            }
        }
        [HttpGet]
        public JsonResult GetAllJson()
        {
            Modelo.Tarea tarea = new Modelo.Tarea();
            Modelo.Result result = Negocio.Tarea.GetAllLINQ();

            tarea.Estado = new Modelo.Estado();
            Modelo.Result resultEstados = Negocio.Estado.GetAllLINQ();
            tarea.Estado.Estados = resultEstados.Objects;

            tarea.Prioridad = new Modelo.Prioridad();
            Modelo.Result resultPrioridad = Negocio.Prioridad.GetAllLINQ();
            tarea.Prioridad.Prioridades = resultPrioridad.Objects;

            tarea.Categoria = new Modelo.Categoria();
            Modelo.Result resultCategoria = Negocio.Categoria.GetAllLINQ();
            tarea.Categoria.Categorias = resultCategoria.Objects;


            if (result.Correct)
            {
                tarea.Tareas = result.Objects;
                return Json(tarea);
            }
            else
            {
                return Json(tarea);
            }
        }
        [HttpGet]
        public JsonResult GetAllPersonal()
        {
            Modelo.Tarea tarea = new Modelo.Tarea();
            Modelo.Result result = Negocio.Tarea.GetAllPersonal();

            tarea.Estado = new Modelo.Estado();
            Modelo.Result resultEstados = Negocio.Estado.GetAllLINQ();
            tarea.Estado.Estados = resultEstados.Objects;

            tarea.Prioridad = new Modelo.Prioridad();
            Modelo.Result resultPrioridad = Negocio.Prioridad.GetAllLINQ();
            tarea.Prioridad.Prioridades = resultPrioridad.Objects;

            tarea.Categoria = new Modelo.Categoria();
            Modelo.Result resultCategoria = Negocio.Categoria.GetAllLINQ();
            tarea.Categoria.Categorias = resultCategoria.Objects;


            if (result.Correct)
            {
                tarea.Tareas = result.Objects;
                return Json(tarea);
            }
            else
            {
                return Json(tarea);
            }
        }
        [HttpGet]
        public JsonResult GetAllProfesional()
        {
            Modelo.Tarea tarea = new Modelo.Tarea();
            Modelo.Result result = Negocio.Tarea.GetAllProfesional();

            tarea.Estado = new Modelo.Estado();
            Modelo.Result resultEstados = Negocio.Estado.GetAllLINQ();
            tarea.Estado.Estados = resultEstados.Objects;

            tarea.Prioridad = new Modelo.Prioridad();
            Modelo.Result resultPrioridad = Negocio.Prioridad.GetAllLINQ();
            tarea.Prioridad.Prioridades = resultPrioridad.Objects;

            tarea.Categoria = new Modelo.Categoria();
            Modelo.Result resultCategoria = Negocio.Categoria.GetAllLINQ();
            tarea.Categoria.Categorias = resultCategoria.Objects;


            if (result.Correct)
            {
                tarea.Tareas = result.Objects;
                return Json(tarea);
            }
            else
            {
                return Json(tarea);
            }
        }
        [HttpGet]
        public JsonResult GetById(byte idTarea)
        {
            Modelo.Tarea tarea = new Modelo.Tarea();

            //Get all Estado, Prioridad y Categoria
            tarea.Estado = new Modelo.Estado();
            Modelo.Result resultEstados = Negocio.Estado.GetAllLINQ();
            tarea.Estado.Estados = resultEstados.Objects;

            tarea.Prioridad = new Modelo.Prioridad();
            Modelo.Result resultPrioridad = Negocio.Prioridad.GetAllLINQ();
            tarea.Prioridad.Prioridades = resultPrioridad.Objects;

            tarea.Categoria = new Modelo.Categoria();
            Modelo.Result resultCategoria = Negocio.Categoria.GetAllLINQ();
            tarea.Categoria.Categorias = resultCategoria.Objects;

            Modelo.Result result = new Modelo.Result();

            result = Negocio.Tarea.GetByIdLINQ(idTarea);

            return Json(result);
        }
        [HttpPost]
        public JsonResult GuardarTarea(Modelo.Tarea tarea)
        {
            Modelo.Result result = new Modelo.Result();
            //if (ModelState.IsValid)
            //{
            if (tarea.IdTarea == 0)
            {
                //Add
                result = Negocio.Tarea.AddLINQ(tarea);
                if (result.Correct)
                {
                    return Json(result);
                }
            }
            else
            {
                //Update
                result = Negocio.Tarea.UpdateLINQ(tarea);
                if (result.Correct)
                {
                    return Json(result);
                }
            }
            //}
            //else
            //{
            //    return Json(tarea);
            //}
            return Json(tarea);
        }
        [HttpGet]
        public JsonResult Delete(byte idTarea)
        {
            Modelo.Result result = Negocio.Tarea.DeleteLINQ(idTarea);
            if (result.Correct)
            {
                return Json(result);
            }
            else
            {
                return Json(result);
            }
        }

        [HttpPost]
        public JsonResult CambiarEstatus(byte idEstatus, byte idTarea)
        {
            Modelo.Result result = Negocio.Tarea.UpdateEstado(idEstatus, idTarea);

            if (result.Correct)
            {
                return Json(result);
            }
            return Json(result);
        }
    }
}
