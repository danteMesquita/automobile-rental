using AutomobileRentalManagementAPI.Domain.Entities;
using AutomobileRentalManagementAPI.Domain.Repositories.Base;

namespace AutomobileRentalManagementAPI.Domain.Repositories.Motorcycles
{
    public interface IMotorcycleRepository : IRepositoryBase<Motorcycle>
    {
        public Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate);
    }
}