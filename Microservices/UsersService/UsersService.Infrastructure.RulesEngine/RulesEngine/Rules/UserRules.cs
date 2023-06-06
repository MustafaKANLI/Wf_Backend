using Common.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using UsersService.Application.Features.Users.Commands;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using UsersService.Infrastructure.RulesEngine.Interfaces;

namespace UsersService.Infrastructure.RulesEngine.RulesEngine.Rules
{
    public class UserRules : IUserRules
    {
        private readonly DbSet<User> _Users;
        private readonly DbSet<Claim> _Claims;
        private readonly DbSet<Customer> _Customers;

        public UserRules(UsersServiceDbContext dbContext)
        {
            _Users = dbContext.Users;
            _Claims = dbContext.Claims;
            _Customers = dbContext.Customers;
        }

        public async Task<RuleResponse> ValidateCreateUser(CreateUserCommand command)
        {
            RuleResponse ruleResponse = new RuleResponse();

            // Null alan doğrulaması
            if (string.IsNullOrEmpty(command.FullName))
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message = "Fullname is required. ";
            }

            if (string.IsNullOrEmpty(command.UserName))
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "Username is required. ";
            }

            if (string.IsNullOrEmpty(command.Email))
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "Email is required. ";
            }

            if (!Regex.IsMatch(command.Email, @"^[\w\.-]+@([\w-]+\.)+[\w-]{2,}$"))
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "Invalid email format. ";
            }

            if (command.ClaimId == null)
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "ClaimId is required. ";
            }

            if (command.CustomerId == null)
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "CustomerId is required. ";
            }

            // Diğer kurallar
            var claim = await _Claims
                .Where(x => x.Id == command.ClaimId)
                .AsNoTracking()
                .ToListAsync();

            if (!claim.Any())
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "Claim cannot found! ";
            }

            var customer = await _Customers
                .Where(x => x.Id == command.CustomerId)
                .AsNoTracking()
                .ToListAsync();

            if (!customer.Any())
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "Customer cannot found! ";
            }

            var user = await _Users
                .Where(x => x.Email == command.Email)
                .AsNoTracking()
                .ToListAsync();

            if (user.Any())
            {
                ruleResponse.Succeeded = false;
                ruleResponse.Message += "This email address already exists! ";
            }

            // Kurallar sağlanıyorsa başarılı sonucu döndürün
            else
            {
                ruleResponse.Succeeded = true;
                ruleResponse.Message = "Validation succeeded. ";
            }

            return ruleResponse;
        }
    }
}