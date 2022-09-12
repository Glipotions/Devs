using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Kodlama.io.Devs.Application.Features.Users.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.LoginUserApp
{
    public class LoginUserAppCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginUserAppCommandHandler : IRequestHandler<LoginUserAppCommand, TokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserAppBusinessRules _userAppBusinessRules;

        public LoginUserAppCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserAppBusinessRules userAppBusinessRules)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _userAppBusinessRules = userAppBusinessRules;
        }

        public async Task<TokenDto> Handle(LoginUserAppCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAsync(
                u => u.Email.ToLower() == request.Email.ToLower() && u.UserOperationClaims.Any()
            );

            _userAppBusinessRules.UserShouldExist(user);

            List<OperationClaim> operationClaims = new();
            foreach (var userOperationClaim in user.UserOperationClaims)
            {
                operationClaims.Add(userOperationClaim.OperationClaim);
            }

            _userAppBusinessRules.UserCredentialsShouldMatch(request.Password, user.PasswordHash, user.PasswordSalt);

            AccessToken token = _tokenHelper.CreateToken(user, operationClaims);

            TokenDto tokenDto = _mapper.Map<TokenDto>(token);

            return tokenDto;
        }
    }
}
