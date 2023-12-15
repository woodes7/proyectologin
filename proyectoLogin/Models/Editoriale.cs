using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Editoriale
{
    public int IdEditorial { get; set; }

    public string? NombreEditorial { get; set; }

    public virtual ICollection<Libro> Libros { get; } = new List<Libro>();
}
