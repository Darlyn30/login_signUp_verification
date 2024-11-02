using API_Mail.Interfaces;
using API_Mail.Models;
using API_Mail.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Mail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        ISend oSend;
        PINrandomService _random = PINrandomService.Instance();
        MailModel model = new MailModel();
        
        public SendEmailController(ISend oSend)
        {
            this.oSend = oSend;
            
            
        }

 

        [HttpGet("cuentas")]

        public IActionResult getCuentas()
        {
            var result = oSend.GetCuentas();
            return Ok(result);
        }

        [HttpPost("cuentas")]

        public void setCuentas(Cuentas model)
        {
            oSend.setCuentas(model);
        }
        [HttpPut("cuentas")]
        public void putCuentas(Cuentas model)
        {
            oSend.PutCuentas(model);
        }
    }
}
