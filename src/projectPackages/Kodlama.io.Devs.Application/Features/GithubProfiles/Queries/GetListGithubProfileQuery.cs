using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Queries
{
    public class GetListGithubProfileQuery:IRequest<GithubProfileListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListGithubProfileQueryHandler : IRequestHandler<GetListGithubProfileQuery, GithubProfileListModel>
    {
        private readonly IGithubProfileRepository _githubProfileRepository;
        private readonly IMapper _mapper;

        public GetListGithubProfileQueryHandler(IGithubProfileRepository githubProfileRepository, IMapper mapper)
        {
            _githubProfileRepository = githubProfileRepository;
            _mapper = mapper;
        }

        public async Task<GithubProfileListModel> Handle(GetListGithubProfileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GithubProfile> githubProfileEntity = await _githubProfileRepository.GetListAsync(
              index: request.PageRequest.Page,
              size: request.PageRequest.PageSize,
              include: m => m.Include(m => m.User)
              );
            var githubProfileListModel = _mapper.Map<GithubProfileListModel>(githubProfileEntity);

            return githubProfileListModel;
        }
    }
}
