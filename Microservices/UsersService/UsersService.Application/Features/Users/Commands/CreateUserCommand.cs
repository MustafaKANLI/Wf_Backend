using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace UsersService.Application.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int CustomerId { get; set; }
        public int ClaimId { get; set; }
        public string? Phone { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<string>>
    {
        private readonly IUserRepositoryAsync _userRepository;

        public CreateUserCommandHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            byte[] salt, hash;

            CreatePasswordHash(request.Password, out salt, out hash);

            var user = request.Adapt<User>();
            user.PWSalt = salt;
            user.PWHash = hash; 

            await _userRepository.AddAsync(user);

            return new Response<string>(user.Id.ToString(), "User created");
        }

        private void CreatePasswordHash(string password, out byte[] salt, out byte[] hash)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
