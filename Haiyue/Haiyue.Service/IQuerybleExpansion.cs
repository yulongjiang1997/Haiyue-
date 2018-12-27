using Haiyue.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Haiyue.Service
{
    public static class IQuerybleExpansion
    {
        public static IQueryable<T> Pagin<T>(this IQueryable<T> queryable, SelectBaseDto model)
        {
            return queryable.Skip((model.PageNumber - 1) * model.Amount).Take(model.Amount);
        }

        //public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryble,object value)
        //{
        //    if (value != null)
        //    {
        //        queryble = queryble.Where();
        //    }
        //}

        //public static IQueryable<T> OrderByCreateTime<T>(this IQueryable<T> queryable,DateTime CreateTime)
        //{
        //    return queryable.OrderBy(i => CreateTime);
        //}
    }
}
