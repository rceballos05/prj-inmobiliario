using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface IInmuebleRepository
    {
        Task<BaseEntityResponse<Inmueble>> ListInmueble(BaseFilterRequest filters);
        Task<Inmueble> GetInmuebleById(int id);
        Task<bool> RegisterInmueble(Inmueble inmueble);
        Task<bool> EditInmueble(Inmueble inmueble);
        Task<bool> DeleteInmueble(int id);
    }
}
