using Microsoft.Extensions.DependencyInjection;

using UsersService.Infrastructure.RulesEngine.Interfaces;
using UsersService.Infrastructure.RulesEngine.RulesEngine.Rules;

namespace UsersService.Infrastructure.RulesEngine.RulesEngine
{
    public static class ServiceExtensions
    {
        public static void AddRuleLayer(this IServiceCollection services)
        {
            services.AddScoped<IGeneralRules, GeneralRules>();
            services.AddScoped<IUserRules, UserRules>();
        }
    }
}
