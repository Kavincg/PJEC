using System.Linq.Expressions; // Important: Add this using statement for Expression<Func<T, bool>>

namespace Supermarket.Data.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Existing GetAll method
        IEnumerable<T> GetAll();

        // New or updated GetAll method that supports filtering and including related entities.
        // The 'filter' parameter is an optional expression for WHERE clauses.
        // The 'includeProperties' parameter is a comma-separated string of navigation properties to include (e.g., "ApplicationUser,OrderItems").
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> RemoveAsync(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
