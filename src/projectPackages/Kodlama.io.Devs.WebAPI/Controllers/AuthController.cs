using Kodlama.io.Devs.Application.Features.Users.Commands.LoginUserApp;
using Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUserApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register([FromBody] RegisterUserAppCommand registerUserAppCommand)
        {
            var result = await Mediator!.Send(registerUserAppCommand);
            return Created("", result);
        }

        [HttpPost(nameof(Login))]
        public async Task<ActionResult> Login([FromBody] LoginUserAppCommand loginUserAppCommand)
        {
            var result = await Mediator!.Send(loginUserAppCommand);

            return Ok(result);
        }
    }
}
