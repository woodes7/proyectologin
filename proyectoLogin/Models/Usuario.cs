using System;
using System.Collections.Generic;

namespace proyectoLogin.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Dni { get; set; } = null!;

    public string? Napellidos { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string Clave { get; set; } = null!;

    public int IdAcceso { get; set; }

    public int IdAcceso1 { get; set; }

    public bool? EstaBloqueadoUsuario { get; set; }

    public DateTime? FchFinBloqueoUsuario { get; set; }

    public DateTime? FchAltaUsuario { get; set; }

    public DateTime? FchBajaUsuario { get; set; }

    public virtual Acceso IdAcceso1Navigation { get; set; } = null!;

    public virtual ICollection<Prestamo> Prestamos { get; } = new List<Prestamo>();
}
