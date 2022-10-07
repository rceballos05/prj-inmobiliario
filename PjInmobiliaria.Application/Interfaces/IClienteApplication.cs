using PjInmobiliaria.Application.Commons.Bases;
using PjInmobiliaria.Application.Dto_s.Request;
using PjInmobiliaria.Application.Dto_s.Response;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;

namespace PjInmobiliaria.Application.Interfaces
{
    public interface IClienteApplication
    {
        Task<BaseResponse<BaseEntityResponse<ClienteDtoResponse>>> ListaClientes(BaseFilterRequest filters);
        Task<BaseResponse<IEnumerable<ClienteDtoResponse>>> ListaClientesCombo();
        Task<BaseResponse<ClienteDtoResponse>> ClienteById(int id);
        Task<BaseResponse<bool>> RegistrarCliente(ClienteDtoRequest cliente);
        Task<BaseResponse<bool>> EditarCliente(int id, ClienteDtoRequest cliente);
        Task<BaseResponse<bool>> EliminarCliente(int id);
    }
}
