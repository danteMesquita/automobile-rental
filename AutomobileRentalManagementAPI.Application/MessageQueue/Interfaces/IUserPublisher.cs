using AutomobileRentalManagementAPI.Domain.DomainEntities;

namespace AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces
{
    public interface IUserPublisher
    {
        Task PublishAsync(UserDomain user);
    }
}
