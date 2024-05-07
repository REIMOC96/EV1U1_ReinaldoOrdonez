using System;
using System.Collections.Generic;

namespace Mercydevs.Models;

public partial class Servicio
{
    public int Idservicio { get; set; }

    public string? TipoServicio { get; set; }

    public string? Descripcion { get; set; }

    public int? Precio { get; set; }

    public string? Tecnico { get; set; }

    public string? Horario { get; set; }

    public DateOnly? ServicioIniciado { get; set; }

    public DateOnly? ServicioFinalizado { get; set; }

    public virtual ICollection<Clienteservicio> Clienteservicios { get; set; } = new List<Clienteservicio>();
}
