using MediatR;
using FluentValidation;
using AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces;

namespace AutomobileRentalManagementAPI.Application.Features.Motorcycles.CreateMotorcycle
{
    public class CreateMotorcycleHandler : IRequestHandler<CreateMotorcycleCommand, CreateMotorcycleResult>
    {
        private readonly IMotorcyclePublisher _motorcyclePublisher;

        public CreateMotorcycleHandler(IMotorcyclePublisher motorcyclePublisher)
        {
            _motorcyclePublisher = motorcyclePublisher;
        }

        public async Task<CreateMotorcycleResult> Handle(CreateMotorcycleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateMotorcycleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            if (command.Year == 2024)
                await _motorcyclePublisher.PublishAsync(command, "notification-queue");

            await _motorcyclePublisher.PublishAsync(command, "motorcycle-queue");

            return new CreateMotorcycleResult();
        }
    }
}
