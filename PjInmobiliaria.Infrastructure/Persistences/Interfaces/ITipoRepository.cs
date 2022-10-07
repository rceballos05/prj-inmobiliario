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
    public interface ITipoRepository
    {
        Task<BaseEntityResponse<Tipo>> ListTipo(BaseFilterRequest filters);
        Task<Inmueble> GetTipoByIdInmueble(int idInmueble);
        Task<bool> RegisterTipoInmueble(Tipo tipo);
        Task<bool> EditTipoInmueble(Inmueble inmueble);
        Task<bool> DeleteTipo(int idInmueble);
    }
}
