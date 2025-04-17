using AutomobileRentalManagementAPI.Application.Motorcycles.CreateMotorcycle;

namespace AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces
{
    public interface IMotorcyclePublisher
    {
        Task PublishAsync(CreateMotorcycleCommand command, string queueName);
    }
}
