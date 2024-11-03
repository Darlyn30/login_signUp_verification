using API_Mail.Models;

namespace API_Mail.Interfaces
{
    public interface ISesion
    {
        List<Sesion> GetSesion();
        Task<List<Sesion>> GetCuentasByEmail(string email);
        void deleteSesion(string correo);
    }
}
