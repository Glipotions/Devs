using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using FluentValidation;
using Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUserApp;
using Kodlama.io.Devs.Application.Features.Users.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.LoginUserApp
{
    public class RegisterUserAppCommandValidator : AbstractValidator<RegisterUserAppCommand>
    {
        public RegisterUserAppCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.FirstName)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.LastName)
                .MinimumLength(2)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Password)
                .MinimumLength(6)
                .NotEmpty()
                .NotNull();
        }
    }

}
