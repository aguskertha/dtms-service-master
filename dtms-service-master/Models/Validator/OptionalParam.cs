
using dtms_service_master.Protos;
using FluentValidation;

namespace dtms_service_master.Models.Validator
{
    public class OptionalParamValidator : AbstractValidator<OptionalParamRequest>
    {
        public OptionalParamValidator()
        {
            // RuleFor(vendor => vendor.Id).NotEmpty().WithMessage("Vendor Id is required");
            // RuleFor(vendor => vendor.Code).NotEmpty().WithMessage("Vendor Code is required");
        }
    }
}