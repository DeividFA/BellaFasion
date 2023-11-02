using BellaFasion.Auth;
using BellaFasion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace BellaFasion.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : ControllerBase
    {
        private readonly Login _user;

        public LoginController(  Login user)
        {
            _user = user;
        }
        [HttpPost]
        [Route("login")]
        public ActionResult Authenticate([FromBody] LoginViewModel login)
        {
            var authenticated = _user.ValidateUser(login.Username, login.Password);

            if (authenticated)
            {
                var token = _user.UsuarioAuth(login.Username, login.Password);
                return Ok(token);
            }
            else
            {
                return Unauthorized("Credenciais inválidas."); // Retorna um código 401 Unauthorized para credenciais inválidas
            }

        }
        [HttpGet]
        [Route("recurso-protegido")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult RecursoProtegido()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok("Você acessou um recurso protegido!");
        }

        [HttpPost]
        [Route("recurso-protegido")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public  ActionResult RecursoProtegido([FromHeader]int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok("Você acessou um recurso protegido! id:"+ id  );
        }
    }
}
