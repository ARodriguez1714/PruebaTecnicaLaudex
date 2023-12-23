using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estado
    {
        public byte IdEstado { get; set; }

        public string? Nombre { get; set; }

        public List<object>? Estados { get; set; }
    }
}
