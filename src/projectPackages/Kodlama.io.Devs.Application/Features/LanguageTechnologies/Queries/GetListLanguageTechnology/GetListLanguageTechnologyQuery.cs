using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.LanguageTechnologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology
{
    public class GetListLanguageTechnologyQuery : IRequest<LanguageTechnologyListModel>
    {
        public PageRequest PageRequest;
    }

    public class GetListLanguageTechnologyQueryHandler : IRequestHandler<GetListLanguageTechnologyQuery, LanguageTechnologyListModel>
    {
        private readonly ILanguageTechnologyRepository _languageTechnologyRepository;
        private readonly IMapper _mapper;

        public GetListLanguageTechnologyQueryHandler(ILanguageTechnologyRepository languageRepository, IMapper mapper)
        {
            _languageTechnologyRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<LanguageTechnologyListModel> Handle(GetListLanguageTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LanguageTechnology> languages = await _languageTechnologyRepository.GetListAsync
                (index: request.PageRequest.Page,
                size: request.PageRequest.PageSize,
                cancellationToken:cancellationToken);

            LanguageTechnologyListModel mappedLanguageTechnologyListModel = _mapper.Map<LanguageTechnologyListModel>(languages);

            return mappedLanguageTechnologyListModel;

        }
    }
}
