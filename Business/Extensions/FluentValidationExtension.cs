using Common.Responses;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Business.Extensions
{
    public static class FluentValidationExtension
    {
        public static List<CustomValidationError> ConvertToCustomeValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors= new List<CustomValidationError>();
            foreach (var item in validationResult.Errors)
            {
                errors.Add(new()
                {
                    ErrorMessage = item.ErrorMessage,
                    PropertyName = item.PropertyName,
                });
            }
            return errors;
        }
    }
}
