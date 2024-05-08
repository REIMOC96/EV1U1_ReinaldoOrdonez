using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mercydevs.Models;

public partial class Cliente
{ 
    
    public int Idclientes { get; set; }
    [Required]
    public string? Nombre { get; set; }
    [Required]
    public string? Apellido { get; set; }
    [Required]
    public string? Direccion { get; set; }
    [Required]
    public string? Telefono { get; set; }
    [Required]
    public string? Correo { get; set; }

    public virtual ICollection<Clienteservicio> Clienteservicios { get; set; } = new List<Clienteservicio>();
}
