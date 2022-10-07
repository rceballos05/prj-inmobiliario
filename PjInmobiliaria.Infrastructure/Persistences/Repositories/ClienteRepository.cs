using Microsoft.EntityFrameworkCore;
using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;
using PjInmobiliaria.Infrastructure.Persistences.Contexts;
using PjInmobiliaria.Infrastructure.Persistences.Interfaces;
using PjInmobiliaria.Utilities.Statics;

namespace PjInmobiliaria.Infrastructure.Persistences.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
       
        public ClienteRepository(PjInmobiliarioContext _context): base(_context) { }
        public async Task<BaseEntityResponse<Cliente>> ListCliente(BaseFilterRequest filters)
        {
            var response = new BaseEntityResponse<Cliente>();
            var cliente = GetEntityQuery(e => e.Estado == (int)StateTypes.Activo);
            if(filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        cliente = cliente.Where(c => c.NombreCliente!.Contains(filters.TextFilter));
                        break;
                    case 2:
                        cliente = cliente.Where(c => c.Rut!.Contains(filters.TextFilter));
                        break;

                }
            }
            if (filters.State is not null)
            {
                cliente = cliente.Where(c => c.Estado.Equals(filters.State));
            }
            //if(!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            //{
                
            //    cliente = cliente.Where(c => c.Ventas.)
            //}
            if (filters.Sort is null) filters.Sort = "Id";
            response.TotalRecords = await cliente.CountAsync();
            response.Items = await Ordering(filters,cliente).ToListAsync();
           
            return response;
        }

       

    }
}
