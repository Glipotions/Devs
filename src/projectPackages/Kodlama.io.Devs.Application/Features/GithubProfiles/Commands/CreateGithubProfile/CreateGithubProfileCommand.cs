using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class CreateGithubProfileCommand : IRequest<CreatedGithubProfileDto>
    {
        public int UserId { get; set; }
        public string Url { get; set; }
    }

    public class CreateGithubProfileCommandHandler : IRequestHandler<CreateGithubProfileCommand, CreatedGithubProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubProfileRepository _githubProfileRepository;
        GithubProfileBusinessRules _githubProfileBussinessRules;

        public CreateGithubProfileCommandHandler(IMapper mapper, IGithubProfileRepository githubProfileRepository, GithubProfileBusinessRules githubProfileBussinessRules)
        {
            _mapper = mapper;
            _githubProfileRepository = githubProfileRepository;
            _githubProfileBussinessRules = githubProfileBussinessRules;
        }

        public async Task<CreatedGithubProfileDto> Handle(CreateGithubProfileCommand request, CancellationToken cancellationToken)
        {
            var githubProfileEntity = _mapper.Map<Domain.Entities.GithubProfile>(request);
            await _githubProfileBussinessRules.GithubProfileCanNotBeDuplicatedWhenInserted(githubProfileEntity.UserId, githubProfileEntity.Url);

            var createdGithubProfile = await _githubProfileRepository.AddAsync(githubProfileEntity);

            var createdGithubProfileDto = _mapper.Map<CreatedGithubProfileDto>(createdGithubProfile);

            return createdGithubProfileDto;
        }
    }
}
