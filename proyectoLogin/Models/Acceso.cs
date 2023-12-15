using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Acceso
{
    public int IdAcceso { get; set; }

    public string? CodigoAcceso { get; set; }

    public string? DescripcionAcceso { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
