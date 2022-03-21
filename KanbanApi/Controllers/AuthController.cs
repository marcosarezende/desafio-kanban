using Microsoft.AspNetCore.Mvc;
using KanbanApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using KanbanApi.Repositories;

namespace KanbanApi.Controllers
{
    public class AuthController : Controller
    {
        private readonly SettingsAuthentication _settingsAuthentication;

        public AuthController(IOptions<SettingsAuthentication> options)
        {
            _settingsAuthentication = options.Value;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User user)
        {
            if (!(user.Login == _settingsAuthentication.LoginUser && user.Senha == _settingsAuthentication.SenhaUser))
            {
                return BadRequest(new { message = "Login ou senha inválidos" });
            }


            //gera o token para o usuário
            var token = TokenService.GenerateToken(user, _settingsAuthentication.SecretKey, _settingsAuthentication.TokenTime);

            //evita que a senha seja exposta no json retorno
            user.Senha = "";

            return Ok(token);
        }
    }
}
