using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Genero
{
    public int IdGenero { get; set; }

    public string? NombreGenero { get; set; }

    public string? DescripcionGenero { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
