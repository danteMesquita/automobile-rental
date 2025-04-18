using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.Locations.PutLocation
{
    public class UpdateLocationCommand : IRequest<UpdateLocationResult>
    {
        public DateTime EndDate { get; set; }
    }
}