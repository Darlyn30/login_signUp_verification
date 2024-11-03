using API_Mail.Context;
using API_Mail.Interfaces;
using API_Mail.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Mail.Services
{
    public class SesionService : ISesion
    {
        SesionContext _context;

        public SesionService(SesionContext _context)
        {
            this._context = _context;
        }
        public void deleteSesion(string email)
        {
            var registro = _context.sesion.Where(user => user.Email == email).FirstOrDefault();
            _context.sesion.Remove(registro!);
            _context.SaveChanges();
        }

        public async Task<List<Sesion>> GetCuentasByEmail(string email)
        {
            return await _context.ConsultarSesionPorEmailAsync(email);
        }

        public List<Sesion> GetSesion()
        {
            var result = _context.sesion.ToList();
            return result;
        }
    }
}
