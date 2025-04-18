using AutomobileRentalManagementAPI.Domain.Repositories.Motorcycles;
using FluentValidation;
using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.DeliveryPersons.UpdateLicensePlatePhoto
{
    public class UpdateLicensePlatePhotoHandler : IRequestHandler<UpdateLicensePlatePhotoRequestCommand, UpdateLicensePlatePhotoResult>
    {
        private readonly IMotorcycleRepository _motorcycleRepository;

        public UpdateLicensePlatePhotoHandler(IMotorcycleRepository motorcycleRepository)
        {
            _motorcycleRepository = motorcycleRepository;
        }

        public async Task<UpdateLicensePlatePhotoResult> Handle(UpdateLicensePlatePhotoRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLicensePlatePhotoCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            var moto = await _motorcycleRepository.GetByLicensePlateAsync(request.LicensePlate);

            // TODO: TERMINAR IMPLEMENTAÇÂO
            throw new NotImplementedException();
        }
    }
}