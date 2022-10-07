using PjInmobiliaria.Infrastructure.Commons.Bases.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PjInmobiliaria.Infrastructure.Helpers
{
    public static class IQueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip((request.NumPages - 1) * request.Records).Take(request.Records);
        }
    }
}
