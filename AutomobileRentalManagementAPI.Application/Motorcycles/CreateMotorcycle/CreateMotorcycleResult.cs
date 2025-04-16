namespace AutomobileRentalManagementAPI.Application.Motorcycles.CreateMotorcycle
{
    public class CreateMotorcycleResult
    {
        public string Identifier { get; set; } = null!;
        public int Year { get; set; }
        public string Model { get; set; } = null!;
        public string LicensePlate { get; set; } = null!;
    }
}