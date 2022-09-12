using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommand : IRequest<CreateLanguageDto>
    {
        public string Name { get; set; }
    }

    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreateLanguageDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _businessRules;

        public CreateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules businessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _businessRules = businessRules;
        }

        public async Task<CreateLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            Language mappedLanguage = _mapper.Map<Language>(request);
            Language createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
            CreateLanguageDto createLanguageDto = _mapper.Map<CreateLanguageDto>(createdLanguage);

            return createLanguageDto;
        }
    }
}
