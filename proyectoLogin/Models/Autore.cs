using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Autore
{
    public int IdAutor { get; set; }

    public string NombreAutor { get; set; } = null!;

    public string ApellidosAutor { get; set; } = null!;

    public virtual ICollection<Libro> IdLibros { get; } = new List<Libro>();

    public virtual ICollection<Libro> ListaLibrosIdLibros { get; } = new List<Libro>();
}
