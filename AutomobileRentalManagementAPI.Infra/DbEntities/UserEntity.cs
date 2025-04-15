using AutomobileRentalManagementAPI.Domain.Enums;
using AutomobileRentalManagementAPI.Infra.DbEntities.Base;

namespace AutomobileRentalManagementAPI.Infra.DbEntities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserType Type { get; set; }
        public string Password { get; set; } = null!;
    }
}