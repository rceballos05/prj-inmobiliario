﻿using PjInmobiliaria.Domain.Entities;
using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using System.Linq.Expressions;

namespace PjInmobiliaria.Infrastructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(int id);

        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);
        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest request, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
    }
}
