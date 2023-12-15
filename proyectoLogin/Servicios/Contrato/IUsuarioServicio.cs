using Microsoft.EntityFrameworkCore;
using proyectoLogin.Models;

namespace proyectoLogin.Servicios.Contrato
{
    public interface IUsuarioServicio
    {
        Task<Usuario> GetUsuario(string Email, string clave);

        Task<Usuario> Saveusuario(Usuario modelo);
    }
}
