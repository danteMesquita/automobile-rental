using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.DeliveryPersons.UpdateLicensePlatePhoto
{
    public class UpdateLicensePlatePhotoRequestCommand : IRequest<UpdateLicensePlatePhotoResult>
    {
        public string LicensePlate { get; set; } = null!;
    }
}