using API_Mail.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Mail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriggerController : ControllerBase
    {
        ITrigger oTrigger;
        public TriggerController(ITrigger oTrigger)
        {
            this.oTrigger = oTrigger;
        }

        [HttpGet("cuenta_nueva")]

        public IActionResult Get()
        {
            var result = oTrigger.GetTrigger();
            return Ok(result);
        }

        [HttpDelete("cuenta_nueva")]

        public void Delete(string correo)
        {
            oTrigger.delete(correo); // esto hace que despues que se verifique, el correo, esta tabla se limpie
        }
    }
}
