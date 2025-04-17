using FluentValidation;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Get
{
    public class GetMotorcycleRequestValidator : AbstractValidator<GetMotorcycleRequest>
    {
        public GetMotorcycleRequestValidator()
        {
            RuleFor(motorcycle => motorcycle.placa)
              .NotNull()
              .NotEmpty()
              .Length(8);
        }
    }
}