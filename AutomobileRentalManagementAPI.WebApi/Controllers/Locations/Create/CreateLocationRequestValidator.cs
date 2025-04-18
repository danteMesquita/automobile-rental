using FluentValidation;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Locations.Create
{
    public class CreateLocationRequestValidator : AbstractValidator<CreateLocationRequest>
    {
        public CreateLocationRequestValidator()
        {
            RuleFor(x => x.entregador_id)
            .NotEmpty().WithMessage("Delivery person ID is required.");

            RuleFor(x => x.moto_id)
                .NotEmpty().WithMessage("Motorcycle ID is required.");

            RuleFor(x => x.data_inicio)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(x => x.data_termino)
                .NotEmpty().WithMessage("End date is required.");

            RuleFor(x => x)
                .Must(x => x.data_termino >= x.data_inicio)
                .WithMessage("End date must be greater than or equal to start date.");

            RuleFor(x => x.data_previsao_termino)
                .NotEmpty().WithMessage("Estimated end date is required.");

            RuleFor(x => x.plano)
                .IsInEnum().WithMessage("Plan value is invalid.");
        }
    }
}