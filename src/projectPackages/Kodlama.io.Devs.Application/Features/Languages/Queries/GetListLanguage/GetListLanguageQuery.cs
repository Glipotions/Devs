using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery : IRequest<LanguageListModel>
    {
        public PageRequest PageRequest;
    }

    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> languages = await _languageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(languages);

            return mappedLanguageListModel;

        }
    }
}
