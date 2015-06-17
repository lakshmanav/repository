using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Base
{
    /// <summary>
    /// Generic interface for an entity repository
    /// </summary>
    /// <typeparam name="TId">type of the entity identifier</typeparam>
    /// <typeparam name="TEntity">type of the entity</typeparam>
    public interface IEntityRepository<TId, TEntity> 
        where TId : struct 
        where TEntity : Entity<TId>
    {
        /// <summary>
        /// Counts all the instances of type <see cref="TEntity"/> in the repository
        /// </summary>
        /// <returns>total number of instances of type <see cref="TEntity"/></returns>
        Task<double> CountAsync();

        /// <summary>
        /// Gets an entity of type <see cref="TEntity"/> given an id of type <see cref="TId"/>
        /// </summary>
        /// <param name="id">unique identifier of the entity</param>
        /// <returns>an instance of entity matching the unique identifier</returns>
        Task<TEntity> GetAsync(TId id);

        /// <summary>
        /// Checks the existence of an entity based on the identifier
        /// </summary>
        /// <param name="id">id of the entity to be checked for existence</param>
        /// <returns>true, if an entity exists with the given id. false, otherwise</returns>
        Task<bool> ExistsAsync(TId id);

        /// <summary>
        /// Deletes an entity of type <see cref="TEntity"/> from the repository given an id
        /// </summary>
        /// <param name="id">identifier for the entity to be deleted</param>
        /// <returns>state of an entity before deletion</returns>
        Task<TEntity> DeleteAsync(TId id);

        /// <summary>
        /// Creates an entity of type <see cref="TEntity"/> if id holds null or default value.
        /// Updates the entity if the entity has a valid id and an instance of which exists in the repository
        /// </summary>
        /// <param name="entity">entity to be created or updated</param>
        /// <returns>created or updated entity</returns>
        Task<TId> SaveAsync(TEntity entity);

        /// <summary>
        /// Gets paged list of all matching entities which satisfy the query conditions
        /// </summary>
        /// <param name="query">a query implementation which can evaluate the list of matching entities</param>
        /// <param name="sorting">ordered list of fields by which the matching results will be sorted. use +fieldname for ascending sort
        /// and -fieldname for descending sort</param>
        /// <param name="skip">paging options. number of items to be skipped from the matching list</param>
        /// <param name="take">paging options. number of items to be returned from the matching list</param>
        /// <returns></returns>
        Task<PagedResult<TId, TEntity>> GetAsync(IEntityQuery<TId, TEntity> query, List<string> sorting = null,
            double? skip = null, double? take = null);

        /// <summary>
        /// Checks if any entities exists matching the given querying conditions
        /// </summary>
        /// <param name="query">a query implementation which can evaluate the list of matching entities</param>
        /// <returns>true, if there are one or more entities matching the query. false, otherwise</returns>
        Task<bool> AnyAsync(IEntityQuery<TId, TEntity> query);

        /// <summary>
        /// Gets the total number of entities matching the given querying conditions
        /// </summary>
        /// <param name="query">a query implementation which can evaluate the list of matching entities</param>
        /// <returns>total count of matching items</returns>
        Task<double> CountAsync(IEntityQuery<TId, TEntity> query);
    }
}
