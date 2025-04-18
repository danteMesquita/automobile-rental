using FluentValidation;

namespace AutomobileRentalManagementAPI.Application.Features.Motorcycles.UpdateMotorcycle
{
    public class UpdateMotorcycleCommandValidator : AbstractValidator<UpdateMotorcycleCommand>
    {
        public UpdateMotorcycleCommandValidator()
        {
            RuleFor(x => x.LicensePlate)
                .NotNull()
                .NotEmpty();
        }
    }
}