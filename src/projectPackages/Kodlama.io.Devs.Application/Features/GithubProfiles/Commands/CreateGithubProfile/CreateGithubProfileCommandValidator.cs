using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.CreateGithubProfile
{
    public class CreateGithubProfileCommandValidator : AbstractValidator<CreateGithubProfileCommand>
    {
        public CreateGithubProfileCommandValidator()
        {
            RuleFor(g => g.UserId)
                .NotNull();

            RuleFor(g => g.Url)
                .NotEmpty()
                .NotNull();
        }
    }
}
