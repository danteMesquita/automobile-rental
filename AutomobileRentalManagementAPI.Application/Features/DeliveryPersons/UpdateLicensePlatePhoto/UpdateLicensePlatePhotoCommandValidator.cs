using FluentValidation;

namespace AutomobileRentalManagementAPI.Application.Features.DeliveryPersons.UpdateLicensePlatePhoto
{
    public class UpdateLicensePlatePhotoCommandValidator : AbstractValidator<UpdateLicensePlatePhotoRequestCommand>
    {
        public UpdateLicensePlatePhotoCommandValidator()
        {
            RuleFor(licensePlate => licensePlate.LicensePlate)
               .NotNull()
               .NotEmpty();
        }
    }
}