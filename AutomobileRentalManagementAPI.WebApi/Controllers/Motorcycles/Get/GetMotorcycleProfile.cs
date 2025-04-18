using AutoMapper;
using AutomobileRentalManagementAPI.Application.Features.Motorcycles.GetMotorcycle;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Get
{
    public class GetMotorcycleProfile : Profile
    {
        public GetMotorcycleProfile()
        {
            CreateMap<GetMotorcycleRequest, GetMotorcycleCommand>()
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.placa));

            CreateMap<GetMotorcycleResponse, GetMotorcycleResult>()
                .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.identificador))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.ano))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.modelo))
                .ForMember(dest => dest.LicensePlate, opt => opt.MapFrom(src => src.placa));
        }
    }
}