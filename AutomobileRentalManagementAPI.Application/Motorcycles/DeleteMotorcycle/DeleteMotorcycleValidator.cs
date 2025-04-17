using FluentValidation;

namespace AutomobileRentalManagementAPI.Application.Motorcycles.DeleteMotorcycle
{
    public class DeleteMotorcycleValidator : AbstractValidator<DeleteMotorcycleCommand>
    {
        public DeleteMotorcycleValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}