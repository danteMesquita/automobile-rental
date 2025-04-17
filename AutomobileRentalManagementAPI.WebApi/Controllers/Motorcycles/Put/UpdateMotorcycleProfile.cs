using AutoMapper;
using AutomobileRentalManagementAPI.Application.Motorcycles.UpdateMotorcycle;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put
{
    public class UpdateMotorcycleProfile : Profile
    {
        public UpdateMotorcycleProfile()
        {
            CreateMap<UpdateMotorcycleRequest, UpdateMotorcycleCommand>();
            CreateMap<UpdateMotorcycleResult, UpdateMotorcycleResponse>();
        }
    }
}