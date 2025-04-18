namespace AutomobileRentalManagementAPI.Application.Features.DeliveryPersons.CreateDeliveryPerson
{
    public class CreateDeliveryPersonResult
    {
        public Guid NavigationId { get; set; }
        public string Identifier { get; init; } = null!;
        public string Name { get; init; } = null!;
        public string Cnpj { get; init; } = null!;
        public DateTime BirthDate { get; init; }
        public string DriverLicenseNumber { get; init; } = null!;
        public string DriverLicenseType { get; init; } = null!;
        public string DriverLicenseImage { get; init; } = null!;
    }
}