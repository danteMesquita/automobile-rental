using AutomobileRentalManagementAPI.Domain.Entities;
using AutomobileRentalManagementAPI.Domain.Repositories.Motorcycles;
using AutomobileRentalManagementAPI.Infra.Contexts.Impl;
using AutomobileRentalManagementAPI.Infra.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace AutomobileRentalManagementAPI.Infra.Repositories.Motorcycles
{
    public class MotorcycleRepository : RepositoryBase<Motorcycle>, IMotorcycleRepository
    {
        public MotorcycleRepository(RentalDbContext db) : base(db)
        {
        }

        public async Task<Motorcycle?> GetByLicensePlateAsync(string licensePlate)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.LicensePlate == licensePlate);
        }
    }
}