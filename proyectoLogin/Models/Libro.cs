using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? IsbnLibro { get; set; }

    public string? TituloLibro { get; set; }

    public string? EdicionLibro { get; set; }

    public int? CantidadLibro { get; set; }

    public int IdEditorial { get; set; }

    public int IdEditorial1 { get; set; }

    public int IdGenero { get; set; }

    public int IdGenero1 { get; set; }

    public int IdColeccion { get; set; }

    public int IdColeccion1 { get; set; }

    public virtual Coleccione IdColeccion1Navigation { get; set; } = null!;

    public virtual Editoriale IdEditorial1Navigation { get; set; } = null!;

    public virtual Genero IdGenero1Navigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();

    public virtual ICollection<Autore> AutoresIdAutors { get; } = new List<Autore>();

    public virtual ICollection<Autore> IdAutors { get; } = new List<Autore>();

    public virtual ICollection<Prestamo> IdPrestamos { get; } = new List<Prestamo>();
}
