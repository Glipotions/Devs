using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }
    }

    public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, LanguageGetByIdDto>
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public GetByIdLanguageQueryHandler(IMapper mapper, ILanguageRepository languageRepository, LanguageBusinessRules languageBusinessRules)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
        {
            Language? language = await _languageRepository.GetAsync(x => x.Id == request.Id);

            _languageBusinessRules.LanguageShouldExistWhenRequested(language);

            LanguageGetByIdDto languageGetByIdDto = _mapper.Map<LanguageGetByIdDto>(language);

            return languageGetByIdDto;

        }
    }
}
