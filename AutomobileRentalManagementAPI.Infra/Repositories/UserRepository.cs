using AutomobileRentalManagementAPI.Domain.Entities;
using AutomobileRentalManagementAPI.Domain.Repositories;
using AutomobileRentalManagementAPI.Infra.Contexts.Impl;

namespace AutomobileRentalManagementAPI.Infra.Repositories
{
    public class UserRepository : RepositoryBase<Motorcycle>, IUserRepository
    {

        public UserRepository(RentalDbContext context) : base(context) { }
    }
}
