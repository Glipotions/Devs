using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Queries;
using Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Application.Features.Languages.Queries.GetByIdLanguage;
using Kodlama.io.Devs.Application.Features.Languages.Queries.GetListLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubProfileController : BaseController
    {
        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] CreateGithubProfileCommand createGithubProfileCommand)
        {
            var result = await Mediator!.Send(createGithubProfileCommand);

            return Created("", result);
        }

        [HttpGet(nameof(GetList))]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getGithubProfileQuery = new GetListGithubProfileQuery() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getGithubProfileQuery);
            return Ok(result);
        }

        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateGithubProfileCommand updateGithubProfileCommand)
        {
            var result = await Mediator!.Send(updateGithubProfileCommand);

            return Ok(result);
        }


        /// Todo: Silme tam olarak çalısmıyor. Düzeltilecek.
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubProfileCommand deleteGithubProfileCommand)
        {
            var result = await Mediator!.Send(deleteGithubProfileCommand);
            return NoContent();
        }

    }
}
