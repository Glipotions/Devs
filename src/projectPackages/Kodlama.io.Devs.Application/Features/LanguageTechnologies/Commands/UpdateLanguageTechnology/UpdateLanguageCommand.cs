using AutoMapper;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class UpdateLanguageTechnologyCommand : IRequest<UpdatedLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }

    }

    public class UpdateLanguageTechnologyCommandHandler : IRequestHandler<UpdateLanguageTechnologyCommand, UpdatedLanguageTechnologyDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageTechnologyRepository _languageRepository;
        private readonly LanguageTechnologyBusinessRules _languageTechnologyBusinessRules;


        public UpdateLanguageTechnologyCommandHandler(IMapper mapper, ILanguageTechnologyRepository languageRepository, LanguageTechnologyBusinessRules languageTechnologyBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageTechnologyBusinessRules = languageTechnologyBusinessRules;
        }

        public async Task<UpdatedLanguageTechnologyDto> Handle(UpdateLanguageTechnologyCommand request, CancellationToken cancellationToken)
        {
            await _languageTechnologyBusinessRules.NameCanNotBeDuplicatedWhenInserted(request.Name);
            await _languageTechnologyBusinessRules.ShouldHaveValidForeignKey(request.LanguageId);
            await _languageTechnologyBusinessRules.ShouldHaveValidId(request.Id);

            LanguageTechnology? language = await _languageRepository.GetAsync(x => x.Id == request.Id);

            language.Name = request.Name;

            var updatedLanguageTechnology = await _languageRepository.UpdateAsync(language);

            UpdatedLanguageTechnologyDto updatedLanguageTechnologyDto = _mapper.Map<UpdatedLanguageTechnologyDto>(updatedLanguageTechnology);

            return updatedLanguageTechnologyDto;
        }
    }
}
