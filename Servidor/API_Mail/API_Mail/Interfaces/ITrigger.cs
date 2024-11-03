using API_Mail.Models;

namespace API_Mail.Interfaces
{
    public interface ITrigger
    {
        List<Trigger> GetTrigger(); // almacena despues de crear la nueva cuenta
        void delete(string correo);
    }
}
