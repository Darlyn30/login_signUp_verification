using API_Mail.Context;
using API_Mail.Interfaces;
using API_Mail.Models;

namespace API_Mail.Services
{
    public class TriggerService : ITrigger
    {
        TriggerContext _context;
        public TriggerService(TriggerContext _context)
        {
            this._context = _context;
        }

        public void delete(string correo)
        {

            var registro = _context.cuenta_creadas.Where(user => user.Email == correo).FirstOrDefault();
            _context.cuenta_creadas.Remove(registro!);
            _context.SaveChanges();
        }

        public List<Trigger> GetTrigger()
        {
            var result = _context.cuenta_creadas.ToList();
            return result;
        }
    }
}
