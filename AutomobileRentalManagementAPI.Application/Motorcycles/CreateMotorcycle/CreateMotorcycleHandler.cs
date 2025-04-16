using MediatR;
using FluentValidation;

namespace AutomobileRentalManagementAPI.Application.Motorcycles.CreateMotorcycle
{
    public class CreateMotorcycleHandler : IRequestHandler<CreateMotorcycleCommand, CreateMotorcycleResult>
    {
        public CreateMotorcycleHandler()
        {
            
        }

        public async Task<CreateMotorcycleResult> Handle(CreateMotorcycleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateMotorcycleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            //TODO: implement publish on queue

            throw new NotImplementedException();
        }
    }
}
