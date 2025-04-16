using AutoMapper;
using AutomobileRentalManagementAPI.Application.Motorcycles.CreateMotorcycle;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Create
{
    public class CreateMotorcycleProfile : Profile
    {
        public CreateMotorcycleProfile()
        {
            CreateMap<CreateMotorcycleRequest, CreateMotorcycleCommand>();
            CreateMap<CreateMotorcycleResult, CreateMotorcycleResponse>();
        }
    }
}