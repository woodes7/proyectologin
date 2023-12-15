using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class EstadosPrestamo
{
    public int IdEstadoPrestamo { get; set; }

    public string CodigoEstadoPrestamo { get; set; } = null!;

    public string DescripcionEstadoPrestamo { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
