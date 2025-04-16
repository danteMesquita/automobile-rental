using FluentValidation;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Create
{
    public class CreateMotorcycleRequestValidator : AbstractValidator<CreateMotorcycleRequest>
    {
        public CreateMotorcycleRequestValidator()
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