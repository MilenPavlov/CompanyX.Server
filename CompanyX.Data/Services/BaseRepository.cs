using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CompanyX.Data.Interfaces;

namespace CompanyX.Data.Services
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T: class
    {
        private readonly IUnitOfWork _unitOfWork;
        internal DbSet<T> dbSet; 
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            dbSet = _unitOfWork.Db.Set<T>();
        }
        public async Task<T> Single(object primaryKey)
        {
            var dbResult = await dbSet.FindAsync(primaryKey);
            return dbResult;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<int> Insert(T entity)
        {
            dynamic obj = dbSet.Add(entity);
            await this._unitOfWork.Db.SaveChangesAsync();
            return obj.Id;
        }

        public async Task<bool> Update(T entity)
        {
            dbSet.Attach(entity);
            _unitOfWork.Db.Entry(entity).State = EntityState.Modified;
            if (await this._unitOfWork.Db.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<int> Delete(T entity)
        {
            if (_unitOfWork.Db.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dynamic obj = dbSet.Remove(entity);
            await this._unitOfWork.Db.SaveChangesAsync();
            return obj.Id;
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
        internal DbContext Database { get { return _unitOfWork.Db; } }

        public void Dispose()
        {          
        }


        public T Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<T> Filter(Expression<Func<T, bool>> filter,
        out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? dbSet.Where(filter).AsQueryable() :
                dbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) :
                resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }
    }
}
