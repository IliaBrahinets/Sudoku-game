using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku;
using System.Data.Entity;
using EntertainmentPortal.DataAccess.Common.Exceptions.Games.Sudoku;
using EntertainmentPortal.DataAccess.Context;

namespace EntertainmentPortal.DataAccess.Repositories.Sudoku
{
    /// <summary>
    /// A Basic implementaion for all repositories.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="EntertainmentPortal.DataAccess.Common.Repositories.Games.Sudoku.IRepository{TEntity}" />
    /// <seealso cref="System.IDisposable" />
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly IDbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{TEntity}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public Repository(SudokuContext dbContext) 
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<TEntity>();
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetAll();

            foreach(var property in propertySelectors)
            {
                query = query.Include(property);
            }

            return query;
        }

        /// <inheritdoc />
        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        /// <inheritdoc />
        public async virtual Task<List<TEntity>> GetAllListAsync()
        {
            return await GetAll().ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        /// <inheritdoc />
        public async virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }
        
        /// <inheritdoc />
        public virtual async Task<List<TEntity>> ExecuteQueryAsync(IQueryable<TEntity> query)
        {
            return await query.ToListAsync();
        }  

        /// <inheritdoc />
        public virtual TEntity Get(int id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(int id)
        {
            var entity = await FirstOrDefaultAsync(id).ConfigureAwait(false);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        /// <inheritdoc />
        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return GetAll().Single(predicate);

            }
            catch (InvalidOperationException ex)
            {
                throw new EntityNotFoundException("Can't find only one entity mathcing this predicate", ex);
            }
        }

        /// <inheritdoc />
        public async virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await GetAll().SingleAsync(predicate);

            }
            catch (InvalidOperationException ex)
            {
                throw new EntityNotFoundException("Can't find only one entity mathcing this predicate", ex);
            }
        }

        /// <inheritdoc />
        public virtual TEntity FirstOrDefault(int id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        /// <inheritdoc />
        public async virtual Task<TEntity> FirstOrDefaultAsync(int id)
        {
            return await GetAll().FirstOrDefaultAsync(CreateEqualityExpressionForId(id)).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        /// <inheritdoc />
        public async virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public virtual TEntity Load(int id)
        {
            return Get(id);
        }

        /// <inheritdoc />
        public TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        /// <inheritdoc />
        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        /// <inheritdoc />
        public virtual int InsertAndGetId(TEntity entity)
        {
            entity = Insert(entity);

            _dbContext.SaveChanges();

            return entity.Id;
        }

        /// <inheritdoc />
        public virtual async Task<int> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await InsertAsync(entity).ConfigureAwait(false);

            await _dbContext.SaveChangesAsync().ConfigureAwait(false);

            return entity.Id;
        }

        /// <inheritdoc />
        public virtual TEntity InsertOrUpdate(TEntity entity)
        {
            return entity.IsTransient()
                ? Insert(entity)
                : Update(entity);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return entity.IsTransient()
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }

        /// <inheritdoc />
        public virtual int InsertOrUpdateAndGetId(TEntity entity)
        {
            if (entity.IsTransient())
            {
                return InsertAndGetId(entity);
            }
            else
            {
                entity = Update(entity);

                _dbContext.SaveChanges();

                return entity.Id;
            }
        }

        /// <inheritdoc />
        public virtual async Task<int> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            if (entity.IsTransient())
            {
                return await InsertAndGetIdAsync(entity);
            }
            else
            {
                entity = await UpdateAsync(entity);

                await _dbContext.SaveChangesAsync();

                return entity.Id;
            }
        }

        /// <inheritdoc />
        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;

            return entity;
        }

        /// <inheritdoc />
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        /// <inheritdoc />
        public virtual TEntity Update(int id, Action<TEntity> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> UpdateAsync(int id, Func<TEntity, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        }

        /// <inheritdoc />
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        /// <inheritdoc />
        public void Delete(int id)
        {
            var entity = Get(id);
            _dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public async virtual Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id).ConfigureAwait(false);
            _dbSet.Remove(entity);
        }

        /// <inheritdoc />
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        /// <inheritdoc />
        public async virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await GetAll().Where(predicate).ToListAsync();
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        /// <inheritdoc />
        public virtual int Count()
        {
            return GetAll().Count();
        }

        /// <inheritdoc />
        public async virtual Task<int> CountAsync()
        {
            return await GetAll().CountAsync();
        }

        /// <inheritdoc />
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        /// <inheritdoc />
        public async virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll().Where(predicate).CountAsync();
        }

        /// <inheritdoc />
        public virtual long LongCount()
        {
            return GetAll().LongCount();
        }

        /// <inheritdoc />
        public async virtual Task<long> LongCountAsync()
        {
            return await GetAll().LongCountAsync();
        }

        /// <inheritdoc />
        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        /// <inheritdoc />
        public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCountAsync();
        }

        /// <inheritdoc />
        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(int id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(int))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
