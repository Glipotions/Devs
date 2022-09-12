using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Users.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Users.Commands.RegisterUserApp
{
    public class RegisterUserAppCommand : IRequest<TokenDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class RegisterUserAppCommandHandler : IRequestHandler<RegisterUserAppCommand, TokenDto>
    {
        private readonly IUserRepository _userAppRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;

        public RegisterUserAppCommandHandler(IUserRepository userAppRepository, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userAppRepository = userAppRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public async Task<TokenDto> Handle(RegisterUserAppCommand request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            var userAppEntity = _mapper.Map<User>(request);
            userAppEntity.PasswordHash = passwordHash;
            userAppEntity.PasswordSalt = passwordSalt;
            //(userAppEntity.PasswordHash, userAppEntity.PasswordSalt) = (passwordHash, passwordSalt);

            var createdUserApp = await _userAppRepository.AddAsync(userAppEntity);

            AccessToken token = _tokenHelper.CreateToken(createdUserApp, new List<OperationClaim>());

            TokenDto tokenDto = _mapper.Map<TokenDto>(token);

            return tokenDto;
        }
    }

}
