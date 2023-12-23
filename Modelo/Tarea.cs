using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Tarea
    {
        public byte IdTarea { get; set; }

        [RegularExpression(@"/^[a-zA-Z\s]*$/g", ErrorMessage = "*Solo acepta letras")]
        public string? Titulo { get; set; }

        [RegularExpression(@"/^[a-zA-Z\s]*$/g", ErrorMessage = "*Solo acepta letras")]
        public string? Descripcion { get; set; }

        public string? FechaVencimiento { get; set; }

        public Modelo.Categoria? Categoria { get; set; }

        public Modelo.Estado? Estado { get; set; }

        public Modelo.Prioridad? Prioridad { get; set; }

        public List<object>? Tareas { get; set; }
    }
}
