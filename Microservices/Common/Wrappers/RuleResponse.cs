using Microsoft.AspNetCore.Mvc;

namespace Common.Wrappers
{
    public class RuleResponse
    {
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
      
        public RuleResponse()
        {
        }

        public RuleResponse(string message)
        {
            Message = message;
        }

        public static BadRequestObjectResult ModelValidationErrorRuleResponse(ActionContext context)
        {
            var errors = context.ModelState
              .Where(modelError => modelError.Value.Errors.Count > 0)
              .Select(modelError => modelError.Value.Errors.FirstOrDefault()?.ErrorMessage)
              .ToList();

            var RuleResponse = new RuleResponse()
            {
                Succeeded = false,
                Errors = errors,
                Message = "Validation errors occured",
            };

            return new BadRequestObjectResult(RuleResponse);
        }

    }
}