using API_Mail.Services;
using System.ComponentModel.DataAnnotations;

namespace API_Mail.Models
{
    public class Cuentas
    {
        
        public string Nombre {  get; set; }
        [Key]
        public string Email { get; set; }
        public string Clave {  get; set; }
        public bool Estatus {  get; set; }
        public string Pin {  get; set; }
    }
}
