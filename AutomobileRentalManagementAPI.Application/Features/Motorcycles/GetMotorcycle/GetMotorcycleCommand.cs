namespace AutomobileRentalManagementAPI.Application.Features.Motorcycles.GetMotorcycle
{
    public sealed class GetMotorcycleCommand
    {
        public Guid NavigationId { get; init; }
        public string LicensePlate { get; set; } = null!;
    }
}