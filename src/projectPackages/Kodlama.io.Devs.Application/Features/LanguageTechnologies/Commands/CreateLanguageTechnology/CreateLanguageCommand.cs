using AutoMapper;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommand : IRequest<CreateLanguageTechnologyDto>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }

    public class CreateLanguageTechnologyCommandHandler : IRequestHandler<CreateLanguageTechnologyCommand, CreateLanguageTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;

        public CreateLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageTechnologyRepository = languageRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<CreateLanguageTechnologyDto> Handle(CreateLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {

            await _languageTechnologyBusinessRules.NameCanNotBeDuplicatedWhenInserted(request.Name);
            await _languageTechnologyBusinessRules.ShouldHaveValidForeignKey(request.LanguageId);

            LanguageTechnology mappedLanguageTechnology = _mapper.Map<LanguageTechnology>(request);
            LanguageTechnology createdLanguageTechnology = await _languageTechnologyRepository.AddAsync(mappedLanguageTechnology);
            CreateLanguageTechnologyDto createLanguageTechnologyDto = _mapper.Map<CreateLanguageTechnologyDto>(createdLanguageTechnology);

            return createLanguageTechnologyDto;
        }
    }
}
