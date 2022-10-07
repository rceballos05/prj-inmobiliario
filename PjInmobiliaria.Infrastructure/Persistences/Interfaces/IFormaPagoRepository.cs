using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    internal interface IFormaPagoRepository
    {
        Task<BaseEntityResponse<FormaPago>> ListFormaPago(BaseFilterRequest filters);
        Task<FormaPago> GetFormaPagoByIdVenta(int idVenta);
        Task<bool> RegisterFormaPago(FormaPago formaPago);
        Task<bool> EditFormaPago(FormaPago formaPago);
        Task<bool> DeleteFormaPago(int id);
    }
}
