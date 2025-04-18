using MediatR;

namespace AutomobileRentalManagementAPI.Application.Features.Motorcycles.DeleteMotorcycle
{
    public class DeleteMotorcycleCommand : IRequest<DeleteMotorcycleResponse>
    {
        public Guid Id { get; }
    }
}