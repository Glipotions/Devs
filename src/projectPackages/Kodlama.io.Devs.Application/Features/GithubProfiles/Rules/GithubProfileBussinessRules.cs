using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Rules
{
    public class GithubProfileBusinessRules
    {
        private readonly IGithubProfileRepository _githubProfileRepository;

        public GithubProfileBusinessRules(IGithubProfileRepository githubProfileRepository)
        {
            _githubProfileRepository = githubProfileRepository;
        }

        public async Task GithubProfileCanNotBeDuplicatedWhenInserted(int userId, string url)
        {
            var result = await _githubProfileRepository.GetAsync(b => b.UserId == userId && b.Url == url);
            if (result != null)
                throw new BusinessException("There is already same github profile assigned");
        }

        public void GithubProfileShouldExistWhenUpdated(GithubProfile githubProfile)
        {
            if (githubProfile == null)
                throw new BusinessException("Requested github profile does not exist");
        }

        public void GithubProfileShouldExistWhenDeleted(GithubProfile githubProfile)
        {
            if (githubProfile == null)
                throw new BusinessException("Requested github profile does not exist");
        }
    }
}
