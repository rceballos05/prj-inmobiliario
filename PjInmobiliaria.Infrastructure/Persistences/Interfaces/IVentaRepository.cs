using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface IVentaRepository
    {
        Task<BaseEntityResponse<Venta>> ListVenta(BaseFilterRequest filters);
        Task<Venta> GetVentaById(int id);
        Task<bool> RegisterVenta(Venta venta);
        Task<bool> EditVenta(Venta venta);
        Task<bool> DeleteVenta(int id);
        Task<BaseEntityResponse<Venta>> ListVentaByIdCliente(int idCliente);
    }
}
