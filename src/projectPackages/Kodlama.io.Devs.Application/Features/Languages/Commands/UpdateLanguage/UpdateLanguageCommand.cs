using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdatedLanguageDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _businessRules;

        public UpdateLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules businessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _businessRules = businessRules;
        }

        public async Task<UpdatedLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id);

            await _businessRules.LanguageShouldExistWhenRequested(language);
            await _businessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            language.Name = request.Name;

            var updatedLanguage = await _languageRepository.UpdateAsync(language);

            UpdatedLanguageDto updatedLanguageDto = _mapper.Map<UpdatedLanguageDto>(updatedLanguage);

            return updatedLanguageDto;
        }
    }
}
