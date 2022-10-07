using AutoMapper;
using PjInmobiliaria.Application.Dto_s.Request;
using PjInmobiliaria.Application.Dto_s.Response;
using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;
using PjInmobiliaria.Utilities.Statics;

namespace PjInmobiliaria.Application.Mappers
{
    public class ClienteMapperProfile : Profile
    {
        public ClienteMapperProfile()
        {
            CreateMap<Cliente, ClienteDtoResponse>()
                .ForMember(x => x.IdCliente, x=> x.MapFrom(y =>y.Id))
                .ForMember(x => x.EstadoCliente, x => x.MapFrom(y => y.Estado.Equals((int)StateTypes.Activo) ? StateTypes.Activo : StateTypes.Inactivo))
                .ReverseMap();
            CreateMap<BaseEntityResponse<Cliente>,BaseEntityResponse<ClienteDtoResponse>>()
                .ReverseMap();
            CreateMap<ClienteDtoRequest, Cliente>();
        }
    }
}
