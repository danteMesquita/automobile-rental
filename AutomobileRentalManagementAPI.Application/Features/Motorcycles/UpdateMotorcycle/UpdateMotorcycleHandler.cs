using AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces;
using FluentValidation;
using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.Motorcycles.UpdateMotorcycle
{
    public class UpdateMotorcycleHandler : IRequestHandler<UpdateMotorcycleCommand, UpdateMotorcycleResult>
    {
        private readonly IMotorcyclePublisher _motorcyclePublisher;

        public UpdateMotorcycleHandler(IMotorcyclePublisher motorcyclePublisher)
        {
            _motorcyclePublisher = motorcyclePublisher;
        }

        public async Task<UpdateMotorcycleResult> Handle(UpdateMotorcycleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateMotorcycleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            throw new NotImplementedException();
            //if (command.Year == 2024)
            //    await _motorcyclePublisher.PublishAsync(command, "notification-queue");

            //await _motorcyclePublisher.PublishAsync(command, "motorcycle-queue");

            //return new UpdateMotorcycleResult();
        }
    }
}
