using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommand : IRequest<DeletedGithubProfileDto>
    {
        public int Id { get; set; }
    }

    public class DeleteGithubProfileCommandHandler : IRequestHandler<DeleteGithubProfileCommand, DeletedGithubProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubProfileRepository _githubProfileRepository;
        GithubProfileBusinessRules _githubProfileBussinessRules;

        public DeleteGithubProfileCommandHandler(IMapper mapper, IGithubProfileRepository githubProfileRepository, GithubProfileBusinessRules githubProfileBussinessRules)
        {
            _mapper = mapper;
            _githubProfileRepository = githubProfileRepository;
            _githubProfileBussinessRules = githubProfileBussinessRules;
        }

        public async Task<DeletedGithubProfileDto> Handle(DeleteGithubProfileCommand request, CancellationToken cancellationToken)
        {
            var githubProfileEntity = await _githubProfileRepository.GetAsync(x => x.Id == request.Id);

            _githubProfileBussinessRules.GithubProfileShouldExistWhenDeleted(githubProfileEntity);

            githubProfileEntity = await _githubProfileRepository.DeleteAsync(githubProfileEntity);

            var deletedGithubProfileDto = _mapper.Map<DeletedGithubProfileDto>(githubProfileEntity);

            return deletedGithubProfileDto;
        }
    }
}
