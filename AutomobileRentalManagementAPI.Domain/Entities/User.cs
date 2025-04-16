using AutomobileRentalManagementAPI.Domain.Enums;

namespace AutomobileRentalManagementAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public UserType Type { get; set; }
        public string Password { get; set; } = null!;
    }
}
