using AutomobileRentalManagementAPI.Domain.Entities;

namespace AutomobileRentalManagementAPI.Domain.Repositories.Motorcycles
{
    public interface IMotorcycleRepository : IRepositoryBase<Motorcycle>
    {
        public Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate);
    }
}