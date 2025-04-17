using MediatR;

namespace AutomobileRentalManagementAPI.Application.Motorcycles.DeleteMotorcycle
{
    public class DeleteMotorcycleCommand : IRequest<DeleteMotorcycleResponse>
    {
        public Guid Id { get; }
    }
}