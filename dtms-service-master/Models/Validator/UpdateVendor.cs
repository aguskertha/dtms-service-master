
using dtms_service_master.Protos;
using FluentValidation;

namespace dtms_service_master.Models.Validator
{
    public class UpdateVendorValidation : AbstractValidator<UpdateRequest>
    {
        public UpdateVendorValidation()
        {
            RuleFor(vendor => vendor.Code).NotEmpty().WithMessage("Vendor Code is required");
            RuleFor(vendor => vendor.Name).NotEmpty().WithMessage("Vendor Name is required");
        }
    }
}