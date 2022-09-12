using AutoMapper;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Dtos;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile
{
    public class UpdateGithubProfileCommand : IRequest<UpdatedGithubProfileDto>
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }

    public class UpdateGithubProfileCommandHandler : IRequestHandler<UpdateGithubProfileCommand, UpdatedGithubProfileDto>
    {
        private readonly IMapper _mapper;
        private readonly IGithubProfileRepository _githubProfileRepository;
        GithubProfileBusinessRules _githubProfileBussinessRules;

        public UpdateGithubProfileCommandHandler(IMapper mapper, IGithubProfileRepository githubProfileRepository, GithubProfileBusinessRules githubProfileBussinessRules)
        {
            _mapper = mapper;
            _githubProfileRepository = githubProfileRepository;
            _githubProfileBussinessRules = githubProfileBussinessRules;
        }

        public async Task<UpdatedGithubProfileDto> Handle(UpdateGithubProfileCommand request, CancellationToken cancellationToken)
        {
            var githubProfileEntity = _mapper.Map<GithubProfile>(request);
            _githubProfileBussinessRules.GithubProfileShouldExistWhenUpdated(githubProfileEntity);


            githubProfileEntity = _githubProfileRepository.Update(githubProfileEntity);

            var updatedSocialMediaDto = _mapper.Map<UpdatedGithubProfileDto>(githubProfileEntity);

            return updatedSocialMediaDto;
        }
    }
}
