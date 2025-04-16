namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Create
{
    public class CreateMotorcycleRequest
    {
        public string Identifier { get; set; } = null!;
        public int Year { get; set; }
        public string Model { get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
    }
}