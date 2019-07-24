using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Repository.Irepositories
{
    public interface IRepository<T, T2> where T : class
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIDAsync(T2 id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> where);

        IQueryable<T> GetAllWithNavigation(string[] children);
        IQueryable<T> GetAllWithNavigation(string[] children, Expression<Func<T, bool>> where);
        T GetById(T2 Id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Save(T entity);
        Task SaveAsync();
        void Save();
        void Delete(T entity);
        void Delete(T2 Id);
        Task DeleteAsync(T2 Id);
        Task<IEnumerable<T>> ExecWithStoreProcedureAsync(string ProcedureName);

        Task<IEnumerable<T>> ExecWithStoreProcedureAsync(string ProcedureName, params object[] parameters);

        Task DeleteAsync(Expression<Func<T, bool>> match);
        IEnumerable<T> GetFiltered(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> where);
        Task<T> FindByIdAsync(Expression<Func<T, bool>> where);
        IQueryable<T> GetAllQueryable();
        IQueryable<T> Table { get; }
        IQueryable<T> TableAsNoTracking { get; }
        Task<int> ExecWithStoreProcedureAsync(string query, SqlParameter[] parameter);
        DataSet ExecWithStoreProcedureMultipleData(string query, SqlParameter[] parameter);
        List<T1> CreateListFromTable<T1>(DataTable tbl) where T1 : new();
    }
}
