using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Prestamo
{
    public int IdPrestamo { get; set; }

    public int IdUsuario { get; set; }

    public int IdUsuario1 { get; set; }

    public int EstadoPrestamoIdEstadoPrestamo { get; set; }

    public DateTime? FchaInicPrestamo { get; set; }

    public DateTime? FchFinPrestamo { get; set; }

    public DateTime? FchEtregPrestamo { get; set; }

    public int IdEstadoPrestamo { get; set; }

    public int? LibroIdLibro { get; set; }

    public int? IdEstadoPrestamo1 { get; set; }

    public virtual EstadosPrestamo EstadoPrestamoIdEstadoPrestamoNavigation { get; set; } = null!;

    public virtual Prestamo? IdEstadoPrestamo1Navigation { get; set; }

    public virtual Usuario IdUsuario1Navigation { get; set; } = null!;

    public virtual ICollection<Prestamo> InverseIdEstadoPrestamo1Navigation { get; } = new List<Prestamo>();

    public virtual Libro? LibroIdLibroNavigation { get; set; }

    public virtual ICollection<Libro> IdLibros { get; } = new List<Libro>();
}
