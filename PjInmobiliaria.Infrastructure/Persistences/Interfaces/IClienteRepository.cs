using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<BaseEntityResponse<Cliente>> ListCliente(BaseFilterRequest filters);
        
    }
}
