using AutoMapper;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class DeleteLanguageTechnologyCommand : IRequest<DeletedLanguageTechnologyDto>
    {
        public int Id { get; set; }
    }

    public class DeleteLanguageTechnologyCommandHandler : IRequestHandler<DeleteLanguageTechnologyCommand, DeletedLanguageTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;


        public DeleteLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<DeletedLanguageTechnologyDto> Handle(DeleteLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            LanguageTechnology? language = await _languageTechnologyRepository.GetAsync(x => x.Id == request.Id);

            var deletedLanguageTechnology = await _languageTechnologyRepository.DeleteAsync(language);

            DeletedLanguageTechnologyDto deletedLanguageTechnologyDto = _mapper.Map<DeletedLanguageTechnologyDto>(deletedLanguageTechnology);

            return deletedLanguageTechnologyDto;
        }
    }
}
