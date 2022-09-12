using FluentValidation;

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
