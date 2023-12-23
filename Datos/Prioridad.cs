using System;
using System.Collections.Generic;

namespace Datos;

public partial class Prioridad
{
    public byte IdPrioridad { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
