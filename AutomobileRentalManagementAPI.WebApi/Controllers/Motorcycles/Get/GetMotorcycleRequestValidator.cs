using FluentValidation;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Get
{
    public class GetMotorcycleRequestValidator : AbstractValidator<GetMotorcycleRequest>
    {
        public GetMotorcycleRequestValidator()
        {
            RuleFor(motorcycle => motorcycle.LicensePlate)
              .NotNull()
              .NotEmpty()
              .Length(8);
        }
    }
}