using AutoMapper;
using AutomobileRentalManagementAPI.Application.Features.Motorcycles.UpdateMotorcycle;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put
{
    public class UpdateMotorcycleProfile : Profile
    {
        public UpdateMotorcycleProfile()
        {
            CreateMap<UpdateMotorcycleRequest, UpdateMotorcycleCommand>()
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.placa));


            CreateMap<UpdateMotorcycleResult, UpdateMotorcycleResponse>();
        }
    }
}