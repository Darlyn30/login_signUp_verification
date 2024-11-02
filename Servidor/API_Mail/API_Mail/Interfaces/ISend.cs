using API_Mail.Models;

namespace API_Mail.Interfaces
{
    public interface ISend
    {
        //el metodo para enviar el email
        Task sendEmail(string emailReceptor, string tema, string cuerpo);

        List<Cuentas> GetCuentas();
        void setCuentas(Cuentas model);
        void PutCuentas(Cuentas model);
    }
}
