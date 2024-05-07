using System;
using System.Collections.Generic;

namespace Mercydevs.Models;

public partial class Cliente
{
    public int Idclientes { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Clienteservicio> Clienteservicios { get; set; } = new List<Clienteservicio>();
}
