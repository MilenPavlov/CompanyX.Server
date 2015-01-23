using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Services;

namespace CompanyX.Data.Interfaces
{
    public interface IBaseRepository <T>:IDisposable
    {
        Task<T> Single(object primaryKey);
        Task<List<T>> GetAll();

        Task<int> Insert(T entity);

        Task<bool> Update(T entity);

        Task<int> Delete(T entity);

        T Find(Expression<Func<T, bool>> predicate);

        IUnitOfWork UnitOfWork { get; }
    }
}
