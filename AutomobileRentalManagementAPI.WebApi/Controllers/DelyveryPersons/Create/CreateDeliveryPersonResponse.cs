namespace AutomobileRentalManagementAPI.WebApi.Controllers.DelyveryPersons.Create
{
    public class CreateDeliveryPersonResponse
    {
        public Guid NavigationId { get; set; }
        public string identificador { get; init; } = null!;
        public string nome { get; init; } = null!;
        public string cnpj { get; init; } = null!;
        public DateTime dataNascimento { get; init; }
        public string numeroCnh { get; init; } = null!;
        public string tipoCnh { get; init; } = null!;
        public string imagemCnh { get; init; } = null!;
    }
}