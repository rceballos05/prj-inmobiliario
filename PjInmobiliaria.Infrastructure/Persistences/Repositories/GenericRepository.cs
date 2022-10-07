using Microsoft.EntityFrameworkCore;
using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using PjInmobiliaria.Infrastructure.Helpers;
using PjInmobiliaria.Infrastructure.Persistences.Contexts;
using PjInmobiliaria.Infrastructure.Persistences.Interfaces;
using PjInmobiliaria.Utilities.Statics;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PjInmobiliaria.Infrastructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly PjInmobiliarioContext context;
        private readonly DbSet<T> entity;
        public GenericRepository(PjInmobiliarioContext _context)
        {
            context = _context;
            entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await entity.Where(e => e.Estado == (int)StateTypes.Activo).ToListAsync();
            return data;
        }

        public Task<T> GetByIdAsync(int id)
        {
            var data = entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return data!;
        }
        public async Task<bool> RegisterAsync(T entity)
        {
            await context.AddAsync(entity);
            var registrosAfectados = await context.SaveChangesAsync();
            return registrosAfectados > 0;
        }
        public async Task<bool> EditAsync(T entity)
        {
            context.Update(entity);
            var registrosAfectados = await context.SaveChangesAsync();
            return registrosAfectados > 0;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            context.Remove(entity);
            var registrosAfectados = await context.SaveChangesAsync();
            return registrosAfectados > 0;
        }
        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = entity;
            if(filter != null) query = query.Where(filter);
            return query;
        }

        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> query = request.Order == "desc" ? queryable.OrderBy($"{request.Sort} descending") : queryable.OrderBy($"{request.Sort} ascending");

            if (pagination) query = query.Paginate(request);
            return query;
        }
    }
}
