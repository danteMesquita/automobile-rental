using FluentValidation;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put
{
    public class UpdateMotorcycleRequestValidator : AbstractValidator<UpdateMotorcycleRequest>
    {
        public UpdateMotorcycleRequestValidator()
        {
            RuleFor(motorcycle => motorcycle.placa)
                .NotNull()
                .NotEmpty()
                .Length(8);
        }
    }
}