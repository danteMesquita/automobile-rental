using AutoMapper;
using AutomobileRentalManagementAPI.Application.Features.DeliveryPersons.CreateDeliveryPerson;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.DelyveryPersons.Create
{
    public class CreateDeliveryPersonProfile : Profile
    {
        public CreateDeliveryPersonProfile()
        {
            CreateMap<CreateDeliveryPersonRequest, CreateDeliveryPersonCommand>()
                .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.identificador))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.nome))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.cnpj))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.dataNascimento))
                .ForMember(dest => dest.DriverLicenseNumber, opt => opt.MapFrom(src => src.numeroCnh))
                .ForMember(dest => dest.DriverLicenseType, opt => opt.MapFrom(src => src.tipoCnh))
                .ForMember(dest => dest.DriverLicenseImage, opt => opt.MapFrom(src => src.imagemCnh));

            CreateMap<CreateDeliveryPersonResult, CreateDeliveryPersonResponse>()
                .ForMember(dest => dest.identificador, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.cnpj, opt => opt.MapFrom(src => src.Cnpj))
                .ForMember(dest => dest.dataNascimento, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.numeroCnh, opt => opt.MapFrom(src => src.DriverLicenseNumber))
                .ForMember(dest => dest.tipoCnh, opt => opt.MapFrom(src => src.DriverLicenseType))
                .ForMember(dest => dest.imagemCnh, opt => opt.MapFrom(src => src.DriverLicenseImage));

        }
    }
}