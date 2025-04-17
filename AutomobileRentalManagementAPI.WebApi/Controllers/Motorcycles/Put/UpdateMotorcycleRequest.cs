namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put
{
    public sealed class UpdateMotorcycleRequest
    {
        public Guid NavigationId { get; init; }
        public string identificador { get; init; } = null!;
        public int ano { get; init; }
        public string modelo { get; init; } = null!;
        public string placa { get; init; } = null!;
    }
}