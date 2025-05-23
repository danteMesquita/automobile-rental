﻿namespace AutomobileRentalManagementAPI.WebApi.Controllers.DelyveryPersons.Create
{
    public sealed class CreateDeliveryPersonRequest
    {
        public string identificador { get; init; } = null!;
        public string nome { get; init; } = null!;
        public string cnpj { get; init; } = null!;
        public DateTime data_nascimento { get; init; }
        public string numero_cnh { get; init; } = null!;
        public string tipo_cnh { get; init; } = null!;
        public string? imagem_cnh { get; init; }
    }
}