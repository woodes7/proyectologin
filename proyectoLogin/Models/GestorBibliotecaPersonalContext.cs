using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace proyectoLogin.Models;

public partial class GestorBibliotecaPersonalContext : DbContext
{
    public GestorBibliotecaPersonalContext()
    {
    }

    public GestorBibliotecaPersonalContext(DbContextOptions<GestorBibliotecaPersonalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acceso> Accesos { get; set; }

    public virtual DbSet<Autore> Autores { get; set; }

    public virtual DbSet<Coleccione> Colecciones { get; set; }

    public virtual DbSet<Editoriale> Editoriales { get; set; }

    public virtual DbSet<EstadosPrestamo> EstadosPrestamos { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    // Configuración de la conexión a la base de datos en el método OnConfiguring
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   // Configuración de la conexión utilizando la cadena de conexión almacenada en appsettings.json
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
        .Build();

        optionsBuilder.UseNpgsql(configuration.GetConnectionString("ConnectionStr"));
    }
    // Configuración de las relaciones y nombres de tabla en el método OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acceso>(entity =>
        {
            entity.HasKey(e => e.IdAcceso);

            entity.ToTable("Accesos", "gbp_almacen");
        });

        modelBuilder.Entity<Autore>(entity =>
        {
            entity.HasKey(e => e.IdAutor);

            entity.ToTable("Autores", "gbp_almacen");

            entity.HasMany(d => d.IdLibros).WithMany(p => p.IdAutors)
                .UsingEntity<Dictionary<string, object>>(
                    "RelaccionAutoresLibro",
                    r => r.HasOne<Libro>().WithMany().HasForeignKey("IdLibro"),
                    l => l.HasOne<Autore>().WithMany().HasForeignKey("IdAutor"),
                    j =>
                    {
                        j.HasKey("IdAutor", "IdLibro");
                        j.ToTable("RelaccionAutoresLibros", "gbp_almacen");
                        j.HasIndex(new[] { "IdLibro" }, "IX_RelaccionAutoresLibros_IdLibro");
                    });

            entity.HasMany(d => d.ListaLibrosIdLibros).WithMany(p => p.AutoresIdAutors)
                .UsingEntity<Dictionary<string, object>>(
                    "AutorLibro",
                    r => r.HasOne<Libro>().WithMany().HasForeignKey("ListaLibrosIdLibro"),
                    l => l.HasOne<Autore>().WithMany().HasForeignKey("AutoresIdAutor"),
                    j =>
                    {
                        j.HasKey("AutoresIdAutor", "ListaLibrosIdLibro");
                        j.ToTable("AutorLibro", "gbp_almacen");
                        j.HasIndex(new[] { "ListaLibrosIdLibro" }, "IX_AutorLibro_ListaLibrosIdLibro");
                    });
        });

        modelBuilder.Entity<Coleccione>(entity =>
        {
            entity.HasKey(e => e.IdColeccion);

            entity.ToTable("Colecciones", "gbp_almacen");
        });

        modelBuilder.Entity<Editoriale>(entity =>
        {
            entity.HasKey(e => e.IdEditorial);

            entity.ToTable("Editoriales", "gbp_almacen");
        });

        modelBuilder.Entity<EstadosPrestamo>(entity =>
        {
            entity.HasKey(e => e.IdEstadoPrestamo);

            entity.ToTable("EstadosPrestamos", "gbp_almacen");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero);

            entity.ToTable("Generos", "gbp_almacen");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.IdLibro);

            entity.ToTable("Libros", "gbp_almacen");

            entity.HasIndex(e => e.IdColeccion1, "IX_Libros_id_coleccion");

            entity.HasIndex(e => e.IdEditorial1, "IX_Libros_id_editorial");

            entity.HasIndex(e => e.IdGenero1, "IX_Libros_id_genero");

            entity.Property(e => e.IdColeccion1).HasColumnName("id_coleccion");
            entity.Property(e => e.IdEditorial1).HasColumnName("id_editorial");
            entity.Property(e => e.IdGenero1).HasColumnName("id_genero");

            entity.HasOne(d => d.IdColeccion1Navigation).WithMany(p => p.Libros).HasForeignKey(d => d.IdColeccion1);

            entity.HasOne(d => d.IdEditorial1Navigation).WithMany(p => p.Libros).HasForeignKey(d => d.IdEditorial1);

            entity.HasOne(d => d.IdGenero1Navigation).WithMany(p => p.Libros).HasForeignKey(d => d.IdGenero1);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo);

            entity.ToTable("Prestamos", "gbp_almacen");

            entity.HasIndex(e => e.EstadoPrestamoIdEstadoPrestamo, "IX_Prestamos_EstadoPrestamoIdEstadoPrestamo");

            entity.HasIndex(e => e.LibroIdLibro, "IX_Prestamos_LibroIdLibro");

            entity.HasIndex(e => e.IdEstadoPrestamo1, "IX_Prestamos_idEstadoPrestamo");

            entity.HasIndex(e => e.IdUsuario1, "IX_Prestamos_idUsuario");

            entity.Property(e => e.FchEtregPrestamo).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FchFinPrestamo).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FchaInicPrestamo).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IdEstadoPrestamo1).HasColumnName("idEstadoPrestamo");
            entity.Property(e => e.IdUsuario).HasColumnName("Id_usuario");
            entity.Property(e => e.IdUsuario1).HasColumnName("idUsuario");

            entity.HasOne(d => d.EstadoPrestamoIdEstadoPrestamoNavigation).WithMany(p => p.Prestamos).HasForeignKey(d => d.EstadoPrestamoIdEstadoPrestamo);

            entity.HasOne(d => d.IdEstadoPrestamo1Navigation).WithMany(p => p.InverseIdEstadoPrestamo1Navigation).HasForeignKey(d => d.IdEstadoPrestamo1);

            entity.HasOne(d => d.IdUsuario1Navigation).WithMany(p => p.Prestamos).HasForeignKey(d => d.IdUsuario1);

            entity.HasOne(d => d.LibroIdLibroNavigation).WithMany(p => p.Prestamos).HasForeignKey(d => d.LibroIdLibro);

            entity.HasMany(d => d.IdLibros).WithMany(p => p.IdPrestamos)
                .UsingEntity<Dictionary<string, object>>(
                    "RelaccionLibrosPrestamo",
                    r => r.HasOne<Libro>().WithMany().HasForeignKey("IdLibro"),
                    l => l.HasOne<Prestamo>().WithMany().HasForeignKey("IdPrestamo"),
                    j =>
                    {
                        j.HasKey("IdPrestamo", "IdLibro");
                        j.ToTable("RelaccionLibrosPrestamos", "gbp_almacen");
                        j.HasIndex(new[] { "IdLibro" }, "IX_RelaccionLibrosPrestamos_IdLibro");
                    });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario", "gbp_almacen");

            entity.HasIndex(e => e.IdAcceso1, "IX_Usuario_idAcceso");

            entity.Property(e => e.FchAltaUsuario).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FchBajaUsuario).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FchFinBloqueoUsuario).HasColumnType("timestamp without time zone");
            entity.Property(e => e.IdAcceso1).HasColumnName("idAcceso");

            entity.HasOne(d => d.IdAcceso1Navigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdAcceso1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
