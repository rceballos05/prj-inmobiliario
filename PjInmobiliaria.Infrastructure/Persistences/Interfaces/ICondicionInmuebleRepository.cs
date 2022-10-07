using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface ICondicionInmuebleRepository
    {
        Task<BaseEntityResponse<CondicionInmueble>> ListCondicionInmueble(BaseFilterRequest filters);
        Task<CondicionInmueble> GetCondicionInmueble(int id);
        Task<bool> RegisterCondicionInmueble(CondicionInmueble condicionInmueble);
        Task<bool> EditCondicionInmueble(CondicionInmueble condicionInmueble);
        Task<bool> DeleteCondicionInmueble(int id);
    }
}
