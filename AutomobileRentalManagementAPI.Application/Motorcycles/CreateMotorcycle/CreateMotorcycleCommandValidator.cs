using FluentValidation;

namespace AutomobileRentalManagementAPI.Application.Motorcycles.CreateMotorcycle
{
    public class CreateMotorcycleCommandValidator : AbstractValidator<CreateMotorcycleCommand>
    {
        public CreateMotorcycleCommandValidator()
        {
            RuleFor(motorcycle => motorcycle.Identifier)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.Year)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.Model)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.LicensePlate)
                .NotNull()
                .NotEmpty()
                .Length(8);
        }
    }
}