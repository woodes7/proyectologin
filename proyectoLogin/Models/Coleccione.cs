using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Coleccione
{
    public int IdColeccion { get; set; }

    public string? NombreColeccion { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
