using AutomobileRentalManagementAPI.CrossCutting.Validation;

namespace AutomobileRentalManagementAPI.WebApi.Common
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string mensagem { get; set; } = string.Empty;
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];
    }
}