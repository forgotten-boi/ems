using Microsoft.EntityFrameworkCore;
using EMS.Entity.BaseEntity;
using EMS.Entity.DtoModel;
using EMS.Entity.Entities;
using EMS.Infrastructure.Extensions;
using EMS.Repository.Irepositories;
using EMS.Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace EMS.Repository
{
    public abstract class ApplicationService<T, T2> : IApplicationService<T, T2> where T : BaseEntity<T2>
    {

        // private readonly IBusinessContext _businessContext;
        public ApplicationService(IRepository<T, T2> repository)
        //IBusinessContext businessContext)
        {
            Repository = repository;
            //  _businessContext = businessContext;
        }


        public IRepository<T, T2> Repository { get; }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<QueryResult<T>> GetAllPagedAsync(Filter filter)
        {
            var query = Repository.GetAllQueryable();
            var pagedQuery = query.ApplyCompletePagination(filter);
            var result = new QueryResult<T>
            {
                TotalItems = query.Count(),

                Items = pagedQuery.AsEnumerable()
            };
            return result;
        }

        public virtual async Task<QueryResult<T>> GetAllAsync(IQueryObject queryObj)
        {
            var result = new QueryResult<T>();
            var query = await Repository.GetAllAsync();

            result.TotalItems = query.Count();


            result.Items = query.ToList();

            return result;

        }





        public virtual async Task AddAsync(T entity)
        {
            await Repository.AddAsync(entity);
            //  await _businessContext.CommitAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Repository.Update(entity));
            //  await _businessContext.CommitAsync();
        }

        public virtual async Task DeleteAsync(T2 id)
        {
            await Repository.DeleteAsync(id);
            // await _businessContext.CommitAsync();
        }

        public virtual async Task<T> GetByIDAsync(T2 id)
        {
            return await Repository.GetByIDAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> where)
        {
            return await Repository.GetFilteredAsync(where);
        }
        public virtual async Task<T> FindByIdAsync(Expression<Func<T, bool>> where)
        {
            return await Repository.FindByIdAsync(where);
        }
        public virtual async Task DeleteAsync(Expression<Func<T, bool>> where)
        {
            await Repository.DeleteAsync(where);
        }

        //public Task DeleteAsync(Expression<Func<T, bool>> where)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> where)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> FindByIdAsync(Expression<Func<T, bool>> where)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
