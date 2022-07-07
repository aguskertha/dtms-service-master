
using dtms_service_master.Protos;
using FluentValidation.Results;

namespace dtms_service_master.Helpers
{
    public class Utilities
    {
        public static ErrorMessages GetValidationErrors(List<ValidationFailure> errors)
        {
            var validationErrors = new ErrorMessages();

            foreach (var error in errors)
                validationErrors.ErrorList.Add(new ErrorMessage
                {
                    Field = error.PropertyName,
                    Messages = error.ErrorMessage
                });

            return validationErrors;
        }
    }
} 