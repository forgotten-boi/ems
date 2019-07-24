using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

using PagedList.Core;
using System.Linq.Dynamic.Core;

namespace EMS.Infrastructure.Extensions
{
    public enum SortDirection
    {
        None, Ascending, Descending
    }
    public static class SortExtensions
    {
        /// <summary>
        /// Orders a datasource by a property with the specified name in the specified direction
        /// </summary>
        /// <param name="datasource">The datasource to order</param>
        /// <param name="propertyName">The name of the property to order by</param>
        /// <param name="direction">The direction</param>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> datasource, string propertyName, SortDirection direction)
        {
            return datasource.AsQueryable().OrderBy(propertyName, direction);
        }

        /// <summary>
        /// Orders a datasource by a property with the specified name in the specified direction
        /// </summary>
        /// <param name="datasource">The datasource to order</param>
        /// <param name="propertyName">The name of the property to order by</param>
        /// <param name="direction">The direction</param>
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> datasource, string propertyName, SortDirection direction)
        {
            //http://msdn.microsoft.com/en-us/library/bb882637.aspx

            if (string.IsNullOrEmpty(propertyName))
            {
                return datasource;
            }

            var type = typeof(T);
            var property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new InvalidOperationException(string.Format("Could not find a property called '{0}' on type {1}", propertyName, type));
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            const string orderBy = "OrderBy";
            const string orderByDesc = "OrderByDescending";

            string methodToInvoke = direction == SortDirection.Ascending ? orderBy : orderByDesc;

            var orderByCall = Expression.Call(typeof(Queryable),
                methodToInvoke,
                new[] { type, property.PropertyType },
                datasource.Expression,
                Expression.Quote(orderByExp));

            return datasource.Provider.CreateQuery<T>(orderByCall);
        }
    }

    public class GridSortOptions
    {
        public string Column { get; set; }
        public SortDirection Direction { get; set; }
    }

    public class PagedViewModel<T>
    {
        public PagedViewModel()
        {
            GridSortOptions = new GridSortOptions();
        }

        public ViewDataDictionary ViewData { get; set; }
        public IQueryable<T> Query { get; set; }
        public GridSortOptions GridSortOptions { get; set; }
        public string DefaultSortColumn { get; set; }
        public SortDirection DefaultSortOrder { get; set; }
        public IPagedList<T> PagedList { get; private set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public PagedViewModel<T> AddFilter(Expression<Func<T, bool>> predicate)
        {
            Query = Query.Where(predicate);
            return this;
        }

        public PagedViewModel<T> AddFilter<TValue>(string key, TValue value, Expression<Func<T, bool>> predicate)
        {
            ProcessQuery(value, predicate);
            ViewData[key] = value;
            return this;
        }

        public PagedViewModel<T> AddFilter<TValue1>(string key, TValue1 value, string key1, string value1)
        {
            ProcessQuery(value1, value);
            ViewData[key] = value;
            ViewData[key1] = value1;
            return this;
        }


        //public PagedViewModel<T> AddFilter<TValue>(string keyField, object value, Expression<Func<T, bool>> predicate,
        //    IQueryable<TValue> query, string textField)
        //{
        //    ProcessQuery(value, predicate);
        //    var selectList = query.ToSelectList(keyField, textField, value);
        //    ViewData[keyField] = selectList;
        //    return this;
        //}

        private void ProcessQuery<TValue>(TValue value, Expression<Func<T, bool>> predicate)
        {
            if (value == null) return;
            if (typeof(TValue) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(value as string)) return;
            }

            Query = Query.Where(predicate);
        }

        private void ProcessQuery<TValue>(string columnName, TValue value)
        {
            if (value == null) return;
            if (typeof(TValue) == typeof(string))
            {
                if (string.IsNullOrWhiteSpace(value as string)) return;
            }

            Query = Query.Where(columnName, value);
        }

        public PagedViewModel<T> Setup()
        {
            if (string.IsNullOrWhiteSpace(GridSortOptions.Column))
            {
                if (DefaultSortOrder != SortDirection.None)
                    GridSortOptions.Direction = DefaultSortOrder;
                else
                    GridSortOptions.Direction = SortDirection.Descending;

                GridSortOptions.Column = DefaultSortColumn;
            }
            PagedList = Query.OrderBy(GridSortOptions.Column, GridSortOptions.Direction).ToPagedList(Page ?? 1, PageSize ?? 20);
            return this;
        }
    }
}
