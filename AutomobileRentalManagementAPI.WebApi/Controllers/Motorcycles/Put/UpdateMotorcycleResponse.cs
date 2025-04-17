namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put
{
    public sealed class UpdateMotorcycleResponse
    {
        public Guid NavigationId { get; init; }
        public int MyProperty { get; init; }
        public string Identifier { get; init; } = null!;
        public int Year { get; init; }
        public string Model { get; init; } = null!;
        public string LicensePlate { get; init; } = null!;
    }
}
