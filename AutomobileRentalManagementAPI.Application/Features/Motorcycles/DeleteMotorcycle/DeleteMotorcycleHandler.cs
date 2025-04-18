using AutomobileRentalManagementAPI.Domain.Repositories.Motorcycles;
using FluentValidation;
using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.Motorcycles.DeleteMotorcycle
{
    public class DeleteMotorcycleHandler : IRequestHandler<DeleteMotorcycleCommand, DeleteMotorcycleResponse>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public DeleteMotorcycleHandler(IMotorcycleRepository MotorcycleRepository)
        {
            _motorcycleRepository = MotorcycleRepository;
        }

        public async Task<DeleteMotorcycleResponse> Handle(DeleteMotorcycleCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteMotorcycleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            // SÒ PUEDE DELETAR SE NON HOUVER LOCACION
            //var saleRelated = await _saleRepository.GetAllByMotorcycleId(request.Id, cancellationToken);
            //if (saleRelated != null && saleRelated.Count() > 0) throw new DomainException("The Motorcycle cannot be deleted as they have associated sales.");

            var motorcycle = await _motorcycleRepository.GetByIdAsync(command.Id);
            if (motorcycle != null)
                await _motorcycleRepository.DeleteAsync(motorcycle);

            return new DeleteMotorcycleResponse { Success = true };
        }
    }
}