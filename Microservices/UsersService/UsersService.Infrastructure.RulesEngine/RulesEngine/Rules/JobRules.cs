using UsersService.Application.Features.Jobs.Commands;


namespace UsersService.Infrastructure.RulesEngine.RulesEngine.Rules
{
    public class JobRules
    {
        public bool ValidateCreateJob(CreateJobCommand command)
        {
            // CreateJob kurallarını doğrulayacak kodlar
            // Eğer kurallar sağlanmazsa false döndürün
            // Kurallar sağlanıyorsa true döndürün
            return true;
        }
    }
}