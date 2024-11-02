namespace API_Mail.Models
{
    public class MailModel
    {
        public string emailReceptor {  get; set; }
        public string tema = "pin random por correo";
        public Object Cuerpo { get; set; }
    }
}
