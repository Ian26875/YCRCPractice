using System;
using System.Linq;
using System.Linq.Expressions;

namespace YCRCPracticeWebApp.Repository.Interface
{
    /// <summary>
    /// Interface IGeneralRepository
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public interface IGeneralRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Delete(TEntity model);

        /// <summary>
        /// Finds the specified key values.
        /// </summary>
        /// <param name="keyValues">The key values.</param>
        /// <returns>TEntity.</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Inserts the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Insert(TEntity model);

        /// <summary>
        /// Singles the or default.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>TEntity.</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Updates the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        void Update(TEntity model);

        /// <summary>
        /// Wheres the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable&lt;TEntity&gt;.</returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}