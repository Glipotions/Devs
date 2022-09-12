using Core.Application.Requests;
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
    public class LanguagesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreateLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand command)
        {
            DeletedLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand command)
        {
            UpdatedLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);
        }
    }
}
