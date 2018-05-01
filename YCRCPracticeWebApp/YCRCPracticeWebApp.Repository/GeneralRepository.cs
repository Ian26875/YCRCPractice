using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YCRCPracticeWebApp.Repository.Interface;

namespace YCRCPracticeWebApp.Repository
{
    /// <summary>
    /// Class GeneralRepository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class GeneralRepository<TEntity> : IGeneralRepository<TEntity>
        where TEntity : class, new()
    {

        /// <summary>
        /// The unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// The database set
        /// </summary>
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public GeneralRepository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._dbSet = unitOfWork.DataBaseContext.Set<TEntity>();
        }

        /// <summary>
        /// Inserts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Insert(TEntity model)
        {
            _dbSet.Add(model);
        }

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Update(TEntity model)
        {
            var entry = _unitOfWork.DataBaseContext.Entry(model);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        public void Delete(TEntity model)
        {
            _dbSet.Remove(model);
        }

        /// <summary>
        /// Wheres the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.SingleOrDefault(predicate);
        }

        /// <summary>
        /// Finds the specified key values.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>TEntity.</returns>
        public TEntity Find(params object[] keyValues)
        {
            return _dbSet.Find(keyValues);
        }

       
    }
}
