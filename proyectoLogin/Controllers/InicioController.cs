using Microsoft.AspNetCore.Mvc;
using proyectoLogin.Models;
using proyectoLogin.Recursos;
using proyectoLogin.Servicios.Contrato;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;


namespace proyectoLogin.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioServicio _usuarioServicio;
    

        public InicioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public IActionResult Registarse()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registarse(Usuario modelo)
        {
            modelo.Clave = Utilidades.EnCriptarClave(modelo.Clave);
            Usuario usuarioCreado = await _usuarioServicio.Saveusuario(modelo);

            if (usuarioCreado.IdUsuario > 0)
                return RedirectToAction("iniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }       

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string email, string clave)
        {

            Usuario usuarioEncontrado = await _usuarioServicio.GetUsuario(email, Utilidades.EnCriptarClave(clave));

            if (usuarioEncontrado.IdUsuario == null)
            {
                ViewData["Mensaje"] = "Ek usaurio y la contraseña no coinciden";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuarioEncontrado.Napellidos)
            };
            ClaimsIdentity claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authProperties = new AuthenticationProperties
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
                authProperties
                );

            return RedirectToAction("Index","Home");        
      
        
        }
    }
}
  

