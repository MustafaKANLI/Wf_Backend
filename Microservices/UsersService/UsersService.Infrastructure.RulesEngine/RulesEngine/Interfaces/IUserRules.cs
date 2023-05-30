using Common.Wrappers;
using UsersService.Application.Features.Users.Commands;


namespace UsersService.Infrastructure.RulesEngine.Interfaces
{
    public interface IUserRules : IGeneralRules
    {
        public Task<RuleResponse> ValidateCreateUser(CreateUserCommand command);
     
    }
}
