using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mercydevs.Models;

public partial class Servicio
{
    public int Idservicio { get; set; }
    [Required]
    public string? TipoServicio { get; set; }
    [Required]
    public string? Descripcion { get; set; }
    [Required]
    public int? Precio { get; set; }
    [Required]
    public string? Tecnico { get; set; }
    [Required]
    public string? Horario { get; set; }
    [Required]
    public DateOnly? ServicioIniciado { get; set; }
    [Required]
    public DateOnly? ServicioFinalizado { get; set; }

    public virtual ICollection<Clienteservicio> Clienteservicios { get; set; } = new List<Clienteservicio>();
}
