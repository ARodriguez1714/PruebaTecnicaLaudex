using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Prioridad
    {
        public byte IdPrioridad { get; set; }

        public string? Nombre { get; set; }

        public List<object>? Prioridades { get; set; }
    }
}
