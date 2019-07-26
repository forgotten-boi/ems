using System;
using System.Collections.Generic;

using System.Linq;


using System.Linq.Expressions;
using System.Text;
using System.Reflection;
using EMS.Entity.BaseEntity;
using System.Linq.Dynamic.Core;

namespace EMS.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T> ApplyCompletePagination<T>(this IQueryable<T> query, IQueryObject filter)
        {
            if (filter.searchData != null && filter.searchData.Count > 0)
            {
                query = query.ApplySearching<T>(filter);

            }
            if (!String.IsNullOrEmpty(filter.SortBy))
            {
                query = query.OrderBy(filter.SortBy, filter.IsSortAscending == true ? SortDirection.Ascending : SortDirection.Descending);
            }

            query = query.ApplyPaging(filter);

            return query;
        }


        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }

        public static IEnumerable<T> ApplyOrdering<T>(this IEnumerable<T> query, IQueryObject queryObj, Dictionary<string, Func<T, object>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }
        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }

        public static IQueryable<T> OrderBy<T>(IQueryable<T> source, string ordering)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(IQueryable), "OrderBy", new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }

        public static IQueryable<T> ApplySearching<T>(this IQueryable<T> query, IQueryObject filter)
        {
            if (filter.searchData != null && filter.searchData.Count > 0)
            {
                var queryResult = new List<T>();
                StringBuilder queryString = new StringBuilder();
                var dateTime = new DateTime();

                List<DateTime> args = new List<DateTime>();
                //var dic = new Dictionary<string, object>();
                List<string> conditions = new List<string>();
                List<Object> objList = new List<object>();

                filter.searchData.ForEach(searchObj =>
                {
                    switch (searchObj.Datatype)
                    {
                        case "Date":
                            dateTime = DateTime.Parse(searchObj.Value);
                            //dic.Add(searchObj.DbKey, dateTime);
                            objList.Add(dateTime);
                            conditions.Add(string.Format(searchObj.DbKey + ".Equals(@0)", dateTime));

                            break;
                        case "String":
                            conditions.Add(searchObj.DbKey + ".ToLower().Contains(\"" + searchObj.Value.ToLower() + "\")");

                            break;
                        case "Number":
                            var number = Decimal.Parse(searchObj.Value);
                            objList.Add(number);
                            conditions.Add(string.Format(searchObj.DbKey + ".Equals(@0)", number));
                            break;
                    }
                });

                //var conditions = dic.Keys.Select((key, idx) => string.Format("{0} == @{1}", key, idx));
                string predicate = string.Join(" And ", conditions);

                //object[] values = dic.Values.ToArray();
                object[] values = objList.ToArray();

                var result = query.Where(predicate, values);
                queryResult.AddRange(result);
                return queryResult.AsQueryable();

            }
            else
            {
                return query;
            } }

        


    }

}
