using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using FluentValidation;
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
    public class LoginUserAppCommandValidator : AbstractValidator<LoginUserAppCommand>
    {
        public LoginUserAppCommandValidator()
        {
            RuleFor(d => d.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(d => d.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(6);
        }
    }
}
