using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persons.Application.Interfaces
{

        public interface IGenericRepository<TEntity> where TEntity : class
        {
       //  Task<TEntity> GetById(int id);
        //Task<IEnumerable<T>> GetAll();
        //Task Add(T entity);
        //void Delete(T entity);
        //void Update(T entity);

        IQueryable<TEntity> GetAll(bool asNoTracking = true);
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllBySpec(Expression<Func<TEntity, bool>> predicate, bool asNoTracking = true);
        Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
        Task<TEntity?> GetBySpecAsync<Spec>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> ListAsync(CancellationToken cancellationToken = default);
        Task<ICollection<TEntity>> ListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(CancellationToken cancellationToken = default);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<int> CountAsync(IQueryable<TEntity> data, CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(CancellationToken cancellationToken = default);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        ICollection<TEntity> AddRange(ICollection<TEntity> entities);
        Task<int> AddRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);
        void Delete(TEntity entity);
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        void DeleteRange(ICollection<TEntity> entities);
        Task<int> DeleteRangeAsync(ICollection<TEntity> entities, CancellationToken cancellationToken = default);
        void Update(TEntity entity);
        Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<List<TEntity>> ToListAsync(IQueryable<TEntity> data, CancellationToken cancellationToken = default);

        Task<IQueryable<TEntity>> GetbySpecifications(List<Expression<Func<TEntity, bool>>> expressions);
    }
    }

