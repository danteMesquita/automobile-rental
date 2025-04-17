using FluentValidation;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put
{
    public class UpdateMotorcycleRequestValidator : AbstractValidator<UpdateMotorcycleRequest>
    {
        public UpdateMotorcycleRequestValidator()
        {
            RuleFor(motorcycles => motorcycles.NavigationId)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.identificador)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.ano)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.modelo)
                .NotNull()
                .NotEmpty();

            RuleFor(motorcycle => motorcycle.placa)
                .NotNull()
                .NotEmpty()
                .Length(8);
        }
    }
}