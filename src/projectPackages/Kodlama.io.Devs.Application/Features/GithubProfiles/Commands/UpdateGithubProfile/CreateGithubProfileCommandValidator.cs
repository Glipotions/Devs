using FluentValidation;
using Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.UpdateGithubProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class UpdateGithubProfileCommandValidator : AbstractValidator<UpdateGithubProfileCommand>
    {
        public UpdateGithubProfileCommandValidator()
        {
            RuleFor(g => g.Id)
                .NotNull();

            RuleFor(g => g.Url)
                .NotNull()
                .NotEmpty();

            RuleFor(g => g.UserId)
                .NotNull()
                .NotEmpty();
        }
    }
}
