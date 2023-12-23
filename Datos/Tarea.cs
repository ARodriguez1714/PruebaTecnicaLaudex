using System;
using System.Collections.Generic;

namespace Datos;

public partial class Tarea
{
    public byte IdTarea { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public byte? IdEstado { get; set; }

    public byte? IdCategoria { get; set; }

    public byte? IdPrioridad { get; set; }
    public string? NombreEstado { get; set; }
    public string? NombrePrioridad { get; set; }
    public string? NombreCategoria { get; set; }
    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Prioridad? IdPrioridadNavigation { get; set; }
}
