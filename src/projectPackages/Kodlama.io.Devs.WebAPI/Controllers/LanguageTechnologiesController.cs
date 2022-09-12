using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {
        [HttpGet(nameof(GetList))]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var getLanguageTechnologyListQuery = new GetListLanguageTechnologyQuery() { PageRequest = pageRequest };
            var result = await Mediator!.Send(getLanguageTechnologyListQuery);
            return Ok(result);
        }

        [HttpPost(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand createLanguageTechnologyCommand)
        {
            var result = await Mediator!.Send(createLanguageTechnologyCommand);
            return Created("", result);
        }

        // Todo: update is not working !!
        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand updateLanguageTechnologyCommand)
        {
            var result = await Mediator!.Send(updateLanguageTechnologyCommand);
            return NoContent();
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteLanguageTechnologyCommand deleteLanguageTechnologyCommand)
        {
            var result = await Mediator!.Send(deleteLanguageTechnologyCommand);
            return NoContent();
        }
    }
}
