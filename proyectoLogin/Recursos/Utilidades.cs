using System.Security.Cryptography;
using Npgsql.EntityFrameworkCore.PostgreSQL.Internal;
using System.Text;
namespace proyectoLogin.Recursos
{
    public class Utilidades
    {
        public static string EnCriptarClave(string clave)
        {
            StringBuilder sb = new StringBuilder();

            using(SHA256 hash = SHA256Managed.Create()) {
            Encoding enc= Encoding.UTF8;

                byte[]result = hash.ComputeHash(enc.GetBytes(clave));
                foreach(byte b in result) 
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();        }
    }
}
