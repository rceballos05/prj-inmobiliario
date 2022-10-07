//using Microsoft.EntityFrameworkCore;
//using PjInmobiliaria.Domain.Entities;
//using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
//using PjInmobiliaria.Infrastructure.Commons.Bases.Responses;
//using PjInmobiliaria.Infrastructure.Persistences.Contexts;
//using PjInmobiliaria.Infrastructure.Persistences.Interfaces;
//using PjInmobiliaria.Utilities.Statics;
 
//namespace PjInmobiliaria.Infrastructure.Persistences.Repositories
//{
//    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
//    {
//        private readonly PjInmobiliarioContext context;
//        public VentaRepository(PjInmobiliarioContext _context)
//        {
//            context = _context;
//        }
//        public async Task<BaseEntityResponse<Venta>> ListVenta(BaseFilterRequest filters)
//        {
//            var response = new BaseEntityResponse<Venta>();
//            var venta = context.Venta.Where(v => v.IdClienteNavigation.Estado == (int)StateTypes.Activo).AsNoTracking().AsQueryable();
            
//            if(!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
//            {
//                venta = venta.Where(v => v.FechaVenta > Convert.ToDateTime(filters.StartDate) && v.FechaVenta < Convert.ToDateTime(filters.EndDate).AddDays(1));
//            }
//            if (filters.Sort is null) filters.Sort = "IdVenta";

//            response.TotalRecords = await venta.CountAsync();
//            response.Items = await Ordering(filters, venta).ToListAsync();

//            return response;
//        }

//        public async Task<Venta> GetVentaById(int id)
//        {
//            var venta = await context.Venta.Where(v => v.IdVenta == id).FirstOrDefaultAsync();
//            return venta!;
//        }
//        public async Task<BaseEntityResponse<Venta>> ListVentaByIdCliente(int idCliente)
//        {
//            var response = new BaseEntityResponse<Venta>();
//            var venta = context.Venta.Where(v => v.IdCliente == idCliente && v.IdClienteNavigation.Estado == (int)StateTypes.Activo).AsNoTracking().AsQueryable();

//            response.TotalRecords = await venta.CountAsync();
//            response.Items = await venta.ToListAsync();
//            return response;
//        }

//        public async Task<bool> RegisterVenta(Venta venta)
//        {
//            await context.AddAsync(venta);
//            var registrosAfectados = await context.SaveChangesAsync();
//            return registrosAfectados > 0;
//        }
//        public async Task<bool> EditVenta(Venta venta)
//        {
//            context.Update(venta);
//            var registrosAfectados = await context.SaveChangesAsync();
//            return registrosAfectados > 0;
//        }

//        public async Task<bool> DeleteVenta(int id)
//        {
//            var venta = await context.Venta.AsNoTracking().SingleOrDefaultAsync(v => v.IdVenta == id);
//            var registrosAfectados = await context.SaveChangesAsync();
//            return registrosAfectados > 0;
//        }

//    }
//}
