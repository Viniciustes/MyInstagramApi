using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyInstagramApi.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid guid);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> expression);

        Task<TEntity> GetByIdAsync(Guid guid);

        Task<IList<TEntity>> GetAllAsync();

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(Guid guid);

        Task<TEntity> CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(Guid guid);
    }
}
