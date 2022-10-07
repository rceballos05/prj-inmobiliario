using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface ICondicionVentaRepository
    {
        Task<BaseEntityResponse<CondicionVenta>> ListCondicionVenta(BaseFilterRequest filters);
        Task<CondicionVenta> GetCondicionVentaById(int id);
        Task<bool> RegisterCondicionVenta(CondicionVenta condicionVenta);
        Task<bool> EditCondicionVenta(CondicionVenta condicionVenta);
        Task<bool> DeleteCondicionVenta(int id);
    }
}
