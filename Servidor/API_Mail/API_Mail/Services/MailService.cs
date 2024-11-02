using API_Mail.Interfaces;
using System.Net.Mail;
using System.Net;
using API_Mail.Models;
using API_Mail.Context;
using Microsoft.EntityFrameworkCore;

namespace API_Mail.Services
{
    public class MailService : ISend
    {
        private readonly IConfiguration _config;
        PINrandomService _random = PINrandomService.Instance();
        MailModel _mailModel = new MailModel();

        CuentasContext _context;
        public MailService(IConfiguration _config, CuentasContext _context)
        {
            this._config = _config;
            this._context = _context;
        }

        public List<Cuentas> GetCuentas()
        {
            var result = _context.cuentas.ToList();
            return result;
        }

        public void PutCuentas(Cuentas model)
        {
            _context.Entry(model).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task sendEmail(string emailReceptor, string tema, string cuerpo)
        {

            /*
             estas variables serian "variables de entorno", definidos los valores en el appsettings.json
             */
            var emailEmisor = _config.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = _config.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = _config.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = _config.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtpClient = new SmtpClient(host, puerto);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;

            smtpClient.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor!, emailReceptor, tema, $"<h2>Tu código de verificación</h2><p>El código es: <strong>{cuerpo}</strong></p>")
            {
                IsBodyHtml = true // habilitamos el cuerpo con estilo html
            };
            await smtpClient.SendMailAsync(mensaje);//usamos un await ya que el metodo es asincrono en lugar de un return
        }
        public void setCuentas(Cuentas model)
        {
            model.Pin = _random.pinRandom();
            _mailModel.emailReceptor = model.Email;
            _context.cuentas.Add(model);
            Task task = sendEmail(_mailModel.emailReceptor, _mailModel.tema, model.Pin);
            _context.SaveChanges();
        }
    }
}
