using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ByteBank.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IDictionary<string, string[]> ToDictionary(this ValidationResult validationResult)
        {
            return validationResult.Errors
              .GroupBy(x => x.PropertyName)
              .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
              );
        }
    }
}
