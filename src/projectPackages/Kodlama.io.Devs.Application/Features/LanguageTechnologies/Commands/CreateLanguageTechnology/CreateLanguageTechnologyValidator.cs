using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnology
{
    public class CreateLanguageTechnologyCommandValidator : AbstractValidator<CreateLanguageTechnologyCommand>
    {
        public CreateLanguageTechnologyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MinimumLength(1);

            RuleFor(p => p.LanguageId)
                .NotEmpty();
        }
    }
}
