using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _businessRules;

        public DeleteLanguageCommandHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules businessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _businessRules = businessRules;
        }

        public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id || x.Name == request.Name);

            await _businessRules.LanguageShouldExistWhenRequested(language);

            var deletedLanguage = await _languageRepository.DeleteAsync(language);

            DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);

            return deletedLanguageDto;
        }
    }
}
