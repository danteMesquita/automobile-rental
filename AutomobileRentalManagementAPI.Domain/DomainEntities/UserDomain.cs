using AutomobileRentalManagementAPI.Domain.Enums;

namespace AutomobileRentalManagementAPI.Domain.DomainEntities
{
    public class UserDomain
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserType Type { get; set; }
        public string Password { get; set; } = null!;
    }
}
