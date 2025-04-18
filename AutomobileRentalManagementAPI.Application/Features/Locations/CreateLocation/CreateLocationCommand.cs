using AutomobileRentalManagementAPI.Domain.Enums;
using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.Locations.CreateLocation
{
    public sealed class CreateLocationCommand : IRequest<CreateLocationResult>
    {
        public string DeliveryPersonId { get; init; } = null!;
        public string MotorcycleId { get; init; } = null!;
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        public DateTime EstimatedEndDate { get; init; }
        public LocationPlan Plan { get; init; }
    }
}
