using API_Mail.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Mail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        //esta sesion ejecutara el SP

        ISesion oSesion;

        public SesionController(ISesion oSesion)
        {
            this.oSesion = oSesion;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var result = oSesion.GetSesion();
            return Ok(result);
        }


        [HttpGet("sesion")]

        public IActionResult SetSesion(string email)
        {
            oSesion.GetCuentasByEmail(email);
            return Ok();
        }

        [HttpDelete]

        public void deleteSesion(string email)
        {
            oSesion.deleteSesion(email);
        }
    }
}
