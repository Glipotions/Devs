using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.GithubProfiles.Commands.DeleteGithubProfile
{
    public class DeleteGithubProfileCommandValidator : AbstractValidator<DeleteGithubProfileCommand>
    {
        public DeleteGithubProfileCommandValidator()
        {
            RuleFor(p => p.Id)
                 .NotEmpty();
        }
    }
}
