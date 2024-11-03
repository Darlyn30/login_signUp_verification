using System.ComponentModel.DataAnnotations;

namespace API_Mail.Models
{
    public class Sesion
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public bool Estatus { get; set; }
        public string Pin { get; set; }
    }
}
