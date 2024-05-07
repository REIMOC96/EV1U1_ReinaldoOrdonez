using System;
using System.Collections.Generic;

namespace Mercydevs.Models;

public partial class Clienteservicio
{
    public int IdClienteServicio { get; set; }

    public int ClientesIdclientes { get; set; }

    public int ServicioIdservicio { get; set; }

    public virtual Cliente ClientesIdclientesNavigation { get; set; } = null!;

    public virtual Servicio ServicioIdservicioNavigation { get; set; } = null!;
}
