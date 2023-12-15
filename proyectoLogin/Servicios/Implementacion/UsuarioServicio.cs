using Microsoft.EntityFrameworkCore;
using proyectoLogin.Models;
using proyectoLogin.Servicios.Contrato;



namespace proyectoLogin.Servicios.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly DbContext _dbContext;

        public UsuarioServicio(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

         async Task<Usuario> IUsuarioServicio.GetUsuario(string Email, string clave)
        {
            // Buscar un usuario con el email y la clave proporcionados
            Usuario usuarioEncontrado = await _dbContext.Set<Usuario>()
                .FirstOrDefaultAsync(u => u.Email == Email && u.Clave == clave);

            return usuarioEncontrado;
        }

        async Task<Usuario> IUsuarioServicio.Saveusuario(Usuario modelo)
        {
            // Agregar el nuevo usuario al contexto y guardar los cambios
            _dbContext.Set<Usuario>().Add(modelo);
            await _dbContext.SaveChangesAsync();

            return modelo;
        }
    }
}
