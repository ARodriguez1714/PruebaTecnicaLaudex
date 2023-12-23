using System;
using System.Collections.Generic;

namespace Datos;

public partial class Estado
{
    public byte IdEstado { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
